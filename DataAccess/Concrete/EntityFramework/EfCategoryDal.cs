using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntitiFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, LibraryContext>, ICategoryDal
    {
        
        public List<CategoryDetailDto> GetCategoryDetails()
        {
            using (var context = new LibraryContext())
            {
                var reult = from c in context.Categories
                    join b in context.Books on c.CategoryId equals b.BookId
                    select new CategoryDetailDto
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName
                    };
                return reult.ToList();
            }
        }
    }
}
