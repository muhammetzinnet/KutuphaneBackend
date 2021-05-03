using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.DTOs
{
    public class CategoryDetailDto : IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
