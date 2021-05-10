using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IReturnBookService
    {
        IDataResult<List<ReturnBook>> GetAll();
        IDataResult<ReturnBook> GetById(int id);
    }
}
