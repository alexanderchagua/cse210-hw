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
                    DisplayMenu();
                    Console.Write("Enter the number of the food item: ");
                    if (int.TryParse(Console.ReadLine(), out int foodNumber) && foodNumber >= 1 && foodNumber <= _menu.Count)
                    {
                        Food selectedFood = _menu[foodNumber - 1];
                        AddFoodToOrder(selectedFood);
                        Console.WriteLine(selectedFood.GetName() + " added to the order.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid food number.");
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
                    
                    break;
                case "5":
                    
                    break;
                case "6":
                    
                    break;
                case "7":
                    
                    break;
                case "8":
                    
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
