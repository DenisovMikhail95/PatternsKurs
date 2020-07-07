using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace PatternsKurs
{
    class Controller
    {
        public List<Account> getAccountList(string user) //получить список счетов члена семьи
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.Accounts.Where(ac => ac.FamilyMember.Name == user).ToList();
        }

        public void addAccount(string name, string user)
        {
            MyDbContext db = MyDbContext.getInstance();

            Account account = new Account();
            account.Name = name;
            account.FamilyMember = db.FamilyMembers.Where(fm => fm.Name == user).FirstOrDefault();

            db.Accounts.Add(account);
            db.SaveChanges();

            MessageBox.Show("Новый счет добавлен!");
        }

        public void updateOneAccount (int id, string name)
        {
            MyDbContext db = MyDbContext.getInstance();
            Account income_category = db.Accounts.Find(id);
            income_category.Name = name;
            db.SaveChanges();
            MessageBox.Show("Счет успешно изменен!");
        }

        public void deleteAccount(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();

            MessageBox.Show("Аккаунт успешно удален!");
        }

        public List<Valuta> getValutaList() //получуить список зарегестрированных валют
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.Valutas.ToList();
        }

        public List<Valuta> getValutaFromCB()
        {
            List<Valuta> list_valuta = new List<Valuta>();
            try {
                DateTime now = DateTime.Now;
                string day = now.ToString("dd");
                string month = now.ToString("MM");
                string year = now.ToString("yyyy");
                var document = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + day + "/" + month + "/" + year);
                var element = document.Root.Elements();

                foreach (var el in element)
                {
                    list_valuta.Add(new Valuta { Name = el.Element("Name").Value, Rate = Convert.ToDouble(el.Element("Value").Value) });
                }         
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить список валют. Проверьте подключение к интернету.");
            }

            return list_valuta;
        }

        public void addValuta(string name, double rate)
        {
            MyDbContext db = MyDbContext.getInstance();

            Valuta valuta = new Valuta();
            valuta.Name = name;
            valuta.Rate = rate;

            db.Valutas.Add(valuta);
            db.SaveChanges();

            MessageBox.Show("Новая валюта добавлена!");
        }

        public void deleteValuta(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            Valuta valuta = db.Valutas.Find(id);
            db.Valutas.Remove(valuta);
            db.SaveChanges();

            MessageBox.Show("Валюта успешно удалена!");
        }

        public List<IncomeCategory> getIncomeCategoryList()
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.IncomeCategorys.ToList();
        }

        public IncomeCategory getOneIncomeCategory(int id)
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.IncomeCategorys.Where(inc => inc.Id == id).FirstOrDefault();
        }

        public void addIncomeCategory(string name)
        {
            MyDbContext db = MyDbContext.getInstance();

            IncomeCategory income_category = new IncomeCategory();
            income_category.Name = name;

            db.IncomeCategorys.Add(income_category);
            db.SaveChanges();

            MessageBox.Show("Новая категория дохода добавлена!");

        }

        public void updateOneIncomeCategory(int id, string name)
        {
            MyDbContext db = MyDbContext.getInstance();
            IncomeCategory income_category = db.IncomeCategorys.Find(id);
            income_category.Name = name;
            db.SaveChanges();
            MessageBox.Show("Категория успешно обновлена!");
        }

        public void deleteIncomeCategory(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            IncomeCategory income_category = db.IncomeCategorys.Find(id);
            db.IncomeCategorys.Remove(income_category);
            db.SaveChanges();

            MessageBox.Show("Категория успешно удалена!");
        }

        public List<IncomeSubcategory> getIncomeSubcategoryList()
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.IncomeSubcategorys.ToList();
        }

        public void addIncomeSubcategory(string name, int id_in_category)
        {
            MyDbContext db = MyDbContext.getInstance();

            IncomeSubcategory income_subcategory = new IncomeSubcategory();
            income_subcategory.Name = name;
            income_subcategory.IncomeCategoryId = id_in_category;

            db.IncomeSubcategorys.Add(income_subcategory);
            db.SaveChanges();

            MessageBox.Show("Новая подкатегория дохода добавлена!");

        }

        public void updateOneIncomeSubcategory(int id, string name)
        {
            MyDbContext db = MyDbContext.getInstance();
            IncomeSubcategory income_subcategory = db.IncomeSubcategorys.Find(id);
            income_subcategory.Name = name;
            db.SaveChanges();
            MessageBox.Show("Подкатегория успешно обновлена!");
        }

        public void deleteIncomeSubcategory(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            IncomeSubcategory income_subcategory = db.IncomeSubcategorys.Find(id);
            db.IncomeSubcategorys.Remove(income_subcategory);
            db.SaveChanges();

            MessageBox.Show("Подкатегория успешно удалена!");
        }



        public List<ExpenseCategory> getExpenseCategoryList()
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.ExpenseCategorys.ToList();
        }

        public ExpenseCategory getOneExpenseCategory(int id)
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.ExpenseCategorys.Where(exc => exc.Id == id).FirstOrDefault();
        }

        public void addExpenseCategory(string name)
        {
            MyDbContext db = MyDbContext.getInstance();

            ExpenseCategory expense_category = new ExpenseCategory();
            expense_category.Name = name;

            db.ExpenseCategorys.Add(expense_category);
            db.SaveChanges();

            MessageBox.Show("Новая категория расхода добавлена!");

        }

        public void updateOneExpenseCategory(int id, string name)
        {
            MyDbContext db = MyDbContext.getInstance();
            ExpenseCategory expense_category = db.ExpenseCategorys.Find(id);
            expense_category.Name = name;
            db.SaveChanges();
            MessageBox.Show("Категория успешно обновлена!");
        }

        public void deleteExpenseCategory(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            ExpenseCategory expense_category = db.ExpenseCategorys.Find(id);
            db.ExpenseCategorys.Remove(expense_category);
            db.SaveChanges();

            MessageBox.Show("Категория успешно удалена!");
        }

        public List<ExpenseSubcategory> getExpenseSubcategoryList()
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.ExpenseSubcategorys.ToList();
        }

        public void addExpenseSubcategory(string name, int id_in_category)
        {
            MyDbContext db = MyDbContext.getInstance();

            ExpenseSubcategory expense_subcategory = new ExpenseSubcategory();
            expense_subcategory.Name = name;
            expense_subcategory.ExpenseCategoryId = id_in_category;

            db.ExpenseSubcategorys.Add(expense_subcategory);
            db.SaveChanges();

            MessageBox.Show("Новая подкатегория расхода добавлена!");
        }

        public void updateOneExpenseSubcategory(int id, string name)
        {
            MyDbContext db = MyDbContext.getInstance();
            ExpenseSubcategory expense_subcategory = db.ExpenseSubcategorys.Find(id);
            expense_subcategory.Name = name;
            db.SaveChanges();
            MessageBox.Show("Подкатегория успешно обновлена!");
        }

        public void deleteExpenseSubcategory(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            ExpenseSubcategory expense_subcategory = db.ExpenseSubcategorys.Find(id);
            db.ExpenseSubcategorys.Remove(expense_subcategory);
            db.SaveChanges();

            MessageBox.Show("Подкатегория успешно удалена!");
        }


        public List<ExpenseOutput> getExpenseListByParam(string user, string account, string valuta, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<Expense> expenses_list;
            List<ExpenseOutput> expenses_output = new List<ExpenseOutput>();

            if (account != "Все счета")
            {
                expenses_list = db.Expenses.Where(ex => ex.Account.FamilyMember.Name == user && ex.Account.Name == account && ex.Date >= from_date && ex.Date <= to_date).ToList();
            }
            else
            {
                expenses_list = db.Expenses.Where(ex => ex.Account.FamilyMember.Name == user && ex.Date >= from_date && ex.Date <= to_date).ToList();
            }

            Valuta vlt = db.Valutas.Where(v => v.Name == valuta).FirstOrDefault();

            foreach (var exp in expenses_list)
            {
                ExpenseOutput exp_out = new ExpenseOutput();
                exp_out.Id = exp.Id;
                exp_out.Date = exp.Date;
                exp_out.SumInValuta = exp.SumInValuta;
                exp_out.SumInCurValuta = Math.Round(exp.SumInRub / Convert.ToDecimal(vlt.Rate), 2);
                exp_out.Comment = exp.Comment;
                if (exp.ExpenseSubcategory != null)
                {
                    exp_out.ExpenseSubcategory = exp.ExpenseSubcategory.Name;
                    exp_out.ExpenseCategory = exp.ExpenseSubcategory.ExpenseCategory.Name;
                }
                exp_out.Account = exp.Account.Name;
                exp_out.Valuta = exp.Valuta.Name;

                expenses_output.Add(exp_out);
            }
            return expenses_output;
        }

        public void deleteExpense(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
            db.SaveChanges();

            MessageBox.Show("Расход успешно удален!");
        }

        public List<IncomeOutput> getIncomeListByParam(string user, string account, string valuta, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<Income> incomes_list;
            List<IncomeOutput> incomes_output = new List<IncomeOutput>();

            if (account != "Все счета")
            {
                incomes_list = db.Incomes.Where(inc => inc.Account.FamilyMember.Name == user && inc.Account.Name == account && inc.Date >= from_date && inc.Date <= to_date).ToList();
            }
            else
            {
                incomes_list = db.Incomes.Where(inc => inc.Account.FamilyMember.Name == user && inc.Date >= from_date && inc.Date <= to_date).ToList();
            }

            Valuta vlt = db.Valutas.Where(v => v.Name == valuta).FirstOrDefault();

            foreach (var inc in incomes_list)
            {
                IncomeOutput inc_out = new IncomeOutput();
                inc_out.Id = inc.Id;
                inc_out.Date = inc.Date;
                inc_out.SumInValuta = inc.SumInValuta;
                inc_out.SumInCurValuta = Math.Round(inc.SumInRub / Convert.ToDecimal(vlt.Rate), 2);
                inc_out.Comment = inc.Comment;
                if (inc.IncomeSubcategory != null)
                {
                    inc_out.IncomeSubcategory = inc.IncomeSubcategory.Name;
                    inc_out.IncomeCategory = inc.IncomeSubcategory.IncomeCategory.Name;
                }
                inc_out.Account = inc.Account.Name;
                inc_out.Valuta = inc.Valuta.Name;

                incomes_output.Add(inc_out);
            }
            return incomes_output;
        }

        public void deleteIncome(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            Income income = db.Incomes.Find(id);
            db.Incomes.Remove(income);
            db.SaveChanges();

            MessageBox.Show("Доход успешно удален!");
        }

        public double getBalance(string user, string account, string valuta, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<Income> income_list;
            List<Expense> expense_list;

            if (account != "Все счета")
            {
                income_list = db.Incomes.Where(inc => inc.Account.FamilyMember.Name == user && inc.Account.Name == account && inc.Date >= from_date && inc.Date <= to_date).ToList();
                expense_list = db.Expenses.Where(ex => ex.Account.FamilyMember.Name == user && ex.Account.Name == account && ex.Date >= from_date && ex.Date <= to_date).ToList();
            }
            else
            {
                income_list = db.Incomes.Where(inc => inc.Account.FamilyMember.Name == user && inc.Date >= from_date && inc.Date <= to_date).ToList();
                expense_list = db.Expenses.Where(ex => ex.Account.FamilyMember.Name == user && ex.Date >= from_date && ex.Date <= to_date).ToList();
            }

            Valuta vlt = db.Valutas.Where(v => v.Name == valuta).FirstOrDefault();

            double income_sum = 0, expense_sum = 0;

            foreach (var inc in income_list)
            {
                income_sum += Convert.ToDouble(inc.SumInRub) / vlt.Rate;      
            } 
            foreach (var exp in expense_list)
            {
                expense_sum += Convert.ToDouble(exp.SumInRub) / vlt.Rate;
            }

            return Math.Round(income_sum - expense_sum, 2);
        }

        public void addExpense(object subcategory, object account, object valuta, double summ, string comment)
        {
            MyDbContext db = MyDbContext.getInstance();
            Expense expense = new Expense()
            {
                Date = DateTime.Today,
                SumInValuta = Convert.ToDecimal(summ),
                Valuta = (Valuta)valuta,
                SumInRub = Convert.ToDecimal(summ * ((Valuta)valuta).Rate),
                ExpenseSubcategory = (ExpenseSubcategory)subcategory,
                Account = (Account)account,
                Comment = comment
            };

            db.Expenses.Add(expense);
            db.SaveChanges();
        }

        public void addIncome(object subcategory, object account, object valuta, double summ, string comment)
        {
            MyDbContext db = MyDbContext.getInstance();
            Income income = new Income()
            {
                Date = DateTime.Today,
                SumInValuta = Convert.ToDecimal(summ),
                Valuta = (Valuta)valuta,
                SumInRub = Convert.ToDecimal(summ * ((Valuta)valuta).Rate),
                IncomeSubcategory = (IncomeSubcategory)subcategory,
                Account = (Account)account,
                Comment = comment
            };

            db.Incomes.Add(income);
            db.SaveChanges();
        }

        public List<ReminderOutput> getReminderList(string username)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<Reminder> reminders = db.Reminders.Where(r => r.FamilyMember.Name == username).ToList();
            List<ReminderOutput> reminders_out = new List<ReminderOutput>();

            foreach (var rem in reminders)
            {
                ReminderOutput rem_out = new ReminderOutput();
                rem_out.Id = rem.Id;
                rem_out.Name = rem.Name;
                rem_out.RemindType = rem.RemindType.Name;
                rem_out.Comment = rem.Comment;
                if (rem.Date != DateTime.MaxValue.Date)
                    rem_out.Date = rem.Date;
                reminders_out.Add(rem_out);
            }
            return reminders_out;
        }

        public List<RemindType> getReminderTypeList()
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.RemindTypes.ToList();
        }

        public void addReminder(string name, string username, object type, DateTime date, string comment)
        {
            MyDbContext db = MyDbContext.getInstance();

            Reminder reminder = new Reminder();
            reminder.Name = name;
            reminder.RemindType = (RemindType)type;
            reminder.Comment = comment;
            reminder.FamilyMember = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();
            reminder.Date = date.Date;

            db.Reminders.Add(reminder);
            db.SaveChanges();

            MessageBox.Show("Новое напоминание добавлено!");
        }

        public Reminder getOneReminder(int id)
        {
            MyDbContext db = MyDbContext.getInstance();
            return db.Reminders.Where(r => r.Id == id).FirstOrDefault();
        }

        public void updateOneReminder(int id, string name, object type, DateTime date, string comment)
        {
            MyDbContext db = MyDbContext.getInstance();
            Reminder reminder = db.Reminders.Find(id);
            reminder.Name = name;
            reminder.RemindType = (RemindType)type;
            reminder.Comment = comment;
            reminder.Date = date.Date;
            db.SaveChanges();
            MessageBox.Show("Напоминание успешно изменено!");
        }
        public void deleteReminder(int id)
        {
            MyDbContext db = MyDbContext.getInstance();

            Reminder reminder = db.Reminders.Find(id);
            db.Reminders.Remove(reminder);
            db.SaveChanges();

            MessageBox.Show("Напоминание успешно удалено!");
        }

        public double getTotalSumExpense(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            decimal total = db.Expenses.Where(exp => exp.Account.FamilyMemberId == fam_member.Id && exp.Date >= from_date && exp.Date <= to_date).Sum(s => s.SumInRub);
            return Math.Round(Convert.ToDouble(total),2);          
        }

        public double getTotalSumIncome(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            decimal total = db.Incomes.Where(exp => exp.Account.FamilyMemberId == fam_member.Id && exp.Date >= from_date && exp.Date <= to_date).Sum(s => s.SumInRub);
            return Math.Round(Convert.ToDouble(total), 2);

        }

        public List<CategoryInfo> getListExCategoryInfo(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<CategoryInfo> list_cat_info = new List<CategoryInfo>();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            List<ExpenseCategory> expense_categorys = db.ExpenseCategorys.ToList();

            foreach (var exp_cat in expense_categorys)
            {
                CategoryInfo category_info = new CategoryInfo();
                category_info.name = exp_cat.Name;
                decimal total = 0;
                foreach (var exp_subcat in exp_cat.ExpenseSubcategorys)
                {
                    foreach (var exp in exp_subcat.Expenses)
                    {
                        if (exp.Date >= from_date && exp.Date <= to_date && exp.Account.FamilyMemberId == fam_member.Id)
                        {
                            total += exp.SumInRub;
                        }
                    }
                }
                category_info.sum = Convert.ToDouble(total);
                list_cat_info.Add(category_info);
            }

            double total_sum = list_cat_info.Sum(s => s.sum);
            foreach (var cat_info in list_cat_info)
            {
                cat_info.percent = (cat_info.sum / total_sum) * 100;
            }


            return list_cat_info;
        }


        public List<CategoryInfo> getListInCategoryInfo(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<CategoryInfo> list_cat_info = new List<CategoryInfo>();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            List<IncomeCategory> income_categorys = db.IncomeCategorys.ToList();

            foreach (var inc_cat in income_categorys)
            {
                CategoryInfo category_info = new CategoryInfo();
                category_info.name = inc_cat.Name;
                decimal total = 0;
                foreach (var inc_subcat in inc_cat.IncomeSubcategorys)
                {
                    foreach (var inc in inc_subcat.Incomes)
                    {
                        if (inc.Date >= from_date && inc.Date <= to_date && inc.Account.FamilyMemberId == fam_member.Id)
                        {
                            total += inc.SumInRub;
                        }
                    }
                }
                category_info.sum = Convert.ToDouble(total);
                list_cat_info.Add(category_info);
            }

            double total_sum = list_cat_info.Sum(s => s.sum);
            foreach (var cat_info in list_cat_info)
            {
                cat_info.percent = (cat_info.sum / total_sum) * 100;
            }
            return list_cat_info;
        }






        public List<CategoryInfo> getListExSubcategoryInfo(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<CategoryInfo> list_cat_info = new List<CategoryInfo>();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            List<ExpenseSubcategory> expense_subcategorys = db.ExpenseSubcategorys.ToList();

            
            foreach (var exp_subcat in expense_subcategorys)
            {
                CategoryInfo category_info = new CategoryInfo();
                category_info.name = exp_subcat.Name;
                decimal total = 0;

                foreach (var exp in exp_subcat.Expenses)
                {
                    if (exp.Date >= from_date && exp.Date <= to_date && exp.Account.FamilyMemberId == fam_member.Id)
                    {
                        total += exp.SumInRub;
                    }
                }
                category_info.sum = Convert.ToDouble(total);
                list_cat_info.Add(category_info);
            }

            double total_sum = list_cat_info.Sum(s => s.sum);
            foreach (var cat_info in list_cat_info)
            {
                cat_info.percent = (cat_info.sum / total_sum) * 100;
            }

            return list_cat_info;
        }

        public List<CategoryInfo> getListInSubcategoryInfo(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<CategoryInfo> list_cat_info = new List<CategoryInfo>();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            List<IncomeSubcategory> income_subcategorys = db.IncomeSubcategorys.ToList();


            foreach (var inc_subcat in income_subcategorys)
            {
                CategoryInfo category_info = new CategoryInfo();
                category_info.name = inc_subcat.Name;
                decimal total = 0;

                foreach (var inc in inc_subcat.Incomes)
                {
                    if (inc.Date >= from_date && inc.Date <= to_date && inc.Account.FamilyMemberId == fam_member.Id)
                    {
                        total += inc.SumInRub;
                    }
                }
                category_info.sum = Convert.ToDouble(total);
                list_cat_info.Add(category_info);
            }

            double total_sum = list_cat_info.Sum(s => s.sum);
            foreach (var cat_info in list_cat_info)
            {
                cat_info.percent = (cat_info.sum / total_sum) * 100;
            }

            return list_cat_info;
        }

        public List<ValutaAndAccountInfo> getListValutaInfo (string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<ValutaAndAccountInfo> list_valuta_info = new List<ValutaAndAccountInfo>();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            List<Valuta> valutas = db.Valutas.ToList();

            int count_in_ex = db.Expenses.Where(exp => exp.Account.FamilyMemberId == fam_member.Id && exp.Date >= from_date && exp.Date <= to_date).Count();
            count_in_ex += db.Incomes.Where(inc => inc.Account.FamilyMemberId == fam_member.Id && inc.Date >= from_date && inc.Date <= to_date).Count();

            foreach (var val in valutas)
            {
                ValutaAndAccountInfo valuta_info = new ValutaAndAccountInfo();
                valuta_info.name = val.Name;
                int val_count = val.Expenses.Where(exp => exp.Account.FamilyMemberId == fam_member.Id && exp.Date >= from_date && exp.Date <= to_date).Count();
                val_count += val.Incomes.Where(inc => inc.Account.FamilyMemberId == fam_member.Id && inc.Date >= from_date && inc.Date <= to_date).Count();

                valuta_info.percent = ((double)val_count / (double)count_in_ex) * 100;
                list_valuta_info.Add(valuta_info);
            }
            return list_valuta_info;
        }


        public List<ValutaAndAccountInfo> getListAccountInfo(string username, DateTime from_date, DateTime to_date)
        {
            MyDbContext db = MyDbContext.getInstance();
            List<ValutaAndAccountInfo> list_account_info = new List<ValutaAndAccountInfo>();
            FamilyMember fam_member = db.FamilyMembers.Where(fm => fm.Name == username).FirstOrDefault();

            List<Account> accounts = db.Accounts.Where(ac => ac.FamilyMember.Id == fam_member.Id).ToList();

            int count_in_ex = db.Expenses.Where(exp => exp.Account.FamilyMemberId == fam_member.Id && exp.Date >= from_date && exp.Date <= to_date).Count();
            count_in_ex += db.Incomes.Where(inc => inc.Account.FamilyMemberId == fam_member.Id && inc.Date >= from_date && inc.Date <= to_date).Count();

            foreach (var acc in accounts)
            {
                ValutaAndAccountInfo account_info = new ValutaAndAccountInfo();
                account_info.name = acc.Name;
                int acc_count = acc.Expenses.Where(exp => exp.Account.FamilyMemberId == fam_member.Id && exp.Date >= from_date && exp.Date <= to_date).Count();
                acc_count += acc.Incomes.Where(inc => inc.Account.FamilyMemberId == fam_member.Id && inc.Date >= from_date && inc.Date <= to_date).Count();

                account_info.percent = ((double)acc_count / (double)count_in_ex) * 100;
                list_account_info.Add(account_info);
            }
            return list_account_info;
        }



    }
}
