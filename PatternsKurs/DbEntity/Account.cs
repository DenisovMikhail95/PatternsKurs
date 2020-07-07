using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatternsKurs
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? FamilyMemberId { get; set; }
        public virtual FamilyMember FamilyMember { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

        public Account()
        {
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }
    }
}
