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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer, LibraryContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GeCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (LibraryContext context = new LibraryContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id

                    select new CustomerDetailDto
                    {
                        UserId = u.Id,
                        CustomerId = c.CustomerId,
                        ContactName = c.ContactName,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        PasswordHash = u.PasswordHash,
                        PasswordSalt = u.PasswordSalt,
                        Status = u.Status
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList;
            }
        }
    }
}
