using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class ReturnBook :IEntity
    {
        public int ReturnBookId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
