using DeepakGallery.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeepakGallery.Data
{
    public class GalleryDataSeeder
    {
        private readonly GalleryContext context;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<GalleryUser> userManager;

        public GalleryDataSeeder(GalleryContext context, IWebHostEnvironment hosting, UserManager<GalleryUser> userManager)
        {
            this.context = context;
            this.hosting = hosting;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            this.context.Database.EnsureCreated();

            var user = await this.userManager.FindByEmailAsync("deepak.agarwal@appliedis.com");

            if(user == null)
            {
                user = new GalleryUser
                {
                    FirstName = "Deepak",
                    LastName = "Agarwal",
                    Email = "deepak.agarwal@appliedis.com",
                    UserName="deepak.agarwal@appliedis.com"
                };

                var result = await this.userManager.CreateAsync(user, "Deepak@74");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Cannot create the seeded user.");
                }
            }

            if (!this.context.Products.Any())
            {
                var filepath = Path.Combine(this.hosting.ContentRootPath, "Data\\art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                this.context.Products.AddRange(products);
                var order = this.context.Orders.FirstOrDefault(x => x.Id == 1);
                if (order != null)
                {
                    order.LoginUser = user;
                    order.Items = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Product = products.FirstOrDefault(),
                            Quantity = 4,
                            UnitPrice = products.FirstOrDefault().Price
                        }
                    };
                }
                this.context.SaveChanges();
            }
        }
    }
}
