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