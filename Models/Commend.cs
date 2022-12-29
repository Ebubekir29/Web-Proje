using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebProje.Models
{
    public class Commend
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string text { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string yemekId { get; set; }
    }
}
