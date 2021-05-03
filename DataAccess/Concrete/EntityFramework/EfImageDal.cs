using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntitiFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageDal : EfEntityRepositoryBase<Image, LibraryContext>, IImageDal
    {
    }
}
