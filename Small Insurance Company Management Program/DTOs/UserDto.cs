using System.ComponentModel.DataAnnotations;

namespace Small_Insurance_Company_Management_Program.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string InsuranceProductName { get; set; }
    }
}
