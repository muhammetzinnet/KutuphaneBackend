using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<KindDetailDto> KindDetailDto(Kind kind)
        {
            using (var context = new LibraryContext())
            {
                var result = from k in context.Kinds
                    join c in context.Categories on k.KindId equals c.CategoryId
                    select new KindDetailDto()
                    {
                        KindId = k.KindId,
                        CategoryId = c.CategoryId,
                        KindName = k.KindName
                    };

                return result.ToList();
            }
        }
    }
}
