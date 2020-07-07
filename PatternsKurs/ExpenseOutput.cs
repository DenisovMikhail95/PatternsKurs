using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsKurs
{
    class ExpenseOutput
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal SumInCurValuta { get; set; }
        public string Valuta { get; set; }
        public decimal SumInValuta { get; set; }
        public string ExpenseCategory { get; set; }
        public string ExpenseSubcategory { get; set; }
        public string Account { get; set; }
        public string Comment { get; set; }

    }
}
