using DeliveryDB;
using DeliveryDB.Models;
using DeliveryModels.Managers;
using DeliveryModels.Models.RestaurantModels;
using Microsoft.EntityFrameworkCore;

namespace DeliveryModels.DbManagers.RestaurantManagers
{
    public class RestaurantDbManager(DeliveryContext deliveryContext) : BaseDbManager(deliveryContext)
    {
        public List<Restaurant>? GetRestaurantsByFilter(int filter)
        {
            return _deliveryContext.RestaurantTags.Where(p => filter == p.TagId)
                                                  .Include(p => p.Restaurant)
                                                  .ToList()?
                                                  .ConvetToRestaurant();
        }

        public Restaurant? GetRestaurantById(int restaurantId)
        {
            return _deliveryContext.Restaurants.FirstOrDefault(p => p.Id == restaurantId);
        }
    }
}
