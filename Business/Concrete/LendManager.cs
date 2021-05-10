using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class LendManager : ILendService
    {
        private ILendDal _lendDal;

        public LendManager(ILendDal lendDal)
        {
            _lendDal = lendDal;
        }

        [ValidationAspect(typeof(KindValidator))]
        public IResult Add(Lend lend)
        {
            IResult result = BusinessRules.Run(CheckIfTheBookHasBeenDelivered(lend),
                CheckIfitisPastDelivery(lend), CheckIfRentDay(lend));
            if (result!=null)
            {
                return result;
            }
            _lendDal.Add(lend);
            return new SuccessResult(Messages.LendAdded);
        }

        private object CheckIfRentDay(Lend lend)
        {
            if (lend.LendDate.Day < DateTime.Now.Day)
            {
                return new ErrorResult(Messages.LendDayCantbePast);
            }
            return new SuccessResult();
        }

        private object CheckIfitisPastDelivery(Lend lend)
        {
            var result = _lendDal.GetAll(l => l.LendId == lend.LendId && (lend.LendDate.Day - l.LendPeriod) == 0);
            if (result.Any())
            {
                return new ErrorResult(Messages.BookOnRent);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTheBookHasBeenDelivered(Lend lend)
        {
            var result = _lendDal.GetAll(l => l.LendId == lend.LendId);
            if (result.Any())
            {
                return new ErrorResult(Messages.RentalNotComeBack);
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(KindValidator))]
        public IResult Delete(Lend lend)
        {
            _lendDal.Delete(lend);
            return new SuccessResult(Messages.LendDeleted);
        }

        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<Lend>> GetAll()
        {
            return new SuccessDataResult<List<Lend>>(_lendDal.GetAll(), Messages.LendsListed);
        }

        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<Lend>> GetAllBook(Book book)
        {
            return new SuccessDataResult<List<Lend>>(_lendDal.GetAll(), Messages.BookLendsListed);
        }

        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<Lend>> GetById(int id)
        {
            return new SuccessDataResult<List<Lend>>(_lendDal.GetAll(l => l.LendId == id));
        }

        [ValidationAspect(typeof(KindValidator))]
        public IResult Update(Lend lend)
        {
            _lendDal.Update(lend);
            return new SuccessResult(Messages.LendUpdated);
        }
    }
}
