namespace SalonBooking
{
    internal class BookingSystem
    {
        private List<Service> services;
        private List<Appointment> appointments;

        public BookingSystem()
        {
            services = new();
            appointments = new();
        }

        public void AddService(Service service)
        {
            if (services.Any(s => s.Name == service.Name))
            {
                throw new ArgumentException("Usluga vec postoji!");
            }
            services.Add(service);
        }

        public void ListServices()
        {
            foreach (Service service in services)
            {
                service.PrintInfo();
            }
        }

        public void BookAppointment(string clientName, string serviceName, DateTime dateTime)
        {
            Service service = services.FirstOrDefault(s => s.Name == serviceName);
            if (service == null)
            {
                throw new KeyNotFoundException("Usluga ne postoji");
            }

            if (dateTime < DateTime.Now)
            {
                throw new ArgumentException("Termin ne moze biti u proslosti");
            }

            if (appointments.Any(a => a.DateTime == dateTime))
            {
                throw new InvalidOperationException("Termin je vec zauzet");
            }

            Appointment newAppointment = new Appointment(clientName,service, dateTime);
            appointments.Add(newAppointment);
        }
    }
}
