
namespace Kajens;

public abstract class Vehicle
{
    public int Number { get; protected set; }
    public double Hourprice { get; protected set; }
    public bool Rented { get; private set; }

    protected Vehicle()
    {
        Rented  = false;
    }

    public void RentOut()
    {
        Rented = true;
    }

    public void ReturnBack()
    {
        Rented = false;
    }

    public double TotalPrice(int hours)
    {
        return Hourprice * hours;
    }

    public abstract string TheType();
}
