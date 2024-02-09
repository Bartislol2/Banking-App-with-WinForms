using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
        public Account SavingsAccount { get; set; }
    }
}
