using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siparis.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? OrderNumber { get; set; } = string.Empty;
        public string? OrderImageUrl { get; set; } = string.Empty;
        public decimal OrderTotalPrice { get; set; }
        public decimal OrderDownPayment { get; set; }
        public decimal OrderRemainingPayment { get; set; }
        public string? OrderDescription { get; set; } = string.Empty;
        public string? CustomerName { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? OrderStatus { get; set; } = string.Empty;

    }
}
