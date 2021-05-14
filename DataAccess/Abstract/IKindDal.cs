using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IKindDal : IEntityRepository<Kind>
    {
        List<KindDetailDto> GetKindDetails(Expression<Func<KindDetailDto>>filter=null);
    }
}
