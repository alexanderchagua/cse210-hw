class Bonus
{
    private bool _hasBonus;

    public Bonus()
    {
        _hasBonus = false;
    }

    public void SetBonus(bool value)
    {
        _hasBonus = value;
    }

    public bool HasBonus()
    {
        return _hasBonus;
    }

    public double ApplyDiscount(double totalAmount)
    {
        return totalAmount * 0.5;
    }

    public double ApplyDebitCardDiscount(double totalAmount)
    {
        return totalAmount * 0.8;
    }

    public void ResetBonus()
    {
        _hasBonus = false;
    }
}
