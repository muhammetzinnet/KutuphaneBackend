using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntitiFramework;
using Core.Entities.Concreate;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, LibraryContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new LibraryContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, OpClmName = operationClaim.OpClmName };
                return result.ToList();

            }
        }
    }
}
