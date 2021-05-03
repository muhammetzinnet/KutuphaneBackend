using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<Book>> GetAllByCategoryId(int id);
        IDataResult<List<Book>> GetAllByKind();
        IDataResult<List<Book>> GetAllByLend();
        IDataResult<List<BookDetailDto>> GetBookDetails();
        IDataResult<Book> GetById(int bookId);

        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
    }
}
