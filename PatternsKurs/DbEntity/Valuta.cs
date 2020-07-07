using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class Valuta //валюта
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

        public Valuta()
        {
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }
    }
}
