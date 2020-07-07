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
    public partial class FormExCat : Form
    {
        Controller cntrl;
        public FormExCat()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void FormExCat_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cntrl.getExpenseCategoryList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEditExCat FrmEditExCat = new FormEditExCat();
            DialogResult result = FrmEditExCat.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                cntrl.addExpenseCategory(FrmEditExCat.textBox1.Text);

                dataGridView1.DataSource = cntrl.getExpenseCategoryList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                FormEditExCat FrmEditExCat = new FormEditExCat();

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                string name = dataGridView1[1, index].Value.ToString();

                FrmEditExCat.textBox1.Text = name;

                DialogResult result = FrmEditExCat.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    name = FrmEditExCat.textBox1.Text;
                    cntrl.updateOneExpenseCategory(id, name);

                    dataGridView1.DataSource = cntrl.getExpenseCategoryList();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить категорию?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                cntrl.deleteExpenseCategory(id);

                dataGridView1.DataSource = cntrl.getExpenseCategoryList();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                ExpenseCategory expense_category = cntrl.getOneExpenseCategory(id);
                dataGridView2.DataSource = expense_category.ExpenseSubcategorys;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                FormEditExSubcat FrmEditExSubcat = new FormEditExSubcat();

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);


                DialogResult result = FrmEditExSubcat.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    cntrl.addExpenseSubcategory(FrmEditExSubcat.textBox1.Text, id);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                FormEditExSubcat FrmEditExSubcat = new FormEditExSubcat();

                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                string name = dataGridView2[1, index].Value.ToString();

                FrmEditExSubcat.textBox1.Text = name;

                DialogResult result = FrmEditExSubcat.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    name = FrmEditExSubcat.textBox1.Text;
                    cntrl.updateOneExpenseSubcategory(id, name);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить подкатегорию?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            if (dataGridView2.SelectedRows.Count == 1)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);

                cntrl.deleteExpenseSubcategory(id);
            }
        }
    }
}
