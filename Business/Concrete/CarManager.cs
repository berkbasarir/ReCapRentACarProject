using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Business.BusinessAspects.Autofac;
using Entities.DTOs;
using System;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarImageService _carImageService;


        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [SecuredOperation("car.add, admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator), Priority = 1)]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExist(car.Name));

            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [PerformanceAspect(5)]
        //[SecuredOperation("car.list, Admin")]
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour >= 15 && DateTime.Now.Hour < 16)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByModelYear(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear >= min && c.ModelYear <= max), Messages.Listed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.Listed);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            //if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 18)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarsDetails(), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(filter), "Ürünler Listelendi.");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(c => c.BrandId == BrandId).ToList());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(c => c.ColorId == ColorId).ToList());
        }





        private IResult CheckIfProductNameExist(string carName)
        {
            //Aynı isimde ürün var mı
            var result = _carDal.GetAll(p => p.Name == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExist);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
