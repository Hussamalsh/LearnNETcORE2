using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnNETcORE2.Models.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
