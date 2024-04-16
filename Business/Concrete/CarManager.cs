using System;
using Business.Abstract;
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

        public void Add(Car car)
        { 
                if (car.CarName.Length <= 2)
                {
                    Console.WriteLine("Araba ismini 2 karakterden fazla gireceksin");

                }
                else if (car.DailyPrice <= 0)
                {
                    Console.WriteLine("Arabanın günlük fiyatı 0 dan büyük olacak");
                }
                else
                {
                    _carDal.Add(car);
                    Console.WriteLine("Araba Başarıyla Eklendi");

                }
        }

        public List<CarDetailDto> carDetailDtos()
        {
            return _carDal.CarDetailDtos();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(p=> p.CarId==carId);
        }

        public List<Car> GetCarsByBrandId(int carId, int brandId)
        {
            return _carDal.GetAll(p => p.CarId == carId && p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int carId, int colorId)
        {
            return _carDal.GetAll(p => p.CarId == carId && p.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

