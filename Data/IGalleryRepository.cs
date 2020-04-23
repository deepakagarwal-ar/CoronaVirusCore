using DeepakGallery.Data.Entities;
using System.Collections.Generic;

namespace DeepakGallery.Data
{
    public interface IGalleryRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrdersByUser(string user, bool includeItems);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(string user, int id);
        void AddOrder(Order newOrder);

        void AddEntity(object model);
        bool SaveAll();
    }
}