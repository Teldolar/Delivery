using DeliveryModels.DbManagers.RestaurantManagers;
using DeliveryModels.Models.RestaurantModels;
using Grpc.Core;

namespace CustomerService.Services;

public class RestaurantService(ILogger<RestaurantService> logger, RestaurantDbManager restaurantDbManager) : Restaurant.RestaurantBase
{
    private readonly ILogger<RestaurantService> _logger = logger;
    private readonly RestaurantDbManager _restaurantDbManager = restaurantDbManager;

    public override Task<GetRestaurantByFilterResponse> GetRestaurantByFilter(GetRestaurantByFilterRequest request, ServerCallContext context)
    {
        List<DeliveryDB.Models.Restaurant> cards = _restaurantDbManager.GetRestaurantsByFilter(request.TagId);
        GetRestaurantByFilterResponse response = new();

        foreach (var item in cards)
        {
            response.RestaurantCard.Add(new RestaurantCard()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            });
        }

        return Task.FromResult(response);
    }

    public override Task<GetRestaurantByIdResponse> GetRestaurantById(GetRestaurantByIdRequest request, ServerCallContext context)
    {
        DeliveryDB.Models.Restaurant restaurant = _restaurantDbManager.GetRestaurantById(request.Id);

        return Task.FromResult(new GetRestaurantByIdResponse()
        {
            Name = restaurant?.Name,
            Description = restaurant?.Description,
            LogoUrl = restaurant?.LogoUrl,
            Status = restaurant?.Status
        });
    }
}
