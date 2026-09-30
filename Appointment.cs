namespace SalonBooking
{
    internal class Appointment
    {
        public string ClientName {  get; private set; }
        public Service Service { get; private set; }
        public DateTime DateTime { get; private set; }

        public Appointment (string clientName, Service service, DateTime dateTime)
        {
            ClientName = clientName;
            Service = service;
            DateTime = dateTime;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{ClientName} - {Service.Name} - {DateTime}");
        }
    }
}
