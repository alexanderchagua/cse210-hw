class Payment
{
    private Order _currentOrder;
    private Restaurant _restaurant;

    public Payment(Order currentOrder, Restaurant restaurant)
    {
        _currentOrder = currentOrder;
        _restaurant = restaurant;
    }

    public bool ProcessPayment(string paymentMethod)
    {
        if (paymentMethod != "")
        {
            double amountPaid = 0;
            if (paymentMethod == "cash")
            {
                Console.Write("Enter the amount to pay: ");
                double.TryParse(Console.ReadLine(), out amountPaid);
            }
            else
            {
                amountPaid = _currentOrder.GetTotalAmount();
            }

            if (_currentOrder.PayOrder(paymentMethod, amountPaid))
            {
                _restaurant.SetExit(false);
                return true;
            }
        }

        return false;
    }
}