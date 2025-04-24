using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace udemyMAUI1.MVVM.Models
{
     public class TransactionsSummary
     {
          public DateTime TransactionsDate { get; set; }
          public string ShownDate { get; set; }
          public decimal TransactionsTotal { get; set; }
     }
}
