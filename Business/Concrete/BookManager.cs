using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [SecuredOperation("book.add, admin")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(book.BookName));
            if (result!=null)
            {
                return result;
            }
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        [SecuredOperation("book.add, admin")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Delete(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(book.BookName));
            if (result != null)
            {
                return result;
            }
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }

        public IDataResult<List<Book>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Book>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(), Messages.BooksListed);
        }

        public IDataResult<List<Book>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.CategoryId == id));
        }

        public IDataResult<List<Book>> GetAllByKind()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<Book>> GetAllByLend()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<List<BookDetailDto>> GetBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails());
        }
        [PerformanceAspect(5)]
        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.BookId == bookId));
        }

        [SecuredOperation("book.add, admin")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(book.BookName));
            if (result != null)
            {
                return result;
            }
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }

        private IResult CheckIfBookNameExists(string bookName)
        {
            var result = _bookDal.GetAll(b => b.BookName == bookName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BookNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
