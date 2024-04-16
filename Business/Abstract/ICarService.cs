using System;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface ICarService
	{
		List<Car> GetAll();
        List<Car> GetCarsByBrandId(int carId,int brandId);
        List<Car> GetCarsByColorId(int carId, int colorId);
		List<CarDetailDto> carDetailDtos();
		Car GetById(int carId);
		void Add(Car car);
		void Update(Car car);
		void Delete(Car car);
    }
}

