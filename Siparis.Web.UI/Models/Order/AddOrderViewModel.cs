using System.ComponentModel.DataAnnotations;

namespace Siparis.Web.UI.Models.Order
{
    public class AddOrderViewModel
    {
        public string? OrderImageUrl { get; set; }
        [DataType(DataType.Currency)]
        public decimal OrderTotalPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal OrderRemainingPayment { get; set; }
        [DataType(DataType.Currency)]
        public decimal OrderDownPayment => OrderTotalPrice - OrderRemainingPayment;
        public string? OrderDescription { get; set; }
        public string? CustomerName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? CustomerPhone { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? OrderStatus { get; set; } = "Sipriş Alındı";
    }
}
