using System.Collections.ObjectModel;
using System.Collections.Generic;
using DAL.Operations;
using DAL.Entities;
using DAL.Interfaces;

namespace Models.Collections
{
    public class OrdersCollections : IEntityCollection<Order>
    {
        private List<Order> orders;
        private OrdersOperations orderOperations;
        //private const int EntityTablesCount = 6;

        public OrdersCollections()
        {
            orderOperations = new OrdersOperations();
            orders = new List<Order>();
            orders = orderOperations.GetAll();
        }

        public void Add(Order order)
        {
            orderOperations.Insert(order);
            orders.Clear();
            orders = orderOperations.GetAll();
        }
        public void Update(Order order)
        {
            orderOperations.Update(order);
            orders.Clear();
            orders = orderOperations.GetAll();
        }
        public void Delete(int id)
        {
            orderOperations.Delete((int)orders[id].Id);
            orders.RemoveAt(id);
        }

        public List<Order> GetAll()
        {
            return orders;
        }
        public Order GetByID(int id)
        {
            return orders[id];
        }
        public int GetEntitiesCount()
        {
            return orders.Count;
        }
        //public int GetEntityTablesCount()
        //{
        //    return EntityTablesCount;
        //}
    }
}
