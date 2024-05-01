using DeliveryDB;

namespace CustomerService.Managers
{
    public class BaseDbManager
    {
        internal DeliveryContext _deliveryContext;

        public BaseDbManager(DeliveryContext deliveryContext) 
        {
            _deliveryContext = deliveryContext;
        }
    }
}
