using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntitiFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, LibraryContext>, ICategoryDal
    {
        public List<CategoryDetailDto> GetCategoryDetails(Expression<Func<CategoryDetailDto, bool>> filter = null)
        {
            using (var context = new LibraryContext())
            {
                var reult = from c in context.Categories
                    join b in context.Books on c.CategoryId equals b.BookId
                    join k in context.Kinds on c.CategoryId equals k.KindId 
                    select new CategoryDetailDto
                    {
                        CategoryId = c.CategoryId
                        
                    };
                return reult==null? reult.ToList():reult.Where(filter).ToList();
            }
        }
    }
}
