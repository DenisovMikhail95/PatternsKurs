using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternsKurs
{
    public partial class Form1 : Form
    {
        FormAuth FormAth;
        Controller cntrl;
        bool flag_data_selected = false;
        public Form1(FormAuth FA)
        {
            InitializeComponent();
            FormAth = FA;
            cntrl = new Controller();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //подгрузка комбобокса счета
            comboBoxAccounts.Text = "";
            List<Account> list_acc = cntrl.getAccountList(labelUser.Text);
            Account all_acc = new Account { Id = 0, Name = "Все счета" };
            list_acc.Insert(0, all_acc);
            comboBoxAccounts.DataSource = list_acc;
            comboBoxAccounts.ValueMember = "Id";
            comboBoxAccounts.DisplayMember = "Name";

            //подгрузка комбобокса валюты
            comboBoxValuta.DataSource = cntrl.getValutaList();
            comboBoxValuta.ValueMember = "Id";
            comboBoxValuta.DisplayMember = "Name";

            List<ReminderOutput> ListRem = cntrl.getReminderList(labelUser.Text);
            dataGridViewRem.DataSource = ListRem;
            dataGridViewRem.Columns[0].Visible = false;
            dataGridViewRem.Columns[1].HeaderText = "Название";
            dataGridViewRem.Columns[2].HeaderText = "Тип напоминания";
            dataGridViewRem.Columns[3].HeaderText = "Дата";
            dataGridViewRem.Columns[4].HeaderText = "Комментарий";

            radioButtonGeneral.Checked = Properties.Settings.Default.RBgeneral;
            radioButtonPersonal.Checked = Properties.Settings.Default.RBpersonal;
        }
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            updateDataGrids();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            radioButtonToday.Checked = false;
            radioButtonMonth.Checked = false;
            radioButtonWeek.Checked = false;
            radioButtonYear.Checked = false;
            radioButtonAllTime.Checked = false;
            flag_data_selected = true;
            updateDataGrids();
            
        }

        private void radioButtonAllTime_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllTime.Checked == true)
            {
                monthCalendar1.SetDate(DateTime.Now);
                flag_data_selected = false;
                updateDataGrids();
            }
        }
        
        private void radioButtonYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYear.Checked == true)
            {
                monthCalendar1.SetDate(DateTime.Now);
                flag_data_selected = false;
                updateDataGrids();
            }
        }

        private void radioButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMonth.Checked == true)
            {
                monthCalendar1.SetDate(DateTime.Now);
                flag_data_selected = false;
                updateDataGrids();
            }
        }

        private void radioButtonWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeek.Checked == true)
            {
                monthCalendar1.SetDate(DateTime.Now);
                flag_data_selected = false;
                updateDataGrids();
            }
        }

        private void radioButtonToday_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonToday.Checked == true)
            {
                monthCalendar1.SetDate(DateTime.Now);
                flag_data_selected = false;
                updateDataGrids();
            }
        }

        private void моиСчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAccounts FormAcc = new FormAccounts(labelUser.Text);
            FormAcc.Show();
        }

        private void категорииДоходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExCat FormExCat = new FormExCat();
            FormExCat.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void категорииРасходовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInCat FormInCat = new FormInCat();
            FormInCat.Show();
        }

        private void валютыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormValuta FormVlt = new FormValuta();
            FormVlt.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.RBgeneral = radioButtonGeneral.Checked;
            Properties.Settings.Default.RBpersonal = radioButtonPersonal.Checked;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAth.Show();//запуск формы авторизации
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddExpense FormAddEx = new FormAddExpense();

            List<ExpenseCategory> cat_list = cntrl.getExpenseCategoryList();
            
            List<Account> acc_list = cntrl.getAccountList(labelUser.Text);
            List<Valuta> valuta_list = cntrl.getValutaList();

            FormAddEx.comboBoxCat.DataSource = cat_list;
            FormAddEx.comboBoxCat.ValueMember = "Id";
            FormAddEx.comboBoxCat.DisplayMember = "Name";
            FormAddEx.comboBoxAcc.DataSource = acc_list;
            FormAddEx.comboBoxAcc.ValueMember = "Id";
            FormAddEx.comboBoxAcc.DisplayMember = "Name";
            FormAddEx.comboBoxVal.DataSource = valuta_list;
            FormAddEx.comboBoxVal.ValueMember = "Id";
            FormAddEx.comboBoxVal.DisplayMember = "Name";

            DialogResult result = FormAddEx.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                cntrl.addExpense(FormAddEx.comboBoxSubcat.SelectedItem, FormAddEx.comboBoxAcc.SelectedItem, FormAddEx.comboBoxVal.SelectedItem, Convert.ToDouble(FormAddEx.textBoxSum.Text), FormAddEx.textBoxComment.Text);
                updateDataGrids();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddIncome FormAddInc = new FormAddIncome();

            List<IncomeCategory> cat_list = cntrl.getIncomeCategoryList();

            List<Account> acc_list = cntrl.getAccountList(labelUser.Text);
            List<Valuta> valuta_list = cntrl.getValutaList();

            FormAddInc.comboBoxCat.DataSource = cat_list;
            FormAddInc.comboBoxCat.ValueMember = "Id";
            FormAddInc.comboBoxCat.DisplayMember = "Name";
            FormAddInc.comboBoxAcc.DataSource = acc_list;
            FormAddInc.comboBoxAcc.ValueMember = "Id";
            FormAddInc.comboBoxAcc.DisplayMember = "Name";
            FormAddInc.comboBoxVal.DataSource = valuta_list;
            FormAddInc.comboBoxVal.ValueMember = "Id";
            FormAddInc.comboBoxVal.DisplayMember = "Name";

            DialogResult result = FormAddInc.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                cntrl.addIncome(FormAddInc.comboBoxSubcat.SelectedItem, FormAddInc.comboBoxAcc.SelectedItem, FormAddInc.comboBoxVal.SelectedItem, Convert.ToDouble(FormAddInc.textBoxSum.Text), FormAddInc.textBoxComment.Text);
                updateDataGrids();
            }
        }

        public void updateDataGrids()
        {
            DateTime fromdate = new DateTime(), todate = new DateTime();

            if (radioButtonToday.Checked == true)
            {     
                fromdate = DateTime.Today; todate = DateTime.Today;
            }
            else if (radioButtonWeek.Checked == true)
            {
                fromdate = DateTime.Today;
                while (fromdate.DayOfWeek != System.DayOfWeek.Monday) { fromdate = fromdate.AddDays(-1); }
                todate = fromdate.AddDays(6);
            }
            else if (radioButtonMonth.Checked == true)
            {
                fromdate = DateTime.Today;
                fromdate = fromdate.AddDays(-(fromdate.Day - 1));
                todate = fromdate.AddMonths(1).AddDays(-1);
            }
            else if (radioButtonYear.Checked == true)
            {
                fromdate = new DateTime(DateTime.Now.Year, 1, 1);
                todate = new DateTime(DateTime.Now.Year + 1, 1, 1);
                todate = todate.AddDays(-1);
            }
            else if (radioButtonAllTime.Checked == true)
            {
                fromdate = DateTime.MinValue;
                todate = DateTime.Today;
            }
            else if (flag_data_selected == true)
            {
                fromdate = monthCalendar1.SelectionStart;
                todate = fromdate;
            }

            List<ExpenseOutput> listExp = cntrl.getExpenseListByParam(labelUser.Text, comboBoxAccounts.Text, comboBoxValuta.Text, fromdate, todate);
            dataGridViewEx.DataSource = listExp;
            dataGridViewEx.Columns[0].Visible = false;
            dataGridViewEx.Columns[1].HeaderText = "Дата";
            dataGridViewEx.Columns[2].HeaderText = "Сумма в текущей валюте";
            dataGridViewEx.Columns[3].HeaderText = "Валюта расхода";
            dataGridViewEx.Columns[4].HeaderText = "Сумма в валюте расхода";
            dataGridViewEx.Columns[5].HeaderText = "Категория расхода";
            dataGridViewEx.Columns[6].HeaderText = "Подкатегория расхода";
            dataGridViewEx.Columns[7].HeaderText = "Счет";
            dataGridViewEx.Columns[8].HeaderText = "Комментарий";

            List<IncomeOutput> listInc = cntrl.getIncomeListByParam(labelUser.Text, comboBoxAccounts.Text, comboBoxValuta.Text, fromdate, todate);
            dataGridViewIn.DataSource = listInc;
            dataGridViewIn.Columns[0].Visible = false;
            dataGridViewIn.Columns[1].HeaderText = "Дата";
            dataGridViewIn.Columns[2].HeaderText = "Сумма в текущей валюте";
            dataGridViewIn.Columns[3].HeaderText = "Валюта расхода";
            dataGridViewIn.Columns[4].HeaderText = "Сумма в валюте дохода";
            dataGridViewIn.Columns[5].HeaderText = "Категория дохода";
            dataGridViewIn.Columns[6].HeaderText = "Подкатегория дохода";
            dataGridViewIn.Columns[7].HeaderText = "Счет";
            dataGridViewIn.Columns[8].HeaderText = "Комментарий";

            List<ReminderOutput> ListRem = cntrl.getReminderList(labelUser.Text);
            dataGridViewRem.DataSource = ListRem;
            dataGridViewRem.Columns[0].Visible = false;
            dataGridViewRem.Columns[1].HeaderText = "Название";
            dataGridViewRem.Columns[2].HeaderText = "Тип напоминания";
            dataGridViewRem.Columns[3].HeaderText = "Дата";
            dataGridViewRem.Columns[4].HeaderText = "Комментарий";

            labelBalance.Text = Convert.ToString(cntrl.getBalance(labelUser.Text, comboBoxAccounts.Text, comboBoxValuta.Text, fromdate, todate));

        }

        private void comboBoxAccounts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDataGrids();
        }

        private void comboBoxValuta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDataGrids();
        }

        private void buttonDelExp_Click(object sender, EventArgs e)
        {
            if (dataGridViewEx.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить расход?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No)
                    return;

                int index = dataGridViewEx.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridViewEx[0, index].Value.ToString(), out id);

                cntrl.deleteExpense(id);

                updateDataGrids();
            }
        }

        private void buttonDelInc_Click(object sender, EventArgs e)
        {
            if (dataGridViewIn.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить доход?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No)
                    return;

                int index = dataGridViewIn.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridViewIn[0, index].Value.ToString(), out id);

                cntrl.deleteIncome(id);

                updateDataGrids();
            }
        }

        private void button3_Click(object sender, EventArgs e) //добавление напоминания
        {
            FormEditRemind FormEditRem = new FormEditRemind();

            FormEditRem.comboBoxType.DataSource = cntrl.getReminderTypeList();
            FormEditRem.comboBoxType.DisplayMember = "Name";
            FormEditRem.comboBoxType.ValueMember = "Id";

            DialogResult result = FormEditRem.ShowDialog(this);

            DateTime date;
            if (FormEditRem.dateTimePicker1.Enabled == false)
                date = DateTime.MaxValue;
            else
                date =FormEditRem.dateTimePicker1.Value;

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                cntrl.addReminder(FormEditRem.textBoxName.Text, labelUser.Text, FormEditRem.comboBoxType.SelectedItem, date, FormEditRem.textBoxComment.Text);
                updateDataGrids();
            }
        }

        private void button4_Click(object sender, EventArgs e) //изменение напоминания
        {
            if (dataGridViewRem.SelectedRows.Count == 1)
            {
                FormEditRemind FormEditRem = new FormEditRemind();

                int index = dataGridViewRem.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewRem[0, index].Value.ToString(), out id);

                Reminder rem = cntrl.getOneReminder(id);
                FormEditRem.comboBoxType.DataSource = cntrl.getReminderTypeList();
                FormEditRem.comboBoxType.DisplayMember = "Name";
                FormEditRem.comboBoxType.ValueMember = "Id";
                FormEditRem.comboBoxType.SelectedValue = rem.RemindType.Id;

                FormEditRem.textBoxName.Text = rem.Name;
                FormEditRem.textBoxComment.Text = rem.Comment;
                if(FormEditRem.dateTimePicker1.Enabled == true)
                    FormEditRem.dateTimePicker1.Value = rem.Date;

                DialogResult result = FormEditRem.ShowDialog(this);

                DateTime date;
                if (FormEditRem.dateTimePicker1.Enabled == false)
                    date = DateTime.MaxValue;
                else
                    date = FormEditRem.dateTimePicker1.Value;

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    cntrl.updateOneReminder(id, FormEditRem.textBoxName.Text, FormEditRem.comboBoxType.SelectedItem, date, FormEditRem.textBoxComment.Text);
                    updateDataGrids();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //удаление напоминания
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить напоминание?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            if (dataGridViewRem.SelectedRows.Count == 1)
            {
                int index = dataGridViewRem.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridViewRem[0, index].Value.ToString(), out id);

                cntrl.deleteReminder(id);

                updateDataGrids();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (radioButtonGeneral.Checked == true)
            {
                Notifier notifier = new Notifier(new GeneralStrategy());
                notifier.toNotify(labelUser.Text);
            }
            else if (radioButtonPersonal.Checked == true)
            {
                Notifier notifier = new Notifier(new PersonalStrategy());
                notifier.toNotify(labelUser.Text);
            }          
        }

        private void buttonShowRep_Click(object sender, EventArgs e)
        {
            FormReport FormRep = new FormReport();

            ReportBuilder report_builder = new ExtendedMonthBuilder(labelUser.Text);

            if (radioButtonExY.Checked == true)
            {
                report_builder = new ExtendedYearBuilder(labelUser.Text);
            }
            else if (radioButtonSmpM.Checked == true)
            {
                report_builder = new SimpleMonthBuilder(labelUser.Text);
            }
            else if(radioButtonSmpY.Checked == true)
            {
                report_builder = new SimpleYearBuilder(labelUser.Text);
            }

            //строим отчет
            report_builder.CreateReport();
            report_builder.SetNoteExpenseAndIncome();
            report_builder.SetNoteCategory();
            report_builder.SetNoteSubcategory();
            report_builder.SetNoteValuta();
            report_builder.SetNoteAccount();

            FormRep.textBoxReport.Text = report_builder.Report.Print();
            FormRep.Show();

        }

        private void tabPageRep_Click(object sender, EventArgs e)
        {

        }
    }
}
