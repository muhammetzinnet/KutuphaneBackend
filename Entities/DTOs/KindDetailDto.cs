using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.DTOs
{
    public class KindDetailDto : IDto
    {
        public int KindId { get; set; }
        public string KindName { get; set; }
        public string CategoryName { get; set; }
    }
}
