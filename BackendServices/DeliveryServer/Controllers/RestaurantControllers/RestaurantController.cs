using DeliveryModels.DbManagers.RestaurantManagers;
using DeliveryModels.Models;
using DeliveryModels.Models.RestaurantModels;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using DeliveryServer.Managers;
using DeliveryServer;

namespace CustomerService.Controllers.RestaurantControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController(CustomerManager customerManager) : BaseController
    {
        public readonly CustomerManager _customerManager = customerManager;

        [Route("GetRestaurantsByFilter")]
        [HttpPost]
        public ActionResult<BaseResponseModel> GetRestaurantsByFilter(int tagId)
        {
            try
            {
                var cards = _customerManager.GetRestaurantsByFilter(tagId);

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
                RestaurantInfo restaurantInfo = _customerManager.GetRestaurantById(restaurantId);

                return GenerateJson(restaurantInfo, 0, "");
            }
            catch (Exception ex)
            {
                return GenerateExceptionJson(-1, ex.Message);
            }
        }
    }
}
