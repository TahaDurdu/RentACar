using System;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarImageDal: EfEntityRepositoryBase<CarImage,RentACarContext> ,ICarImageDal
	{
		
	}
}

