using Siparis.BussinessLayer.Abstract;
using Siparis.DataAccessLayer.Abstract;
using Siparis.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siparis.BussinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TDelete(Order item)
        {
            _orderDal.Delete(item);
        }

        public Order? TFindByCondition(Expression<Func<Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> TGetList()
        {
            return _orderDal.GetList();
        }

        public void TInsert(Order item)
        {
            _orderDal.Insert(item);
        }

        public void TUpdate(Order item)
        {
            _orderDal.Update(item);
        }
    }
}
