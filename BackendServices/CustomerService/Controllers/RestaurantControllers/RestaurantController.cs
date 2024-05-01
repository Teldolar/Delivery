using DeliveryDB.Models;
using DeliveryModels.DbManagers.RestaurantManagers;
using DeliveryModels.Models;
using DeliveryModels.Models.RestaurantModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers.RestaurantControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController(RestaurantDbManager restaurantDbManager) : BaseController
    {
        private readonly RestaurantDbManager _restaurantDbManager = restaurantDbManager;

        [Route("GetRestaurantsByFilter")]
        [HttpPost]
        public ActionResult<BaseResponseModel> GetRestaurantsByFilter(RestaurantFilter restaurantFilter)
        {
            try
            {
                List<RestaurantCard> cards = _restaurantDbManager.GetRestaurantsByFilter(restaurantFilter)?.ConvetToRestaurantCards();

                return GenerateJson(cards, 0, "");
            }
            catch (Exception ex)
            {
                return GenerateExceptionJson(-1, ex.Message);
            }
        }

        [Route("GetRestaurantById")]
        [HttpGet]
        public ActionResult<BaseResponseModel> GetRestaurantById(int restaurantId)
        {
            try
            {
                RestaurantInfo restaurantInfo = _restaurantDbManager.GetRestaurantById(restaurantId)?.ConvertToRestaurantInfo();

                return GenerateJson(restaurantInfo, 0, "");
            }
            catch (Exception ex)
            {
                return GenerateExceptionJson(-1, ex.Message);
            }
        }
    }
}
