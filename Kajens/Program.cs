
using System.Globalization;

namespace Kajens;

public class Program
{
    
    static void Main()
    {
        Rentalsysteme systeme = new Rentalsysteme();

        bool run = true;

        while (run)
        {
            
            Console.WriteLine("=== Welcome to Kajens Cykeluthyrning ===");
            Console.WriteLine("1. Show vehicles");
            Console.WriteLine("2. Register customer");
            Console.WriteLine("3. Rent out");
            Console.WriteLine("4. Return vehicles");
            Console.WriteLine("5. Charge");
            Console.WriteLine("6. Exit");

            Console.Write("Enter: ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    systeme.ShowVehicles();
                    break;

                case 2:
                    systeme.RegisterCustomer();
                    break;

                case 3:
                    systeme.RentOutVehicles();
                    break;

                case 4:
                    systeme.ReturnVehicle();
                    break;

                case 5:
                    systeme.ChargeVehicle();
                    break;

                case 6:
                    run = false;
                    break;

                default:
                    Console.WriteLine("invalid input choose betwwen 1 and 6.");
                    break;
            }

            Console.WriteLine();
        }
    }

}
