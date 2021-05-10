using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.DTOs
{
    public class ReturnBookDetailDto : IDto
    {
        public int ReturnBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LendPeriod { get; set; }
        public DateTime ReturnDate { get; set; }
        public int TotalDay { get; set; }
    }
}
