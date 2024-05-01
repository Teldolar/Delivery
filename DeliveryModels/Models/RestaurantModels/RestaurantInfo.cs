namespace DeliveryModels.Models.RestaurantModels
{
    public class RestaurantInfo
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string Status { get; set; }

    }
}
