using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDB.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        public required DateTime CreatedDate { get; set;} = DateTime.Now;
        public DateTime UpdatedDate { get; set;}
        public string LogoUrl { get; set; } = string.Empty;
        public required string Status { get; set; }

        public required int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public required Address Address { get; set; }
    }
}
