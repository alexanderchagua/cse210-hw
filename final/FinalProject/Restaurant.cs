class Restaurant
{
    private List<Food> _menu;
    private Order _currentOrder;
    private List<Food> _extras;
    private Payment _payment;
    private string _paymentMethod;
    private bool _exit;

    public Restaurant()
    {
        _menu = new List<Food>()
        {
            new MenuFood("1. Aji de Gallina", 10),
            new MenuFood("2. Lomo Saltado ", 30),
            new MenuFood("3. Ceviche ", 40),
            new MenuFood("4. Chaufa de Pollo ", 60),
            new MenuFood("5. Pachamanca ", 30)
        };

        _extras = new List<Food>()
        {
            new Extra("1. Bacon ", 20),
            new Extra("2. Cheese ", 20),
            new Extra("3. Extra Sauce ", 20),
            new Extra("4. Custom Dish ", 20)
        };

        _currentOrder = new Order();
        _payment = new Payment(_currentOrder, this);
        _exit = false;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (Food food in _menu)
        {
            food.Display();
        }
    }

    public void DisplayExtras()
    {
        Console.WriteLine("Extras:");
        foreach (Food extra in _extras)
        {
            extra.Display();
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

    public void SaveOrderToFile()
    {
        Console.Write("Enter the filename to save the order: ");
        string filename = Console.ReadLine();
        _currentOrder.SaveOrderToFile(filename);
    }

    public void LoadOrderFromFile()
    {
        Console.Write("Enter the filename to load the order: ");
        string filename = Console.ReadLine();
        _currentOrder.LoadOrderFromFile(filename);
    }

    public void Start()
    {
        while (!_exit)
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
                    DisplayTotalAmount();
                    break;
                case "4":
                    bool addMoreExtras = true;
                    while (addMoreExtras)
                    {
                        DisplayExtras();
                        Console.Write("Enter the number of the extra (0 to exit): ");
                        if (int.TryParse(Console.ReadLine(), out int extraNumber))
                        {
                            if (extraNumber >= 1 && extraNumber <= _extras.Count)
                            {
                                Food selectedExtra = _extras[extraNumber - 1];
                                if (selectedExtra.GetName().Contains("Custom Dish"))
                                {
                                    Console.Write("Enter the custom dish: ");
                                    string customDish = Console.ReadLine();
                                    selectedExtra = new CustomFood(customDish, selectedExtra.GetPrice());
                                }
                                AddFoodToOrder(selectedExtra);
                                Console.WriteLine(selectedExtra.GetName() + " added to the order.");
                            }
                            else if (extraNumber == 0)
                            {
                                addMoreExtras = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid extra number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid extra number.");
                        }
                    }
                    break;
                case "5":
                    SaveOrderToFile();
                    break;
                case "6":
                    LoadOrderFromFile();
                    break;
                case "7":
                    _paymentMethod = SelectPaymentMethod();
                    break;
                case "8":
                    if (!string.IsNullOrEmpty(_paymentMethod))
                    {
                        Console.WriteLine("Please proceed to payment.");
                        ProcessPayment();
                    }
                    else
                    {
                        Console.WriteLine("Please select a payment method first.");
                    }
                    break;
                case "9":
                    _exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public void SetExit(bool value)
    {
        _exit = value;
    }

    private string SelectPaymentMethod()
    {
        Console.WriteLine("Payment Method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. Debit Card");
        Console.WriteLine("3. Cash");
        Console.Write("Enter your choice: ");
        string paymentMethodChoice = Console.ReadLine();
        string paymentMethod = "";

        switch (paymentMethodChoice)
        {
            case "1":
                paymentMethod = "credit card";
                break;
            case "2":
                paymentMethod = "debit card";
                break;
            case "3":
                paymentMethod = "cash";
                break;
            default:
                Console.WriteLine("Invalid payment method. Please choose a valid payment method.");
                break;
        }

        return paymentMethod;
    }

    private void ProcessPayment()
    {
        if (_currentOrder.GetTotalAmount() == 0)
        {
            Console.WriteLine("There are no items in the order. Please add items before making a payment.");
            return;
        }

        if (_payment.ProcessPayment(_paymentMethod))
        {
            Console.WriteLine("Thank you for your purchase!");

            // Reset the order and payment method
            _currentOrder.ResetOrder();
            _paymentMethod = "";
        }
    }

    private void DisplayTotalAmount()
    {
        double totalAmount = _currentOrder.GetTotalAmount();
        Console.WriteLine("Total Amount: $" + totalAmount);

        if (_paymentMethod == "debit card" && totalAmount > 0)
        {
            double discountedAmount = totalAmount * 0.8;
            Console.WriteLine("You have a 20% discount.");
            Console.WriteLine("Discounted Amount: $" + discountedAmount);
        }
    }
}
