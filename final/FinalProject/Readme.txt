This project is a program that simulates a fast food restaurant Peruvian foods. Here's an explanation of the different parts of the code:

The abstract class Food is the base class of the food hierarchy. It has private properties for the name and price, as well as methods to get the name and price of the food. Additionally, it has an abstract method Display that must be implemented in the derived classes.

The MenuFood and Extra classes are derived classes of Food that represent menu items and extras, respectively. These classes implement the Display method to show the name and price of the food.

The Order class handles the current customer order. It has a list of food items _foodItems, a total amount _totalAmount, a payment count _paymentCount, and a Bonus object to apply discounts. The class provides methods to add and remove food items from the order, display the order, save and load the order from a file, process the payment, and reset the order.

The Bonus class represents a discount bonus that can be applied to an order. It has a _hasBonus field to indicate if the bonus is active, and methods to set the bonus, check if there is a bonus, apply discounts, and reset the bonus.

The Payment class handles the payment process. It takes the current order and the restaurant as arguments in its constructor. The ProcessPayment method performs the payment processing based on the selected payment method and the amount paid.

The Restaurant class is the main class that controls the program logic. It has lists of menu items and extras, an instance of the Order class to handle the current order, an instance of the Payment class to handle payments, and other variables such as the selected payment method and an _exit flag to control program termination. The class provides methods to display the menu and extras, add and remove food items from the order, display the order, save and load the order from a file, select the payment method, process the payment, and reset the order. The Start method contains a loop that displays a menu of options to the user and calls the corresponding methods based on the user's choice.

The Program class contains the Main method that creates an instance of the Restaurant class and calls the Start method to begin the program.

The code adheres to the principles of encapsulation, inheritance, and polymorphism by using appropriate classes and methods to encapsulate functionality, inherit common behaviors in base classes, and utilize polymorphism through the Food base class and its derived classes MenuFood, Extra, and CustomFood

In summary, the program functions as follows: it displays a menu with 9 options. The first option shows a list of Peruvian dishes to choose from, along with their respective prices. As the user selects items, the total cost accumulates. The second option allows the user to view their selected items with their prices. Option 3 displays the total amount of the order. The program also provides the option to save the order for future purchases and to load a previously saved order. There is also a payment option, where the user can choose between credit card, debit card (which applies a 20% discount), or cash. If the cash option is selected and the payment is greater than the total amount, the program calculates and returns the change. The program features a creative aspect of offering additional menu items, including the option to enter a custom dish. The additional menu items all have the same price. That is the essence of this project.