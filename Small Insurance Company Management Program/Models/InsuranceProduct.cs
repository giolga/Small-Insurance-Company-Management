using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Small_Insurance_Company_Management_Program.Models
{
    public class InsuranceProduct
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string InsuranceName { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int TypeId { get; set; }
        [JsonIgnore]
        public Typee Type { get; set; }
        public int PackageId { get; set; }
        [JsonIgnore]
        public Package Package { get; set; }

        [MinLength(5)]
        public string? Description { get; set; }
        public int AuthorizedUserId { get; set; }
        [JsonIgnore]
        public AuthorizedUser AuthorizedUser { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
