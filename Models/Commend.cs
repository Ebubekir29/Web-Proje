using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWebProje.Models
{
    public class Commend
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Yorum { get; set; }

        public string Userid { get; set; }

        public string Username { get; set; }

        public string yemekid { get; set; }
    }
}
