using System;
using Core.DataAccess;
using Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
	public interface ICarDal:IEntityRepository<Car>
	{
		List<CarDetailDto> CarDetailDtos();

	}
}

