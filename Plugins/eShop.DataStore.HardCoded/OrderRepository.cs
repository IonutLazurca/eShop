using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders;
        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }
        public int CreateOrder(Order order)
        {
            order.OrderId = orders.Count + 1;
            orders.Add(order.OrderId.Value, order);
            return order.OrderId.Value;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var items = orders.FirstOrDefault(x => x.Value.OrderId == orderId).Value.LineItems;
            return items;
        }

        public Order GetOrder(int orderid)
        {
            return orders[orderid];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            return orders.FirstOrDefault(x => x.Value.UniqueId == uniqueId).Value;
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;            
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue == false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue);
            
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderId.HasValue) return;
            var ord = orders[order.OrderId.Value];
            if (ord == null) return;
            orders[order.OrderId.Value] = order; ;
        }
    }
}
