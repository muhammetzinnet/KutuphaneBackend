using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntitiFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLendDal : EfEntityRepositoryBase<Lend, LibraryContext>, ILendDal
    {
        public List<LendDetailDto> GetLendDetails(Expression<Func<LendDetailDto, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {


                var result = from l in context.Lends
                    join b in context.Books
                        on l.BookName equals b.BookName
                    join us in context.Users on l.UserName equals us.FirstName
                    join r in context.ReturnBooks on l.LendDate equals r.ReturnDate


                    select new LendDetailDto()
                    {
                        LendId = l.LendId,
                        BookName = l.BookName,
                        UserName = us.FirstName,
                        LendDate = r.ReturnDate,
                        LendPeriod = l.LendPeriod,
                        ReturnBookDate = r.ReturnDate,
                        TotalDay = (l.LendDate.Day - r.ReturnDate.Day)
                    };

                return filter==null? result.ToList(): result.Where(filter).ToList();
            }
        }

    }
}
