using System.ComponentModel.DataAnnotations;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class Typee
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
