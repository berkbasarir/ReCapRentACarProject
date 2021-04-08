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
        public List<CustomersDetailDto> GetCustomersDetails()
        {
            using (RentACarProjectDbContext context = new RentACarProjectDbContext())
            {
                var result =
                    from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomersDetailDto()
                    {
                        id = c.Id,
                        UserId = c.UserId,
                        FirstName = u.FirstName, 
                        LastName = u.LastName, 
                        CompanyName = c.CompanyName, 
                        Email = u.Email,
                        FindexPoint = (int)c.FindexPoint
                    };
                return result.ToList();
            }
        }

        public CustomersDetailDto GetByEmail(Expression<Func<CustomersDetailDto, bool>> filter)
        {
            using (var context = new RentACarProjectDbContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomersDetailDto
                             {
                                 id = customer.Id,
                                 UserId = customer.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName,
                                 FindexPoint = (int)customer.FindexPoint
                             };

                return result.SingleOrDefault(filter);
            }
        }
    }
}
