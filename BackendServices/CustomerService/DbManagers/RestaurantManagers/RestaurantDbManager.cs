using CustomerService.Managers;
using CustomerService.Models.RestaurantModels;
using DeliveryDB;
using DeliveryDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DbManagers.RestaurantManagers
{
    public class RestaurantDbManager : BaseDbManager
    {
        public RestaurantDbManager(DeliveryContext deliveryContext) : base(deliveryContext)
        {

        }

        public List<Restaurant> GetRestaurantsByFilter(RestaurantFilter filter)
        {
            List<RestaurantTag> restaurantsIds = _deliveryContext.RestaurantTags.Where(p => filter.TagIds.Contains(p.TagId))
                                                                                .Include(p => p.Restaurant)
                                                                                .ToList();
            List<Restaurant> restaurants = [];
            foreach (var item in restaurantsIds)
            {
                restaurants.Add(item.Restaurant);
            }
            return restaurants;
        }
    }
}
