using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarProjectDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetails()
        {
            using (RentACarProjectDbContext context = new RentACarProjectDbContext())
            {
                var result =
                    from r in context.Rentals
                    join c in context.Customers on r.CustomerId equals c.Id
                    join u in context.Users on c.UserId equals u.Id
                    join car in context.Cars on r.CarId equals car.Id
                    join b in context.Brands on car.BrandId  equals b.Id
                    select new RentalDetailDto()
                    {
                        RentalId = r.Id,
                        BrandName = b.Name,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,

                    };
                return result.ToList();
            }
        }
    }
}
