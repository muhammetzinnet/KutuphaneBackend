using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Kind : IEntity
    {
        public int KindId { get; set; }
        public string CategoryName{ get; set; }
        public string KindName { get; set; }
    }
}
