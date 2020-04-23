using DeepakGallery.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly IGalleryRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IGalleryRepository repository, ILogger<ProductsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed to get the products : {ex}");
                return BadRequest("Failed to get the products details try again after some time.");
            }
        }
    }
}
