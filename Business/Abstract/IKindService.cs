using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IKindService
    {
        IDataResult<List<Kind>> GetAll();
        IDataResult<List<Kind>> GetAllById(int id);
        IDataResult<List<Kind>> GetAllBook();

        IResult Add(Kind kind);
        IResult Delete(Kind kind);
        IResult Update(Kind kind);
    }
}
