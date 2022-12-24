using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebProje.Models
{
    [Table("iletisim")]
    public class iletisim
    {
        public int id { get; set; }
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        [Required]
        [StringLength(30)]
        public string? Surname { get; set; }
        [Required]
        [StringLength(30)]
        public string? Email { get; set; }
        [Required]
        [StringLength(150)]
        public string? Description { get; set; }
    }
}
