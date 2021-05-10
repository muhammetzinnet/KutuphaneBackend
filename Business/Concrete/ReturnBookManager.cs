using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ReturnBookManager : IReturnBookService
    {
        private IReturnBookDal _returnBookDal;

        public ReturnBookManager(IReturnBookDal returnBookDal)
        {
            _returnBookDal = returnBookDal;
        }

        [SecuredOperation("category.update, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<List<ReturnBook>> GetAll()
        {
            return new SuccessDataResult<List<ReturnBook>>(_returnBookDal.GetAll(), Messages.ReturnBookListed);
        }
        
        [SecuredOperation("category.update, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IDataResult<ReturnBook> GetById(int id)
        {
            return new SuccessDataResult<ReturnBook>(_returnBookDal.Get(r => r.ReturnBookId == id));
        }
    }
}
