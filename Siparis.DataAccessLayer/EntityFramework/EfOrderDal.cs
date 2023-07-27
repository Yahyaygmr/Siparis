using Siparis.DataAccessLayer.Abstract;
using Siparis.DataAccessLayer.Concrete;
using Siparis.DataAccessLayer.Repositories;
using Siparis.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siparis.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }
    }
}
