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
    public class EfReturnBookDal : EfEntityRepositoryBase<ReturnBook, LibraryContext>, IReturnBookDal
    {
        public List<ReturnBookDetailDto> GetReturnBookDetails(Expression<Func<LendDetailDto, bool>> filter = null)
        {
            using (LibraryContext libraryContext = new LibraryContext())
            {
                var result = from r in libraryContext.ReturnBooks
                    join l in libraryContext.Lends on r.ReturnBookId equals l.LendId
                    join u in libraryContext.Users on r.FirstName equals u.FirstName 
                    select new ReturnBookDetailDto()
                    {
                        ReturnBookId = r.ReturnBookId,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        ReturnDate = r.ReturnDate,
                        LendPeriod = l.LendPeriod,

                        TotalDay = (r.ReturnDate.Day - l.LendPeriod)
                        
                    };
                return result.ToList();
            }
        }
    }
}
