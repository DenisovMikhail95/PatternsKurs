using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class FamilyMember //член семьи
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }

        public FamilyMember()
        {
            Reminders = new List<Reminder>();
            Accounts = new List<Account>();
        }
    }
}
