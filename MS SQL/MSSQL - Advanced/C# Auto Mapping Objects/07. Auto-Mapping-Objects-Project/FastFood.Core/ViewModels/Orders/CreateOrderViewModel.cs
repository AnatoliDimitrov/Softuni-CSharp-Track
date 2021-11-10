namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<int> ItemsIds { get; set; }

        public List<string> ItemsNames { get; set; }

        public List<int> EmployeesIds { get; set; }

        public List<string> EmployeesNames { get; set; }
    }
}
