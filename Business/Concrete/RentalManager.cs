using System;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
	public class RentalManager:IRentalService
	{
        IRentalDal _rentalDal;

		public RentalManager(IRentalDal rentalDal)
		{
            _rentalDal = rentalDal;
		}

        public IResult Add(Rental rental)
        {
            bool isCarAvailable = !(_rentalDal.GetAll(r => r.CarId == rental.CarId &&  r.ReturnDate==null ).Any());

            if (isCarAvailable)
            {
                return new ErrorResult(Messages.CarNotDelivered);
               

            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdd);



        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalGetAll);
        }

        public IDataResult<List<Rental>> GetCarIdByCustomerId(int carId, int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p=>p.CarId==carId && p.CustomerId ==customerId));
        }

       
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}

