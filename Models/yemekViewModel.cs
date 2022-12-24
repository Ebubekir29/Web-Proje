namespace MvcWebProje.Models
{
    public class yemekViewModel
    {
        public Guid id { get; set; }
        public string? yemekIsmi { get; set; }
        public string? yemeginKategorisi { get; set; }
        public string? YemekTarifi { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
