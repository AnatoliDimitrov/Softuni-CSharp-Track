using System;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using FastFood.Data;
using FastFood.Models;
using FastFood.Core.ViewModels.Orders;

namespace FastFood.Core.Controllers
{

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                ItemsIds = this.context.Items.Select(x => x.Id).ToList(),
                ItemsNames = this.context.Items.Select(x => x.Name).ToList(),
                EmployeesIds = this.context.Employees.Select(x => x.Id).ToList(),
                EmployeesNames = this.context.Employees.Select(x => x.Name).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            var orderId = this.context
                .Orders
                .Select(x => x.Id)
                .ToList()
                .Last();

            OrderItem orderItem = new OrderItem()
            {
                ItemId = model.ItemId,
                OrderId = orderId,
                Quantity = model.Quantity,
            };

            this.context.OrderItems.Add(orderItem);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}
