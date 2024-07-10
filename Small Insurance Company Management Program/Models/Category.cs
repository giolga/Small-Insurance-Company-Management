using System.ComponentModel.DataAnnotations;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
