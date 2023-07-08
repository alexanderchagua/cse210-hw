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