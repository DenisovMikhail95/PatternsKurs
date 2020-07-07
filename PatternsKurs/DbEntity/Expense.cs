using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsKurs
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal SumInValuta { get; set; }
        public decimal SumInRub { get; set; }
        public string Comment { get; set; }

        public int? ExpenseSubcategoryId { get; set; }
        public virtual ExpenseSubcategory ExpenseSubcategory { get; set; }

        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int? ValutaId { get; set; }
        public virtual Valuta Valuta { get; set; }

    }
}
