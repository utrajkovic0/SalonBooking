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

        public void CancelAppointment(string clientName, DateTime dateTime)
        {
            Appointment appointment = appointments.FirstOrDefault(a => a.DateTime == dateTime && a.ClientName == clientName);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Rezervacija ne postoji!");
            }
            appointments.Remove(appointment);
        }

        public void ListAppointments()
        {
            if(appointments.Count == 0)
            {
                Console.WriteLine("Nema zakazanih termina!");
                return;
            }
            foreach(var appointment in appointments)
            {
                appointment.PrintInfo();
            }
        }

        public void ListAppointmentsByDate(DateTime date)
        {
            List<Appointment> appointment = appointments.Where(a => a.DateTime.Date ==  date.Date).ToList();
            if (appointment.Count == 0)
            {
                Console.WriteLine($"Nema zakazanih termina za datum {date}");
                return;
            }
            Console.WriteLine($"Termini za dan {date:dd.MM.yyyy}");
            foreach (var a in appointment)
            {
                a.PrintInfo();
            }
        }
    }
}
