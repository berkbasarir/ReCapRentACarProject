using System;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImagesNumberLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);




            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            IResult result = BusinessRules.Run(CheckOfManitanceTime());

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetAllByCarId(int carId)
        {
            var images = _carImageDal.GetAll(c => c.Id == carId);
            foreach (var image in images)
            {
                if (image.ImagePath != null)
                {
                    return new SuccessDataResult<CarImage>(image.ImagePath);
                }
            }
            return new SuccessDataResult<CarImage>(Messages.DefaultImage);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        private IResult CarImagesNumberLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }

            return new SuccessResult();
        }

        private IResult CheckOfManitanceTime()
        {
            if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 18)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult();
        }
    }
}