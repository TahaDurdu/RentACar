using System;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ICarService
	{
		List<Car> GetAll();
		List<Car> GetCarsByBrandId(int carId,int brandId);
		List<Car> GetCarsByColorId(int carId, int colorId);
		void AddCarRules(Car car);
    }
}

