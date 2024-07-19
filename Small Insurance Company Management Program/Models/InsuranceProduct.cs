using System.ComponentModel.DataAnnotations;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class InsuranceProduct
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int TypeId { get; set; }
        public Typee Type { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        [MinLength(5)]
        public string Description { get; set; }

        public int AuthorizedUserId { get; set; }
        public AuthorizedUser AuthorizedUser { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
