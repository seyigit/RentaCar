using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccss.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rentals rental)
        {

            if (rental.ReturnDate==null)
            {
                return new ErrorResult(Messages.AddToRentalInvalid);
            }
            _rentalDal.Add(rental);

            return new SuccesResult(Messages.AddToRentalSuccessMessage);
        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);

            return new SuccesResult(Messages.DeleteToRentalSuccessMessage);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(), Messages.GetAllFilterSuccessMessage);
        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);

            return new SuccesResult(Messages.UpdateToRentalSuccessMessage);
        }
    }
}
