//klassen representerar en pågående uthyrning. Den kopplar ihop ett fordon med en kund som hyr det och beräknar grundpriset beroende av antal timmar

namespace Kajens;

public class Rental
{
    public Customer Customer { get; }
    public Vehicle Vehicle { get; }
    public int Hoursnbr { get; }

    public double Basepris { get; }
    public double Discount { get; }
    public double Topay { get; }

    public Rental(Customer customer, Vehicle vehicle, int hours)
    {

        Customer = customer;
        Vehicle = vehicle;
        Hoursnbr = hours;

        Basepris = vehicle.TotalPrice(hours);

        if (customer.IsMember)
        {
            Discount = Basepris * 0.10;
        }
        else
        {
            Discount = 0;
        }

        Topay = Basepris - Discount;
    }
}
