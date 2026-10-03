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
            foreach (var a in appointment)
            {
                a.PrintInfo();
            }
        }

        public void PrintStatistics()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("Nema podataka za statistiku");
                return ;
            }

            Console.WriteLine($"Ukupan broj zakazanih termina: {appointments.Count}");

            Console.WriteLine($"Ukupan prihod: {appointments.Sum(a => a.Service.Price)} RSD");

            var najtrazeniji = appointments
                .GroupBy(a => a.Service.Name)
                .OrderByDescending(g => g.Count())
                .First();

            Console.WriteLine($"Najtrazenija usluga je {najtrazeniji.Key} zakazana {najtrazeniji.Count()} puta");
        }
    }
}
