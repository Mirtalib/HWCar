namespace WebApplication3.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        public int EngineSize { get; set; }
    }
}
