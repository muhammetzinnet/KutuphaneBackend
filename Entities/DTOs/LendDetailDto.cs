using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.DTOs
{
    public class LendDetailDto : IDto
    {
        public int LendId { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateTime LendDate { get; set; }
        public int LendPeriod { get; set; }
        public int TotalDay { get; set; }
        public DateTime ReturnBookDate { get; set; }
    }
}
