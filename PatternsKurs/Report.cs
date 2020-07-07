using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternsKurs
{
    class CategoryInfo
    {
       public string name;
       public double sum;
       public double percent;
    }
    class ValutaAndAccountInfo
    {
        public string name;
        public double percent;
    }


    class NoteExpenseAndIncome
    {
        public double TotalExpense { get; set; }
        public double ToTalIncome { get; set; }
    }

    class NoteCategory
    {
        public List<CategoryInfo> AboutExCategorys { get; set; }
        public List<CategoryInfo> AboutInCategorys { get; set; }
        public NoteCategory()
        {
            AboutExCategorys = new List<CategoryInfo>();
            AboutInCategorys = new List<CategoryInfo>();
        }
    }
    class NoteSubcategory
    {
        public List<CategoryInfo> AboutExSubcategorys { get; set; }
        public List<CategoryInfo> AboutInSubcategorys { get; set; }
        public NoteSubcategory()
        {
            AboutExSubcategorys = new List<CategoryInfo>();
            AboutInSubcategorys = new List<CategoryInfo>();
        }
    }
    class NoteValuta
    {
        public List<ValutaAndAccountInfo> AboutValutas { get; set; }

        public NoteValuta()
        {
            AboutValutas = new List<ValutaAndAccountInfo>();
        }
    }
    class NoteAccount
    {
        public List<ValutaAndAccountInfo> AboutAccounts { get; set; }

        public NoteAccount()
        {
            AboutAccounts = new List<ValutaAndAccountInfo>();
        }
    }

    class Report
    {
        public NoteExpenseAndIncome NoteExpenseAndIncome { get; set; }
        public NoteCategory NoteCategory { get; set; }
        public NoteSubcategory NoteSubcategory { get; set; }
        public NoteValuta NoteValuta { get; set; }
        public NoteAccount NoteAccount { get; set; }

        public string Print()
        {
            string doc = "";

            if(NoteExpenseAndIncome != null)
            {
                doc += "Общий доход составил: " + NoteExpenseAndIncome.ToTalIncome + "\r\n";
                doc += "Общий расход составил:" + NoteExpenseAndIncome.TotalExpense + "\r\n\r\n";
                doc += "-------------------------------------------------------------------\r\n\r\n";
            }
            if(NoteCategory != null)
            {
                doc += "Категории дохода:\r\n\r\n";
                foreach (var cat in NoteCategory.AboutInCategorys)
                {
                    doc += cat.name + "   " + cat.sum + " руб.   (" + Math.Round(cat.percent,2) + " %)\r\n";
                }
                doc += "\r\n";
                doc += "Категории расхода:\r\n\r\n";
                foreach (var cat in NoteCategory.AboutExCategorys)
                {
                    doc += cat.name + "   " + cat.sum + " руб.   (" + Math.Round(cat.percent,2) + " %)\r\n";
                }
                doc += "\r\n-------------------------------------------------------------------\r\n\r\n";
            }
            if (NoteSubcategory != null)
            {
                doc += "Подкатегории дохода:\r\n\r\n";
                foreach (var cat in NoteSubcategory.AboutInSubcategorys)
                {
                    doc += cat.name + "   " + cat.sum + " руб.   (" + Math.Round(cat.percent,2) + " %)\r\n";
                }
                doc += "\r\n";
                doc += "Подкатегории расхода:\r\n\r\n";
                foreach (var cat in NoteSubcategory.AboutExSubcategorys)
                {
                    doc += cat.name + "   " + cat.sum + " руб.   (" + Math.Round(cat.percent,2) + " %)\r\n";
                }
                doc += "\r\n-------------------------------------------------------------------\r\n\r\n";
            }
            if(NoteValuta != null)
            {
                doc += "Процентное соотношения использования валют:\r\n\r\n";
                foreach (var val in NoteValuta.AboutValutas)
                {
                    doc += val.name + "   (" + Math.Round(val.percent,2) + " %)\r\n";
                }
                doc += "\r\n-------------------------------------------------------------------\r\n\r\n";
            }
            if (NoteAccount != null)
            {
                doc += "Процентное соотношения использования счетов:\r\n\r\n";
                foreach (var acc in NoteAccount.AboutAccounts)
                {
                    doc += acc.name + "   (" + Math.Round(acc.percent,2) + " %)\r\n";
                }
                doc += "\r\n-------------------------------------------------------------------\r\n\r\n";
            }
            return doc;
        }
    }

    abstract class ReportBuilder 
    {
        public Controller cntrl { get; set; }
        public string Username { get; set; }
        public Report Report { get; set; }
        public void CreateReport()
        {
            Report = new Report();
        }
        public abstract void SetNoteExpenseAndIncome();
        public abstract void SetNoteCategory();
        public abstract void SetNoteSubcategory();
        public abstract void SetNoteValuta();
        public abstract void SetNoteAccount();

        public ReportBuilder(string username)
        {
            Username = username;
            cntrl = new Controller();
        }

    }

    class ExtendedMonthBuilder : ReportBuilder
    {
        public DateTime Fromdate { get; set; }
        DateTime Todate { get; set; }

        public ExtendedMonthBuilder (string username) : base(username)
        {
            Fromdate = DateTime.Today;
            Fromdate = Fromdate.AddDays(-(Fromdate.Day - 1));
            Todate = Fromdate.AddMonths(1).AddDays(-1);
        }

        public override void SetNoteExpenseAndIncome()
        {    
            Report.NoteExpenseAndIncome = new NoteExpenseAndIncome();
            Report.NoteExpenseAndIncome.TotalExpense = cntrl.getTotalSumExpense(Username, Fromdate, Todate);
            Report.NoteExpenseAndIncome.ToTalIncome = cntrl.getTotalSumIncome(Username, Fromdate, Todate);
        }
        public override void SetNoteCategory()
        {
            Report.NoteCategory = new NoteCategory();
            Report.NoteCategory.AboutExCategorys = cntrl.getListExCategoryInfo(Username, Fromdate, Todate);
            Report.NoteCategory.AboutInCategorys = cntrl.getListInCategoryInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteSubcategory()
        {
            Report.NoteSubcategory = new NoteSubcategory();
            Report.NoteSubcategory.AboutExSubcategorys = cntrl.getListExSubcategoryInfo(Username, Fromdate, Todate);
            Report.NoteSubcategory.AboutInSubcategorys = cntrl.getListInSubcategoryInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteValuta()
        {
            Report.NoteValuta = new NoteValuta();
            Report.NoteValuta.AboutValutas = cntrl.getListValutaInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteAccount()
        {
            Report.NoteAccount = new NoteAccount();
            Report.NoteAccount.AboutAccounts = cntrl.getListAccountInfo(Username, Fromdate, Todate);
        }
    }

    class ExtendedYearBuilder : ReportBuilder
    {
        public DateTime Fromdate { get; set; }
        DateTime Todate { get; set; }

        public ExtendedYearBuilder(string username) : base(username)
        {
            Fromdate = new DateTime(DateTime.Now.Year, 1, 1);
            Todate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            Todate = Todate.AddDays(-1);
        }

        public override void SetNoteExpenseAndIncome()
        {
            Report.NoteExpenseAndIncome = new NoteExpenseAndIncome();
            Report.NoteExpenseAndIncome.TotalExpense = cntrl.getTotalSumExpense(Username, Fromdate, Todate);
            Report.NoteExpenseAndIncome.ToTalIncome = cntrl.getTotalSumIncome(Username, Fromdate, Todate);
        }
        public override void SetNoteCategory()
        {
            Report.NoteCategory = new NoteCategory();
            Report.NoteCategory.AboutExCategorys = cntrl.getListExCategoryInfo(Username, Fromdate, Todate);
            Report.NoteCategory.AboutInCategorys = cntrl.getListInCategoryInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteSubcategory()
        {
            Report.NoteSubcategory = new NoteSubcategory();
            Report.NoteSubcategory.AboutExSubcategorys = cntrl.getListExSubcategoryInfo(Username, Fromdate, Todate);
            Report.NoteSubcategory.AboutInSubcategorys = cntrl.getListInSubcategoryInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteValuta()
        {
            Report.NoteValuta = new NoteValuta();
            Report.NoteValuta.AboutValutas = cntrl.getListValutaInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteAccount()
        {
            Report.NoteAccount = new NoteAccount();
            Report.NoteAccount.AboutAccounts = cntrl.getListAccountInfo(Username, Fromdate, Todate);
        }
    }

    class SimpleMonthBuilder : ReportBuilder
    {
        public DateTime Fromdate { get; set; }
        DateTime Todate { get; set; }

        public SimpleMonthBuilder(string username) : base(username)
        {
            Fromdate = DateTime.Today;
            Fromdate = Fromdate.AddDays(-(Fromdate.Day - 1));
            Todate = Fromdate.AddMonths(1).AddDays(-1);
        }

        public override void SetNoteExpenseAndIncome()
        {
            Report.NoteExpenseAndIncome = new NoteExpenseAndIncome();
            Report.NoteExpenseAndIncome.TotalExpense = cntrl.getTotalSumExpense(Username, Fromdate, Todate);
            Report.NoteExpenseAndIncome.ToTalIncome = cntrl.getTotalSumIncome(Username, Fromdate, Todate);
        }
        public override void SetNoteCategory()
        {
            Report.NoteCategory = new NoteCategory();
            Report.NoteCategory.AboutExCategorys = cntrl.getListExCategoryInfo(Username, Fromdate, Todate);
            Report.NoteCategory.AboutInCategorys = cntrl.getListInCategoryInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteSubcategory() { }

        public override void SetNoteValuta() { }

        public override void SetNoteAccount() { }

    }

    class SimpleYearBuilder : ReportBuilder
    {
        public DateTime Fromdate { get; set; }
        DateTime Todate { get; set; }

        public SimpleYearBuilder(string username) : base(username)
        {
            Fromdate = new DateTime(DateTime.Now.Year, 1, 1);
            Todate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            Todate = Todate.AddDays(-1);
        }

        public override void SetNoteExpenseAndIncome()
        {
            Report.NoteExpenseAndIncome = new NoteExpenseAndIncome();
            Report.NoteExpenseAndIncome.TotalExpense = cntrl.getTotalSumExpense(Username, Fromdate, Todate);
            Report.NoteExpenseAndIncome.ToTalIncome = cntrl.getTotalSumIncome(Username, Fromdate, Todate);
        }
        public override void SetNoteCategory()
        {
            Report.NoteCategory = new NoteCategory();
            Report.NoteCategory.AboutExCategorys = cntrl.getListExCategoryInfo(Username, Fromdate, Todate);
            Report.NoteCategory.AboutInCategorys = cntrl.getListInCategoryInfo(Username, Fromdate, Todate);
        }
        public override void SetNoteSubcategory() { }

        public override void SetNoteValuta() { }

        public override void SetNoteAccount() { }
    }

}
