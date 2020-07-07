using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsKurs
{
    class Notifier
    {
        public NotifierStrategy strategy { get; set; } //ссылка на класс стратегии

        public Notifier(NotifierStrategy notifier_strategy)
        {
            strategy = notifier_strategy;
        }

        public void toNotify(string username)
        {
            strategy.toNotify(username); //используем нужную стратегию
        }
    }
}
