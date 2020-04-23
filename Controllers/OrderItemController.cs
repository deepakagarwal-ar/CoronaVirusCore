using AutoMapper;
using DeepakGallery.Data;
using DeepakGallery.Data.Entities;
using DeepakGallery.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Controllers
{
    [Route("/api/orders/{orderId}/Items")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemController : Controller
    {
        private readonly IGalleryRepository repository;
        private readonly ILogger<OrderItemController> logger;
        private readonly IMapper mapper;


        public OrderItemController(IGalleryRepository repository, ILogger<OrderItemController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var user = this.User.Identity.Name;
            var order = this.repository.GetOrderById(user, orderId);
            if (order != null)
            {
                return Ok(this.mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            }
            else
            {
                return NotFound("Order Item not found.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var user = this.User.Identity.Name;
            var order = this.repository.GetOrderById(user, orderId);
            if (order != null)
            {
                var item = order.Items.Where(x => x.Id == id).FirstOrDefault();
                if(item != null)
                {
                    return Ok(this.mapper.Map<OrderItem, OrderItemViewModel>(item));
                }
                else
                {
                    return  NotFound("Item not found.");
                }
            }
            else
            {
                return NotFound("Order Item not found.");
            }
        }

    }
}
