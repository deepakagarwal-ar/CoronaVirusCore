using DeepakGallery.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DeepakGallery.Data
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly GalleryContext context;
        private readonly ILogger<GalleryRepository> logger;

        public GalleryRepository(GalleryContext context, ILogger<GalleryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public IEnumerable<Order> GetAllOrdersByUser(string user, bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return this.context.Orders
                        .Where(o => o.LoginUser.UserName == user)
                        .Include(x => x.Items)
                        .ThenInclude(p => p.Product).ToList();

                }
                else
                {
                    return this.context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed To get orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return this.context.Orders
                        .Include(x => x.Items)
                        .ThenInclude(p => p.Product).ToList();

                }
                else
                {
                    return this.context.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed To get orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrders(string user, bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return this.context.Orders
                        .Where(o => o.LoginUser.UserName == user)
                        .Include(x => x.Items)
                        .ThenInclude(p => p.Product).ToList();

                }
                else
                {
                    return this.context.Orders.Where(o => o.LoginUser.UserName == user).ToList();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed To get orders: {ex}");
                return null;
            }
        }

        public void AddOrder(Order newOrder)
        {
            foreach (var item in newOrder.Items)
            {
                item.Product = this.context.Products.Find(item.Product.Id);
            }

            AddEntity(newOrder);
        }

        public Order GetOrderById(string user, int id)
        {
            try
            {
                return this.context.Orders
                    .Include(x => x.Items)
                    .ThenInclude(p => p.Product)
                    .Where(x => x.Id == id && x.LoginUser.UserName == user)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Failed To get orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return this.context.Products.OrderBy(x => x.Title).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"GetAllProducts failed { ex }");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return this.context.Products.Where(x => x.Category == category).ToList();
        }




        public bool SaveAll()
        {
            return this.context.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            this.context.Add(model);
        }


    }
}
