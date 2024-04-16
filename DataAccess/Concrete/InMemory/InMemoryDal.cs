using System;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryDal: ICarDal
	{
		List<Car> cars;

		public InMemoryDal()
		{
            cars = new List<Car>
            {
                new Car{CarId = 1 , BrandId =1 , ColorId=1 , ModelYear =2021 , DailyPrice = 2250000 , Description = "Citroen C5 Aircross 1.6 Motor Beyaz" },
                new Car{CarId = 2 , BrandId =1 , ColorId=2 , ModelYear =2022 , DailyPrice = 3000000 , Description = "Citroen C5 Aircross 1.4 Motor Kırmızı" },
                new Car{CarId = 3 , BrandId =2 , ColorId=1 , ModelYear =2019 , DailyPrice = 700000 , Description = "Toyota Corolla 1.4 Motor Beyaz" },
                new Car{CarId = 4 , BrandId =3 , ColorId=2 , ModelYear =2011 , DailyPrice = 225000 , Description = "Bmw 1.0 Motor Kırmızı" },
                new Car{CarId = 5 , BrandId =4 , ColorId=1 , ModelYear =2023 , DailyPrice = 3225000 , Description = "Mercedes 2.0 Motor Beyaz" }
            };

		}

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public List<CarDetailDto> CarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car cardelete = cars.SingleOrDefault(p=>p.CarId == car.CarId);
            cars.Remove(cardelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {

            return cars.Where(p=> p.BrandId == brandId).ToList();

        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carUpdate = cars.SingleOrDefault(p=>p.CarId == car.CarId);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.Description = car.Description;

        }
    }
}

