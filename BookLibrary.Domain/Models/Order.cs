using BookLibrary.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models
{
    public class Order : Auditable
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal FineAmount { get; set; }
        public int? Rating { get; set; }
        public bool IsActive { get; set; }
    }
}
