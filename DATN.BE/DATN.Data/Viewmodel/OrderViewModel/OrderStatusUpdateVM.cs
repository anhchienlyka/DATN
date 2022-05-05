using DATN.InfrastructureLayer.Enums;

namespace DATN.Data.Viewmodel.OrderViewModel
{
    public class OrderStatusUpdateVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DeliveryStatus TransacStatus { get; set; }
    }
}