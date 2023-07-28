namespace Siparis.Web.UI.Models.Order
{
    public class UpdateOrderViewModel
    {
        public int OrderId { get; set; }
        public string? OrderImageUrl { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public decimal OrderRemainingPayment { get; set; }
        public decimal OrderDownPayment => OrderTotalPrice - OrderRemainingPayment;
        public string? OrderDescription { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderNumber { get; set; }
    }
}
