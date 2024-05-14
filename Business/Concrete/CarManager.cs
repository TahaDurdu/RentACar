using System;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]

        [SecuredOperation("admin")]

        public IResult Add(Car car)
        { 
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAddedSuccess);

        }

        public IDataResult<List<CarDetailDto>> carDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetailDtos(),Messages.CarDetailDtosGo);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

           return new SuccessResult(Messages.CarDeleteSuccess);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarGetAllSuccess);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=> p.CarId==carId),Messages.GetByIdCarSuccess);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int carId, int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.CarId == carId && p.BrandId == brandId),Messages.CarByBrandTableSuccess);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int carId, int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.CarId == carId && p.ColorId == colorId),Messages.CarByColorTableSuccess);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdateSuccess);
        }
    }
}

