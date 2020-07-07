using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class IncomeCategory //категория доходов
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IncomeSubcategory> IncomeSubcategorys { get; set; }

        public IncomeCategory()
        {
            IncomeSubcategorys = new List<IncomeSubcategory>();
        }
    }
}
