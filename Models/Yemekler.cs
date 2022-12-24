using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebProje.Models
{
    [Table("Yemekler")]
    public class Yemekler
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
