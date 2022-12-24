using System.ComponentModel.DataAnnotations;

namespace MvcWebProje.Models
{
    public class yemek
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [StringLength(25)]
        public string yemekIsmi { get; set; }
        [Required]
        [StringLength(40)]
        public string yemeginKategorisi { get; set; }

        [Required]
        [StringLength(150)]
        public string YemekTarifi { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
