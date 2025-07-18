using System.ComponentModel.DataAnnotations;

namespace EFCrud.Models
{
    public class ClientDto
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; } = "";
        [Required,EmailAddress(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = "";
        [Phone]
        public string Contact { get; set; } = "";   
    }
}
