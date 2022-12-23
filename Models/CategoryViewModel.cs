using System.ComponentModel.DataAnnotations;

namespace MvcWebProje.Models
{
    public class CategoryViewModel
    {

    }
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = "Name is required."), StringLength(25, ErrorMessage = "Username can be max 25 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required."), StringLength(75, ErrorMessage = "Description can be max 25 characters.")]
        public string Description { get; set; }
    }
}
