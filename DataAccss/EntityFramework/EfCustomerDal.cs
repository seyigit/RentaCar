using Core.DataAccess.EntityFramework;
using DataAccss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccss.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customers,RentacarContext>,ICustomerDal
    {
    }
}
