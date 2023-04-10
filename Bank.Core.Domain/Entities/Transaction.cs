using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int IdAccountFrom { get; set; }
        public int IdAccountTo { get; set;}

    }
}
