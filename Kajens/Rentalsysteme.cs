namespace Kajens;

public class Rentalsysteme
{
    public List<Vehicle> vehicles = new List<Vehicle>();
    public List<Customer> customers = new List<Customer>();
    public List<Rental> activeRentals = new List<Rental>();

    public Rentalsysteme()
    {
        // Fordon som finns när programmet startar.
        vehicles.Add(new Bicycle(1));
        vehicles.Add(new Bicycle(2));
        vehicles.Add(new Elbike(3, 80));
        vehicles.Add(new Elbike(4, 25));
    }
    public void RegisterCustomer()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        if (name == "")
        {
            Console.WriteLine("please enter a name");
            return;
        }
        // kollar om samma kund registreras flera gånger.
        bool alreadyExists = customers.Any(c => c.Name.Equals(name));

         if (alreadyExists)
        {
            Console.WriteLine("You already registered.");
            return;
        }

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        if (age < 0)
        {
            Console.WriteLine("Your age can not be negative");
            return;
        }

        Console.Write("Are you a member (Y/N): ");
        string answer = Console.ReadLine().ToLower();

        bool isMember;

        if (answer == "y")
        {
            isMember = true;
        }
        else if (answer == "n")
        {
            isMember = false;
        }
        else
        {
            Console.WriteLine("Please answer with Y or N.");
            return;
        }

        customers.Add(new Customer(name, age, isMember));

        Console.WriteLine($"{name} is registered now.");
    }


    public Vehicle FindVehicle(int number)
    {
        return vehicles.FirstOrDefault(f => f.Number == number);
    }

    public void RentOutVehicles()
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("Register a customer first.");
            return;
        }

        Console.Write("Customer: ");
        string name = Console.ReadLine();

        Customer customer = customers.FirstOrDefault(c => c.Name.Equals(name));

        if (customer == null)
        {
            Console.WriteLine("The customer does not exist.");
            return;
        }

        Console.Write("Vehicle Number: ");
        int number = int.Parse(Console.ReadLine());

        Vehicle vehicle = vehicles.FirstOrDefault(v => v.Number == number);

        if (vehicle == null)
        {
            Console.WriteLine("The Vehicle does not exist.");
            return;
        }

        if (vehicle.Rented)
        {
            Console.WriteLine("The vehicle is already rented.");
            return;
        }

        if (vehicle.TheType() == "bicycle" && customer.Age < 15)
        {
            Console.WriteLine("The customer must be at least 15 years old for a bike.");

            return;
        }
        
        if (vehicle.TheType() == "electric bicycle")
        {
            if (customer.Age < 18)
            {
                Console.WriteLine("The customer must be at least 18 years old for an electric bike.");
                return;
            }

            Elbike elbike = (Elbike)vehicle;

            if (elbike.BatteryLevel < 30)
            {
                Console.WriteLine(
                $"Elbike {elbike.Number} has too little battery " +
                $"({elbike.BatteryLevel} %). Charge it first.");
                return;
            }
        }


        Console.Write("Number of hours: ");
        int hours = int.Parse(Console.ReadLine());

        if (hours <= 0)
        {
            Console.WriteLine("Number of hours must be greater than zero.");
            return;
        }


        // Skapa och spara uthyrningen.
        Rental rental = new Rental(customer, vehicle, hours);

        activeRentals.Add(rental);
        vehicle.RentOut();

        Console.WriteLine($"{customer.Name} rent {vehicle.TheType()} " +
            $"{vehicle.Number} for {hours} hours.");

    }

    public void ReturnVehicle()
    {
        Console.Write("Vehicle Number: ");

        int number = int.Parse(Console.ReadLine());

        Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Number == number);

        if (vehicle == null)
        {
            Console.WriteLine("The Vehicle does not exist.");
            return;
        }

        Rental rental = activeRentals.FirstOrDefault(r => r.Vehicle.Number == number);

        if (rental == null)
        {
            Console.WriteLine("The vehicle is not rented.");
            return;
        }

        Vehicle theVehicle = rental.Vehicle;

        if (theVehicle.TheType() == "electric bicycle")
        {
            Elbike elbike = (Elbike)vehicle;
            elbike.Consumption(rental.Hoursnbr);
        }

        // Markera fordonet som ledigt.
        theVehicle.ReturnBack();

        // Ta bort uthyrningen från listan.
         activeRentals.Remove(rental);
    }

    public void ChargeVehicle()
    {

        Console.Write("Vehicle Number: ");

        int number = int.Parse(Console.ReadLine());

        Vehicle? vehicle = vehicles.FirstOrDefault(v => v.Number == number);

        if (vehicle == null)
        {
            Console.WriteLine("The Vehicle does not exist.");
            return;
        }


        if (vehicle.TheType() != "electric bicycle")
        {
            Console.WriteLine("Only electric bikes can be charged.");
            return;
        }

        if (vehicle.Rented)
        {
            Console.WriteLine("A rented electric bicycle cannot be charged");
            return;
        }

         Elbike elbike = (Elbike)vehicle;
         elbike.Charge();

        Console.WriteLine( $"Elbike {elbike.Number} is now full charged 100%.");

        return;
    }

    public void VisaFordon()
    {
        Console.WriteLine();
        Console.WriteLine("Nr  Type       Status    Battery");

        foreach (Vehicle vehicle in vehicles)
        {
            string status =
                vehicle.Rented ? "rented" : "free";

            string battery = "-";

            if (vehicle.TheType() == "electric bicycle")
            {
                Elbike elbike = (Elbike)vehicle;
                battery = $"{elbike.BatteryLevel} %";
            }

            Console.WriteLine(
                    $"{vehicle.Number} {vehicle.TheType()} {status} {battery}");

        }
    }
}