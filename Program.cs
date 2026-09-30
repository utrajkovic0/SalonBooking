using SalonBooking;

BookingSystem booking = new BookingSystem();

Service hair = new Service("Sisanje", 60, 1200);
Service beard = new Service("Brijanje", 60, 800);

booking.AddService(hair);
booking.AddService(beard);

booking.ListServices();

booking.BookAppointment("Uros", "Sisanje", new DateTime(2027, 6, 15, 10, 0, 0));

try
{
    booking.BookAppointment("Filip", "Sisanje", new DateTime(2027, 6, 15, 10, 0, 0));
}
catch(Exception ex)
{
    Console.WriteLine($"Greska! {ex.Message}");
}
try
{
    booking.BookAppointment("Filip", "Masaza", new DateTime(2027, 6, 15, 10, 0, 0));
}
catch (Exception ex)
{
    Console.WriteLine($"Greska! {ex.Message}");
}
try
{
    booking.BookAppointment("Filip", "Brijanje", new DateTime(2020, 1, 1, 10, 0, 0));
}
catch (Exception ex)
{
    Console.WriteLine($"Greska! {ex.Message}");
}