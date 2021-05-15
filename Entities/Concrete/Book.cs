using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int BookId { get; set; }
        public int CategoryId{ get; set; }
        public string KindName { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime YearOfPrinting { get; set; }
        public int Piece { get; set; }
        public string Description { get; set; }
    }
}
