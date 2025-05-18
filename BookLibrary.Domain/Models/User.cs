
using BookLibrary.Domain.Enums;
using BookLibrary.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models
{
    public class User : Auditable
    {
        public string FullName { get; set; }
        public Role Role { get; set; }
        public List<Order> Orders { get; set; }

    }
}
