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

        [SecuredOperation("category.update, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IResult Add(ReturnBook returnBook)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(returnBook.BookName));
            if (result!=null)
            {
                return result;
            }
            _returnBookDal.Add(returnBook);
            return new SuccessResult(Messages.ReturnBookAdd);
        }

        private IResult CheckIfBookNameExists(string bookName)
        {
            var result = _returnBookDal.GetReturnBookDetails(r => r.BookName == r.BookName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ReturnBookAlreadyExists);
            }

            return new SuccessResult();
        }

        [SecuredOperation("category.update, admin")]
        [ValidationAspect(typeof(KindValidator))]
        public IResult Delete(ReturnBook returnBook)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(returnBook.BookName));
            if (result!=null)
            {
                return result;
            }
            _returnBookDal.Delete(returnBook);
            return new SuccessResult(Messages.ReturnBookDelete);
        }
    }
}
