using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternsKurs
{
    class NotifierStrategy
    {
        public virtual void toNotify(string username) { }
    }

    class GeneralStrategy : NotifierStrategy
    {
        Controller cntrl;

        public GeneralStrategy() : base()
        {
            cntrl = new Controller();
        }

        public override void toNotify(string username)
        {
            List<ReminderOutput> reminder_list = cntrl.getReminderList(username);
            bool flag = false;
            foreach (var reminder in reminder_list)
            {
                if((reminder.RemindType == "Ежемесячное" && DateTime.Today.Day == 1) || (reminder.Date == DateTime.Today))
                {
                    flag = true;
                    break;
                }          
            }
            if (flag)
                MessageBox.Show("У вас иммеются напоминания на сегодня. Пройдите во вкладку напоминания.", "Уведомление");
        }
    }

    class PersonalStrategy : NotifierStrategy
    {
        Controller cntrl;
        public PersonalStrategy() : base()
        {
            cntrl = new Controller();
        }
        public override void toNotify(string username)
        {
            List<ReminderOutput> reminder_list = cntrl.getReminderList(username);
            foreach (var reminder in reminder_list)
            {
                if ((reminder.RemindType == "Ежемесячное" && DateTime.Today.Day == 1) || (reminder.Date == DateTime.Today))
                {

                    string mess = "Напоминание: " + reminder.Name + ". Комментарий: " + reminder.Comment + ".";
                    MessageBox.Show(mess, "Уведомление");
                }
            }
        }
    }
}

