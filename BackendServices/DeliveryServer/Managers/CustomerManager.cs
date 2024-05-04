using DeliveryModels.DbManagers.RestaurantManagers;
using DeliveryModels.Models.RestaurantModels;
using DeliveryModels.Models;
using Microsoft.AspNetCore.Mvc;
using static DeliveryServer.Restaurant;
using Grpc.Net.Client;
using System.Xml.Linq;
using Grpc.Core;

namespace DeliveryServer.Managers
{
    public class CustomerManager(GrpcChannel grpcChannel)
    {
        private readonly RestaurantClient _restaurantClient = new(grpcChannel);

        public List<RestaurantCard> GetRestaurantsByFilter(int tagId)
        {
            GetRestaurantByFilterResponse response = _restaurantClient.GetRestaurantByFilter(new GetRestaurantByFilterRequest { TagId = tagId });

            List<RestaurantCard> restaurantCards = [];

            foreach (RestaurantCard card in response.RestaurantCard)
            {
                restaurantCards.Add(new RestaurantCard()
                {
                    Id = card.Id,
                    Name = card.Name,
                    Description = card.Description
                });
            }

            return restaurantCards;
        }

        public RestaurantInfo GetRestaurantById(int id)
        {
            GetRestaurantByIdResponse serverData = _restaurantClient.GetRestaurantById(new GetRestaurantByIdRequest { Id = id });

            return new RestaurantInfo()
            {
                Name = serverData.Name,
                Description = serverData.Description,
                LogoUrl = serverData.LogoUrl,
                Status = serverData.Status
            };
        }
    }
}
