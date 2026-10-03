using SalonBooking;

BookingSystem booking = new BookingSystem();
booking.AddService(new Service("Sisanje", 60, 1200));
booking.AddService(new Service("Brijanje", 30, 800));
void HandleBooking()
{
    try
    {
        Console.Write("Vase ime: ");
        string clientName = Console.ReadLine();

        Console.Write("Koju uslugu zelite: ");
        string serviceName = Console.ReadLine();

        Console.Write("Datum i vreme (npr. 2027-06-15 14:30): ");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());

        booking.BookAppointment(clientName, serviceName, dateTime);
        Console.WriteLine("Termin uspesno zakazan!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Greska! {ex.Message}");
    }
}

void HandleCancelation()
{
    try
    {
        Console.Write("Vase ime: ");
        string clientName = Console.ReadLine();

        Console.Write("Datum i vreme (npr. 2027-06-15 14:30): ");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());

        booking.CancelAppointment(clientName, dateTime);
        Console.WriteLine("Termin uspesno otkazan!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Greska! {ex.Message}");
    }
}
void HandleAppointmentsByDate()
{
    try
    {
        Console.Write("Datum (npr. 2027-06-15): ");
        DateTime dateTime = DateTime.Parse(Console.ReadLine());
        Console.WriteLine($"Termini za datum {dateTime.Date:dd.MM.yyyy}: ");
        booking.ListAppointmentsByDate(dateTime);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Greska! {ex.Message}");
    }
}

bool radi = true;
while (radi)
{
    Console.WriteLine("\n=== SALON BOOKING ===");
    Console.WriteLine("1. Prikazi usluge");
    Console.WriteLine("2. Zakazi termin");
    Console.WriteLine("3. Otkazi termin");
    Console.WriteLine("4. Prikazi sve termine");
    Console.WriteLine("5. Prikazi termine za odredjeni datum");
    Console.WriteLine("6. Statistika");
    Console.WriteLine("0. Izlaz");
    Console.Write("Izaberi opciju: ");

    string izbor = Console.ReadLine();

    switch (izbor)
    {
        case ("1"): 
            booking.ListServices();
            break;
        case ("2"):
            HandleBooking();
            break;
        case ("3"):
            HandleCancelation();
            break;
        case("4"):
            booking.ListAppointments();
            break;
        case("5"):
            HandleAppointmentsByDate();
            break;
        case("6"):
            booking.PrintStatistics(); 
            break;
        case ("0"):
            radi = false;
            break;
        default:
            Console.WriteLine("Nepoznata opcija!");
            break;
    }
}