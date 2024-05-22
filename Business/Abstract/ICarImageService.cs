using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
	public interface ICarImageService
	{

        //TODO :  Carimages yerine DTO oluşturulacak 

        IResult Add(IFormFile file, int carId);
        IResult Delete(int id);
        IResult Update(IFormFile file,int id);

        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetByImageId(int imageId);
    }
}

