using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class CheckingAccount : Account
    {
        public decimal Limit { get; set; }
        public decimal[] CheckDeposit(decimal amount)
        {
            List<decimal> list = new List<decimal>();
            decimal value = Balance + amount;
            if (value > Limit)
            {
                decimal toSavings = value - Limit;
                decimal toChecking = amount - toSavings;
                list.Add(toChecking);
                list.Add(toSavings);
            }
            return list.ToArray();
        }
    }
}
