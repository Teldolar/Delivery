using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDB.Models
{

    [Table("MenuItem")]
    public class MenuItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public required double Price { get; set; }

        [Required]
        public required int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public required Restaurant Restaurant { get; set; }
    }
}
