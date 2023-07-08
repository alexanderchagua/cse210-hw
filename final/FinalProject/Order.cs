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