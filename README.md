# MovieRental Exercise

This is a dummy representation of a movie rental system.
Can you help us fix some issues and implement missing features?

 * The app is throwing an error when we start, please help us. Also, tell us what caused the issue. A : Since DbContext is typically registered as Scoped, any service that depends on it — like RentalFeatures — cannot be 
  registered as Singleton, otherwise it will cause a lifetime mismatch error.
 * The rental class has a method to save, but it is not async, can you make it async and explain to us what is the difference? A : The original Save method in the Rental class wasn’t async, which means it blocked the system 
   while saving data to the database. We changed it to use async/await, so the app can keep running smoothly while waiting for the database. This makes the system faster and more responsive, especially when there are many 
   users at the same time.
 * Please finish the method to filter rentals by customer name, and add the new endpoint.
 * We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
   Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!
 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it. A: While the current GetAll method is valid and functional, it would benefit from being asynchronous and supporting pagination to improve performance and scalability in larger systems.
 * No exceptions are being caught in this api, how would you deal with these exceptions? A : To make the API robust and ready, a global exception handler should be used to catch unhandled errors, while expected exceptions should be handled locally in services or controllers, always returning clear and meaningful HTTP status codes.


	## Challenge (Nice to have)
We need to implement a new feature in the system that supports automatic payment processing. Given the advancements in technology, it is essential to integrate multiple payment providers into our system.

Here are the specific instructions for this implementation:

* Payment Provider Classes:
    * In the "PaymentProvider" folder, you will find two classes that contain basic (dummy) implementations of payment providers. These can be used as a starting point for your work.
* RentalFeatures Class:
    * Within the RentalFeatures class, you are required to implement the payment processing functionality.
* Payment Provider Designation:
    * The specific payment provider to be used in a rental is specified in the Rental model under the attribute named "PaymentMethod".
* Extensibility:
    * The system should be designed to allow the addition of more payment providers in the future, ensuring flexibility and scalability.
* Payment Failure Handling:
    * If the payment method fails during the transaction, the system should prevent the creation of the rental record. In such cases, no rental should be saved to the database.
