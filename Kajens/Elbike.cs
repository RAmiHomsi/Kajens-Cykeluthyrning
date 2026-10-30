
namespace Kajens;

public class Elbike : Vehicle
{
    public int BatteryLevel { get; private set; }

    public Elbike(int number, int batteryLevel)
    {
        Number = number;
        Hourprice = 70;
        

        if (batteryLevel < 0 || batteryLevel > 100)
        {
           
            Console.WriteLine( "Battery must be between 0 och 100%");
        }

        BatteryLevel = batteryLevel;
    }

    public override string TheType()
    {
        return "E-bike";
    }

    public void Charge()
    {
        BatteryLevel = 100;
    }

    public void Consumption(int hours)
    {
        int consume = hours * 10;

        BatteryLevel = Math.Max(0, BatteryLevel - consume);
    }
}
