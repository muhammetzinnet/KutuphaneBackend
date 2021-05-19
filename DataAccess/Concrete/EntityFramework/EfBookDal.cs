using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntitiFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from b in context.Books
                    join c in context.Categories on b.CategoryId equals c.CategoryId
                    join k in context.Kinds on b.KindName equals k.KindName

                    select new BookDetailDto
                    {
                        BookId = b.BookId,
                        BookName = b.BookName,
                        CategoryId = c.CategoryId,
                        KindName = k.KindName,
                        Author = b.Author,
                        Publisher = b.Publisher,
                        YearOfPrinting = b.YearOfPrinting,
                        Piece = b.Piece,
                        Description = b.Description,
                        

                    };
                return result == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
