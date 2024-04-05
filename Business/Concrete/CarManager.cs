using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCarRules(Car car)
        {

            if (car.CarName.Length > 2)
            {
                Console.WriteLine("Araba ismini 2 karakterden fazla gireceksin");

            }
            else if(((int)car.DailyPrice)>0)
            {
                Console.WriteLine("Arabanın günlük fiyatı 0dan büyük olacak");
            }
            else
            {
                Console.WriteLine("Araba Başarıyla Eklendi");
            }

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int carId, int brandId)
        {
            return _carDal.GetAll(p => p.CarId == carId && p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int carId, int colorId)
        {
            return _carDal.GetAll(p => p.CarId == carId && p.ColorId == colorId);
        }
    }
}

