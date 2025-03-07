namespace CarApp.Models.Barbershop
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid ClientId { get; set; }
        public Guid BarberId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Service { get; set; }
    }
}
