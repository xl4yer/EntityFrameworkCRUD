using Microsoft.EntityFrameworkCore;

namespace EFCrud.Models
{
    [Index("Email", IsUnique = true)]
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
