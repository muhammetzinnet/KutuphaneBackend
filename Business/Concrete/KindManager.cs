using System;
using System.Collections.Generic;
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
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class KindManager : IKindService
    {
        private IKindDal _kindDal;

        public KindManager(IKindDal kindDal)
        {
            _kindDal = kindDal;
        }

        //[SecuredOperation("kind.add, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IResult Add(Kind kind)
        {
            IResult result = BusinessRules.Run(CheckIfKindNameExists(kind.KindName));
            if (result != null)
            {
                return result;
            }
            _kindDal.Add(kind);
            return new SuccessResult(Messages.KindAdded);
        }

        private IResult CheckIfKindNameExists(string kindName)
        {
            var result = _kindDal.GetAll(k => k.KindName == kindName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BookNameAlreadyExists);
            }

            return new SuccessResult();
        }

        [SecuredOperation("kind.add, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IResult Delete(Kind kind)
        {
            IResult result = BusinessRules.Run(CheckIfKindNameExists(kind.KindName));
            if (result != null)
            {
                return result;
            }
            _kindDal.Delete(kind);
            return new SuccessResult(Messages.KindDeleted);
        }

        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<Kind>> GetAll()
        {
            return new SuccessDataResult<List<Kind>>(_kindDal.GetAll(), Messages.KindsListed);
        }

        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<Kind>> GetAllBook(Book book)
        {
            return new SuccessDataResult<List<Kind>>(_kindDal.GetAll(k => k.KindId == k.CategoryId));
        }

        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<Kind>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Kind>>(_kindDal.GetAll(k => k.KindId == id));
        }

        [SecuredOperation("kind.add, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IResult Update(Kind kind)
        {
            IResult result = BusinessRules.Run(CheckIfKindNameExists(kind.KindName));
            if (result != null)
            {
                return result;
            }
            _kindDal.Update(kind);
            return new SuccessResult(Messages.KindUpdated);
        }
    }
}
