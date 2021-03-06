using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarProjectDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarProjectDbContext context = new RentACarProjectDbContext())
            {
                var result =
                    from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailDto()
                    {
                        CustomerId = c.Id, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName, Email = u.Email
                    };
                return result.ToList();
            }
        }
    }
}
