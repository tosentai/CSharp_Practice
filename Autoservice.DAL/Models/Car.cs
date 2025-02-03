using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.DAL.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(15)]
        public string LicensePlate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
