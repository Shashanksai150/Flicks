# Flicks
Movie Rental System

Flicks is a private organization which allows people to rent movies for its registered and paid customers. Movies that can be rented can be of different languages and in each language customers can choose different genres of movies. This company wants a web based application which can be used by customers to rent the movies on-line and their internal teams like Admin and clerks to use the application to manage the movie catalog which will be presented to the customer who want to rent the movies. Below are the requirements for the specified web site.

•	User should be able to search for different movies based on language and genres.
•	User once he logins in successfully to his account should be presented with the top ten movies that are currently being rented by other people.
•	User should be classified as silver, gold and platinum category where Silver type of user can borrow total of 2 movies, gold can borrow 3 movies and platinum user can borrow 5 movies as maximum movies currently rented. No more rental is allowed if the limit is reached
•	Once the movie is borrowed by a customer the stock available to be reduced by one and when returned stock should be increased by one.
•	 User should be able to rent these movies for a day and return it and cost should be calculated depending upon how many days the movie is there with the customer and 10% of the cost of the movie Blu ray cost per day should be computed and 18% GST has to be added on the cost. 
•	User should be able to view his previous rentals and current rentals as a list.
•	User should be able to cancel his rental if the rental is not delivered.

Admin User
•	Should be able to add customer details to database. Customer should be identified by his unique mobile number.
•	Should be able to Add, Update and delete movies into the database
•	Approve the movie rental placed by users and stock should be reduced by one for that movie.
•	Assign the movie to be delivered to Delivery user.
•	Any outstanding movies not returned by users more than 10 days should be shown to admin as a list.
Delivery User
•	Should be able to check out the movie to be delivered to all users and update the delivery date so that the rental calculation is based on this date and time till the time the returned back to the database.
•	Should be able to check In the movie which are returned by users and update return date which will be used to calculate the number of days. The stock for the movie should be increased by one on return

Common Options
•	All Users should be able to change password. New password should be prompted to change every month.
•	All user should be able to View and edit profile.
