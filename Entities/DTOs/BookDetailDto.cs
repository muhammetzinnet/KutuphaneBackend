using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Entities;

namespace Entities.DTOs
{
    public class BookDetailDto : IDto
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string KindName { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string YearOfPrinting { get; set; }
        public string Description { get; set; }
    }
}
