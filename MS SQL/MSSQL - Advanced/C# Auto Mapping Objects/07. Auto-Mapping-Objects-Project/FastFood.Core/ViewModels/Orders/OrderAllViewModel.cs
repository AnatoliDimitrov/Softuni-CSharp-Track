﻿using System;

namespace FastFood.Core.ViewModels.Orders
{
    public class OrderAllViewModel
    {
        public int OrderId { get; set; }

        public string Customer { get; set; }

        public string EmployeeName { get; set; }

        public DateTime DateTime { get; set; }
    }
}
