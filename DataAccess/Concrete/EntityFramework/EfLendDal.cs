using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntitiFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLendDal : EfEntityRepositoryBase<Lend, LibraryContext>, ILendDal
    {
        public List<LendDetailDto> GetLendDetails(Lend lend)
        {
            using (LibraryContext context = new LibraryContext())
            {


                var result = from l in context.Lends
                    join u in context.Users
                        on l.LendId equals u.Id

                    select new LendDetailDto()
                    {
                        LendId = l.LendId,
                        BookName = l.BookName,
                        UserName = l.UserName,
                        BorrowingDate = l.BorrowingDate,
                        LendDate = l.LendDate,
                        LendPeriod = l.LendPeriod,
                        
                    };

                return result.ToList();
            }
        }
    }
}
