using DeliveryDB;

namespace DeliveryModels.Managers
{
    public class BaseDbManager(DeliveryContext deliveryContext)
    {
        internal DeliveryContext _deliveryContext = deliveryContext;
    }
}
