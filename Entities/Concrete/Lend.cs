using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Lend : IEntity
    {
        public int LendId { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateTime LendDate { get; set; }
        public int LendPeriod { get; set; }
    }
}
