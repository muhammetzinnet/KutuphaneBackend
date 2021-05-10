using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IReturnBookDal : IEntityRepository<ReturnBook>
    {
        List<ReturnBookDetailDto> GetReturnBookDetails(Expression<Func<LendDetailDto, bool>> filter = null);
    }
}
