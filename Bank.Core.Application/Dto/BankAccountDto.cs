using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bank.Core.Application.Dto
{
    public class BankAccountDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
    }
}
