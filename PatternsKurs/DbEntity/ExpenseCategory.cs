using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsKurs
{
    public class ExpenseCategory //категория расходов
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExpenseSubcategory> ExpenseSubcategorys { get; set; }     

        public ExpenseCategory()
        {
            ExpenseSubcategorys = new List<ExpenseSubcategory>();
        }
    }
}
