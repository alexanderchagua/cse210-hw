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