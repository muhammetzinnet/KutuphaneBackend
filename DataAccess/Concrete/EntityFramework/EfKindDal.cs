using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntitiFramework;
using Core.Entities.Concreate;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKindDal : EfEntityRepositoryBase<Kind, LibraryContext>, IKindDal
    {

        public List<KindDetailDto> GetKindDetails(Expression<Func<KindDetailDto>> filter = null)
        {
            using (var context = new LibraryContext())
            {
                var result = from k in context.Kinds
                    join c in context.Categories on k.KindName equals c.CategoryName
                    select new KindDetailDto()
                    {
                        KindId = k.KindId,
                        CategoryName = c.CategoryName,
                        KindName = k.KindName
                    };

                return result.ToList();
            }
        }
    }
}
