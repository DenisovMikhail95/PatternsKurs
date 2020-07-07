using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class RemindType //тип напоминания
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }

        public RemindType()
        {
            Reminders = new List<Reminder>();
        }
    }
}
