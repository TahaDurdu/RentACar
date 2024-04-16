using System;
using System.Linq.Expressions;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Migrations;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> CarDetailDtos()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.CarId equals b.BrandId
                             join l in context.Colors on c.ColorId equals l.ColorId
                             select new CarDetailDto{CarName = c.CarName,BrandName = b.BrandName,ColorName = l.ColorName,DailyPrice = c.DailyPrice };

                return result.ToList();
                             
            }
        }
    }
}

