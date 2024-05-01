using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDB.Models
{
    [Table("Address")]
    public class Address
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HomeNumber { get; set; }
        public string Apartment { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
    }
}
