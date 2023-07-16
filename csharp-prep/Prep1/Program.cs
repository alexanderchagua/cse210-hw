using System;
using System.Collections.Generic;
using System.IO;

abstract class Food
{
    private string _name;
    private double _price;

    public Food(string name, double price)
    {
        _name = name;
        _price = price;
    }

    public string GetName()
    {
        return _name;
    }

    public double GetPrice()
    {
        return _price;
    }

    public abstract void Display();
}

class MenuFood : Food
{
    public MenuFood(string name, double price) : base(name, price)
    {
    }

    public override void Display()
    {
        Console.WriteLine(GetName() + " - $" + GetPrice());
    }
}

class CustomFood : Food
{
    public CustomFood(string name, double price) : base(name, price)
    {
    }

    public override void Display()
    {
        Console.WriteLine(GetName() + " - $" + GetPrice());
    }
}

class Extra : Food
{
    public Extra(string name, double price) : base(name, price)
    {
    }

    public override void Display()
    {
        Console.WriteLine(GetName() + " - $" + GetPrice());
    }
}

class Order
{
    private List<Food> _foodItems;
    private double _totalAmount;

    public Order()
    {
        _foodItems = new List<Food>();
        _totalAmount = 0;
    }

    public void AddFoodItem(Food food)
    {
        _foodItems.Add(food);
        _totalAmount += food.GetPrice();
    }

    public void RemoveFoodItem(Food food)
    {
        _foodItems.Remove(food);
        _totalAmount -= food.GetPrice();
    }

    public double GetTotalAmount()
    {
        return _totalAmount;
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Current Order:");
        foreach (Food food in _foodItems)
        {
            food.Display();
        }
        Console.WriteLine("Total Amount: $" + _totalAmount);
    }
}

class Restaurant
{
    private List<Food> _menu;
    private Order _currentOrder;

    public Restaurant()
    {
        _menu = new List<Food>()
        {
            new MenuFood("1. Aji de Gallina", 10),
            new MenuFood("2. Lomo Saltado", 30),
            new MenuFood("3. Ceviche", 40),
            new MenuFood("4. Chaufa de Pollo", 60),
            new MenuFood("5. Pachamanca", 30)
        };

        _currentOrder = new Order();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (Food food in _menu)
        {
            food.Display();
        }
    }

    public void AddFoodToOrder(Food food)
    {
        _currentOrder.AddFoodItem(food);
    }

    public void RemoveFoodFromOrder(Food food)
    {
        _currentOrder.RemoveFoodItem(food);
    }

    public void DisplayOrder()
    {
        _currentOrder.DisplayOrder();
    }

    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("----- Fast Food Restaurant -----");
            Console.WriteLine("1. Choose Food");
            Console.WriteLine("2. View Order");
            Console.WriteLine("3. Display Total Amount");
            Console.WriteLine("4. Add Extra");
            Console.WriteLine("5. Save Order");
            Console.WriteLine("6. Load Order");
            Console.WriteLine("7. Payment Method");
            Console.WriteLine("8. Pay Order");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    bool chooseMore = true;
                    while (chooseMore)
                    {
                        DisplayMenu();
                        Console.Write("Enter the number of the food item (0 to exit): ");
                        if (int.TryParse(Console.ReadLine(), out int foodNumber))
                        {
                            if (foodNumber >= 1 && foodNumber <= _menu.Count)
                            {
                                Food selectedFood = _menu[foodNumber - 1];
                                AddFoodToOrder(selectedFood);
                                Console.WriteLine(selectedFood.GetName() + " added to the order.");
                            }
                            else if (foodNumber == 0)
                            {
                                chooseMore = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid food number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid food number.");
                        }
                    }
                    break;
                case "2":
                    DisplayOrder();
                    break;
                case "3":
                    double totalAmount = _currentOrder.GetTotalAmount();
                    Console.WriteLine("Total Amount: $" + totalAmount);
                    break;
                case "4":
                    // Code for adding extras to the order
                    break;
                case "5":
                    // Code for saving the order to a file
                    break;
                case "6":
                    // Code for loading an order from a file
                    break;
                case "7":
                    // Code for selecting a payment method
                    break;
                case "8":
                    // Code for paying the order
                    break;
                case "9":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
<<<<<<< HEAD
       
=======
        Restaurant restaurant = new Restaurant();
        restaurant.Start();
>>>>>>> 289e54caad6f49a1fc93076b2d7bedc66e9f75bc
    }
}