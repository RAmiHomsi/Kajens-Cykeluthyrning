namespace Kajens;

public class Bicycle : Vehicle
{
    public Bicycle(int number)
    {
        Number = number;
        Hourprice = 40;
    }

    public override string TheType()
    {
        return "bicycle";
    }
}