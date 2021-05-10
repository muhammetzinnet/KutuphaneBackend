using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] Logics)
        {
            foreach (var logic in Logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }

        public static IResult Run(IResult[] results, object v1, object v2)
        {
            throw new NotImplementedException();
        }

        public static IResult Run(IResult result, object v1, object v2)
        {
            throw new NotImplementedException();
        }
    }
}
