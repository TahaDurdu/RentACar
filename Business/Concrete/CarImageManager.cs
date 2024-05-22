using System;
using Business.Abstract;
using Business.Constans;
using Core.Helpers.FileHalper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
	public class CarImageManager:ICarImageService
	{
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        ICarDal _carDal;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper,ICarDal carDal)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            _carDal = carDal;
        }
        public IResult Add(IFormFile file, int carId)
        {
            IResult result = BusinessRules.Run(CheckCarById(carId),CheckIfCarImageLimit(carId));
           
            if (result != null)
            {
                return result;
            }
            var carImage = new CarImage();
            carImage.CarId = carId;
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Delete(int id)
        {
            var result = BusinessRules.Run(CheckCarImageById(id));
            if (result != null)
            {
                return result;
            }
            var dataResult = _carImageDal.Get(c => c.Id == id);

            _fileHelper.Delete(PathConstants.ImagesPath + dataResult.ImagePath);
            _carImageDal.Delete(dataResult);
            return new SuccessResult();
        }
        public IResult Update(IFormFile file, int id)
        {
            var result = BusinessRules.Run(CheckCarImageById(id));
            if (result != null)
            {
                return result;
            }
            var dataResult = _carImageDal.Get(c => c.Id == id);

            dataResult.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + dataResult.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(dataResult);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImageByCarId(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpeg" });

            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        private IResult CheckCarImageByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Car Image Not Found");
        }
        private IResult CheckCarImageById(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            if (result is not null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Car Image Not Found");
        }
        private IResult CheckCarById(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result is not null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Car Not Found");
        }

    }
}

