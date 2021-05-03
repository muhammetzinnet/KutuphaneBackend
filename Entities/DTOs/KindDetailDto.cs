using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.DTOs
{
    public class KindDetailDto : IDto
    {
        public int KindId { get; set; }
        public int CategoryId { get; set; }
        public string KindName { get; set; }
    }
}
