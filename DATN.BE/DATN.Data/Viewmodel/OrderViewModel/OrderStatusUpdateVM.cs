using DATN.InfrastructureLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Data.Viewmodel.OrderViewModel
{
    public class OrderStatusUpdateVM
    {
        public int Id { get; set; }
        public DeliveryStatus TransacStatus { get; set; }
    }
}
