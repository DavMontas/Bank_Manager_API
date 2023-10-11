using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Request;

public class CreateBankAccountRequest
{
    public double Amount { get; set; }
    public string? AccountNumber { get; set; }
}
public class UpdateBankAccountRequest: CreateBankAccountRequest
{
    public int Id { get; set; }
}