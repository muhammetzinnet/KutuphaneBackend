using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concreate;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
