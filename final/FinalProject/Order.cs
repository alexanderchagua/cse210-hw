class Order
{
    private List<Food> _foodItems;
    private double _totalAmount;
    private int _paymentCount;
    private Bonus _bonus;

    public Order()
    {
        _foodItems = new List<Food>();
        _totalAmount = 0;
        _paymentCount = 0;
        _bonus = new Bonus();
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

    public void SaveOrderToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Food food in _foodItems)
            {
                writer.WriteLine(food.GetName() + "," + food.GetPrice());
            }
            writer.WriteLine("Total Amount: $" + _totalAmount);
        }
        Console.WriteLine("Order saved to " + filename);
    }

    public void LoadOrderFromFile(string filename)
    {
        _foodItems.Clear();
        _totalAmount = 0;

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Total Amount: $"))
                {
                    double.TryParse(line.Substring(15), out _totalAmount);
                }
                else
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        double price;
                        double.TryParse(parts[1], out price);
                        Food food = new MenuFood(name, price);
                        _foodItems.Add(food);
                    }
                }
            }
        }

        Console.WriteLine("Order loaded from " + filename);
    }

    public bool PayOrder(string paymentMethod, double amountPaid)
    {
        double discountedAmount = _totalAmount;
        if (_paymentCount >= 5)
        {
            discountedAmount = _bonus.ApplyDiscount(_totalAmount);
            Console.WriteLine("Congratulations! You have a 50% discount bonus for your next purchase.");
        }

        if (paymentMethod == "debit card")
        {
            discountedAmount = _bonus.ApplyDebitCardDiscount(_totalAmount);
            Console.WriteLine("You have a 20% discount for paying with a debit card.");
        }

        Console.WriteLine("Total Amount: $" + _totalAmount);
        Console.WriteLine("Amount paid: $" + discountedAmount);

        if (paymentMethod == "cash")
        {
            if (amountPaid > discountedAmount)
            {
                double change = amountPaid - discountedAmount;
                Console.WriteLine("Your change is $" + change);
                
                _paymentCount++;
                CheckBonusEligibility();
                return true;
            }
            else if (amountPaid == discountedAmount)
            {
                Console.WriteLine("Thank you for your purchase!");
                _paymentCount++;
                CheckBonusEligibility();
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient payment. Please provide an amount equal to or greater than $" + discountedAmount);
                return false;
            }
        }
        else
        {
            if (amountPaid >= discountedAmount)
            {
                Console.WriteLine("Thank you for your purchase!");
                _paymentCount++;
                CheckBonusEligibility();
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient payment. Please provide an amount equal to or greater than $" + discountedAmount);
                return false;
            }
        }
    }

    private void CheckBonusEligibility()
    {
        if (!_bonus.HasBonus() && _paymentCount >= 5)
        {
            _bonus.SetBonus(true);
            Console.WriteLine("Congratulations! You have a 50% discount bonus for your next purchase.");
        }
    }

    public void ResetOrder()
    {
        _foodItems.Clear();
        _totalAmount = 0;
        _paymentCount = 0;
        _bonus.ResetBonus();
    }
}
