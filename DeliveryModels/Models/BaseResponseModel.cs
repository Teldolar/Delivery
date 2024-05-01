namespace DeliveryModels.Models
{
    public class BaseResponseModel
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Body { get; set; }
    }
}
