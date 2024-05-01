using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDB.Models
{
    [Table("RestaurantTag")]
    public class RestaurantTag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int RestaurantId { get; set; }
        public required int TagId { get; set; }


        [ForeignKey("RestaurantId")]
        public required Restaurant Restaurant { get; set; }

        [ForeignKey("TagId")]
        public required Tag Tag { get; set; }
    }
}
