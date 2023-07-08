/* Well the project that I am working on is a program that shows a menu of typical dishes with their price where you can choose each of them then also shows you a menu of options which you can see the menus you chose the amount of money also has the option to put extras to your menu and you can save the menu and load it for the next purchase also You have the option of payment method and pay if you pay more than 5 times the next purchase will have a discount and if you pay by debit card you will also have discounts.

So far in my program, I have implemented the classes Food, MenuFood, CustomFood, Extra, Order, Restaurant, Payment, and bonus. These classes represent food, menu foods, custom foods, extras, orders, and restaurant, respectively.
Although the payment and bonus classes are still empty, there are still some attribute functions such as saving and loading.
The rest of my classes are already  with inheritance  and polymorphism such as:
The food class is an abstract class that contains properties and methods common to all foods. The MenuFood, CustomFood, and Extra classes inherit from the Food class and provide a specific implementation of the Display() method, which displays the name and price of the food.
The Order class is responsible for managing the selected foods and the total amount of the order.

The Restaurant class contains a list of foods available on the menu, an instance of the Order class for the current order, and several methods for interacting with the ordering system.

The Start() method in the Restaurant class is the entry point of the program. It implements a loop that displays a menu of options to the user and allows interaction with the ordering system.*/


using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Restaurant restaurant = new Restaurant();
        restaurant.Start();
    }
}