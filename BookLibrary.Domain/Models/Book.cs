using BookLibrary.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models
{
    public class Book : Auditable
    {
        public string Title { get; set; }
        public decimal DailyPrice { get; set; }
        public float? Rating { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
