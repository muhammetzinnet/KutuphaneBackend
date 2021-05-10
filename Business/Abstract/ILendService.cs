using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ILendService
    {
        IDataResult<List<Lend>> GetAll();
        IDataResult<List<Lend>> GetAllBook(Book book);
        IDataResult<List<Lend>> GetById(int id);
        IResult Add(Lend lend);
        IResult Delete(Lend lend);
        IResult Update(Lend lend);
    }
}
