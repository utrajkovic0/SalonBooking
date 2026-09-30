namespace SalonBooking
{
    internal class Service
    {
        public string Name {  get; private set; }
        public int DurationMinutes {  get; private set; }
        public double Price {  get; private set; }

        public Service(string name, int durationMinutes, double price)
        {
            Name = name;
            DurationMinutes = durationMinutes;
            Price = price;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} - {DurationMinutes} Minuta - {Price} RSD");
        }
    }
}
