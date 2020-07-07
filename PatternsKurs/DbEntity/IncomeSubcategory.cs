using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class IncomeSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? IncomeCategoryId { get; set; }
        public virtual IncomeCategory IncomeCategory { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }

        public IncomeSubcategory()
        {
            Incomes = new List<Income>();
        }
    }
}
