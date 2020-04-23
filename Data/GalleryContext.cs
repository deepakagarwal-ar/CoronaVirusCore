using DeepakGallery.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Data
{
    public class GalleryContext : IdentityDbContext<GalleryUser>
    {
        public GalleryContext(DbContextOptions<GalleryContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                OrderDate=DateTime.Now,
                OrderNumber = "12345",
            });
        }
    }
}
