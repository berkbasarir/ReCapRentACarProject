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
                        CarId = c.Id, 
                        CarName = c.Name, 
                        BrandName = b.Name, 
                        ColorName = co.Name, 
                        ModelYear = c.ModelYear, 
                        DailyPrice = c.DailyPrice, 
                        Description = c.Description
                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarProjectDbContext context = new RentACarProjectDbContext())
            {
                var result = 
                    from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join image in context.CarImages on car.Id equals image.CarId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.Name,
                                 CarName = car.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 ImageId = image.Id,
                                 ImagePath = image.ImagePath,
                                 Date = image.Date
                             };
                return result.ToList();
            }
        }
    }
}
