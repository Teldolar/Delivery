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
using DeliveryModels.Models.RestaurantModels;

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

        public RestaurantInfo ConvertToRestaurantInfo()
        {
            return new RestaurantInfo()
            {
                Name = Name,
                Description = Description,
                LogoUrl = LogoUrl,
                Status = Status
            };
        }
    }

    public static class RestaurantExtensions
    {
        public static List<RestaurantCard> ConvetToRestaurantCards(this List<Restaurant> restaurants)
        {
            List<RestaurantCard> cards = [];
            foreach (var item in restaurants)
            {
                cards.Add(new RestaurantCard()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                });
            }
            return cards;
        }

        public static List<Restaurant> ConvetToRestaurant(this List<RestaurantTag> restaurantTags)
        {
            List<Restaurant> restaurants = [];
            foreach (var item in restaurantTags)
            {
                restaurants.Add(item.Restaurant);
            }
            return restaurants;
        }
    }
}
