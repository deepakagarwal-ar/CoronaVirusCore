using AutoMapper;
using DeepakGallery.Data;
using DeepakGallery.Data.Entities;
using DeepakGallery.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IGalleryRepository repository;
        private readonly ILogger<OrdersController> logger;
        private readonly IMapper mapper;
        private readonly UserManager<GalleryUser> userManager;

        public OrdersController(
            IGalleryRepository repository, 
            ILogger<OrdersController> logger, 
            IMapper mapper, 
            UserManager<GalleryUser> userManager)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var user = this.User.Identity.Name;
                var orders = this.repository.GetAllOrdersByUser(user, includeItems);
                return Ok(this.mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders));
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed To get orders: {ex}");
                return BadRequest("Failed to get orders.");
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = this.User.Identity.Name;

                var order = this.repository.GetOrderById(user, id);
                if (order != null)
                {
                    var newOrder = this.mapper.Map<Order, OrderViewModel>(order);
                    return Ok(newOrder);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed To get orders: {ex}");
                return BadRequest("Failed to get orders.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderViewModel model)
        {
            //add model to the db
            try
            {
                if (ModelState.IsValid)
                {
                    var currentUser =  await this.userManager.FindByNameAsync(this.User.Identity.Name);
                    var newOrder = this.mapper.Map<OrderViewModel, Order>(model);
                    newOrder.LoginUser = currentUser;
                    this.repository.AddOrder(newOrder);
                    if (this.repository.SaveAll())
                    {
                        var updatedOrderViewModel = this.mapper.Map<Order, OrderViewModel>(newOrder);
                        return Created($"api/orders/{updatedOrderViewModel.OrderId}", updatedOrderViewModel);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed to save the order : { ex } ");
            }

            return BadRequest("Failed to save the order");
        }
    }
}
