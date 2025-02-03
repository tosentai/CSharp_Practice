using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.DAL.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
