using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PatternsKurs
{
    public class Reminder //напоминание
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public int? RemindTypeId { get; set; }
        public virtual RemindType RemindType { get; set; }

        public int? FamilyMemberId { get; set; }
        public virtual FamilyMember FamilyMember { get; set; }

    }

}
