using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ILendDal : IEntityRepository<Lend>
    {
        List<LendDetailDto> GetLendDetails(Expression<Func<LendDetailDto, bool>> filter = null);
    }
}
