using System;
using System.Security.Cryptography.Xml;
using FastFood.Models.Enums;

namespace FastFood.Core.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        public string Customer { get; set; }

        public int ItemId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime DateTime { get; set; }

        public int Quantity { get; set; }

        public OrderType Type { get; set; }
    }
}
