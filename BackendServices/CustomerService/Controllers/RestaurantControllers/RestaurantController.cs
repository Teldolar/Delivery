using CustomerService.DbManagers.RestaurantManagers;
using CustomerService.Models;
using CustomerService.Models.RestaurantModels;
using DeliveryDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerService.Controllers.RestaurantControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : BaseController
    {
        private RestaurantDbManager _restaurantDbManager;
        public RestaurantController(RestaurantDbManager restaurantDbManager) 
        {
            _restaurantDbManager = restaurantDbManager;
        }

        [HttpGet]
        public ActionResult<BaseResponseModel> GetRestaurantsByFilter()
        {
            try
            {
                RestaurantFilter restaurantFilter = new RestaurantFilter()
                {
                    TagIds = [],
                };
                restaurantFilter.TagIds.Add(2);
                List<Restaurant> restaurants = _restaurantDbManager.GetRestaurantsByFilter(restaurantFilter);

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

                return GenerateJson(cards, 0, "");
            }
            catch (Exception ex)
            {
                return GenerateExceptionJson(-1, ex.Message);
            }
        }
    }
}
