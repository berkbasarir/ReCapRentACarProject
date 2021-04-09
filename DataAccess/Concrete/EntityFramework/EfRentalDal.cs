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
                    from rental in context.Rentals
                    join customer in context.Customers on rental.CustomerId equals customer.Id
                    join user in context.Users on customer.UserId equals user.Id
                    join car in context.Cars on rental.CarId equals car.Id
                    join brand in context.Brands on car.BrandId  equals brand.Id
                    select new RentalDetailDto()
                    {
                        Id = rental.Id,
                        CarBrand = brand.Name,
                        CarModel = car.Description,
                        CustomerFirstName = user.FirstName,
                        CustomerLastName = user.LastName,
                        CompanyName = customer.CompanyName,
                        RentDate = rental.RentDate,
                        ReturnDate = (DateTime)rental.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
