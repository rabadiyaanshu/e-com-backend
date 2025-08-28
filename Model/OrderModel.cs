using System;
using System.ComponentModel.DataAnnotations;

namespace WebLoginRegisterApi.Model
{
    public class OrderModel
    {
        [Key]
        
        public int Id { get; set; }

        
        public int UserId { get; set; }

        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string PaymentMethod { get; set; }

        // For record keeping
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
