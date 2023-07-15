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