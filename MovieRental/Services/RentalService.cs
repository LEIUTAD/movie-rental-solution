﻿using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Dto;
using MovieRental.Models;
using MovieRental.PaymentProviders;


namespace MovieRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly MovieRentalDbContext _movieRentalDb;

        public RentalService(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        public async Task<RentalResponseDto> CreateRentalAsync(RentalDto dto)
        {
            double price = dto.DaysRented * 5.0;
            var provider = PaymentProviderFactory.GetProvider(dto.PaymentMethod);
            bool success = await provider.PayAsync(price);

            if (!success)
                throw new ApplicationException("Payment failed. Rental not saved.");

            var rental = new Rental
            {
                MovieId = dto.MovieId,
                CustomerId = dto.CustomerId,
                DaysRented = dto.DaysRented,
                PaymentMethod = dto.PaymentMethod
            };

            _movieRentalDb.Rentals.Add(rental);
            await _movieRentalDb.SaveChangesAsync();

            
            await _movieRentalDb.Entry(rental).Reference(r => r.Movie).LoadAsync();
            await _movieRentalDb.Entry(rental).Reference(r => r.Customer).LoadAsync();

            return new RentalResponseDto
            {
                Id = rental.Id,
                DaysRented = rental.DaysRented,
                MovieTitle = rental.Movie.Title,
                CustomerName = rental.Customer.Name,
                PaymentMethod = rental.PaymentMethod
            };
        }

        public async Task<List<RentalResponseDto>> GetRentalsByCustomerNameAsync(string customerName)
        {
            return await _movieRentalDb.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Where(r => r.Customer.Name.ToLower() == customerName.ToLower())
                .Select(r => new RentalResponseDto
                {
                    Id = r.Id,
                    DaysRented = r.DaysRented,
                    MovieTitle = r.Movie.Title,
                    CustomerName = r.Customer.Name,
                    PaymentMethod = r.PaymentMethod
                })
                .ToListAsync();
        }
    }
}