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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarsDetails()
        {
            using (RentACarProjectDbContext context = new RentACarProjectDbContext())
            {
                var result = 
                    from c in context.Cars 
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id
                    select new CarDetailDto
                    {
                        CarId = c.Id, CarName = c.Name, BrandName = b.Name, ColorName = co.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description
                    };
                return result.ToList();
            }
        }
    }
}
