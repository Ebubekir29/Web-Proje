using System.ComponentModel.DataAnnotations;

namespace MvcWebProje.Models
{
    public class iletisimViewModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }
    }
}
