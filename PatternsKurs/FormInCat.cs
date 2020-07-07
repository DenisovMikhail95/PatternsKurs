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
    public partial class FormInCat : Form
    {
        Controller cntrl;
        public FormInCat()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void FormInCat_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cntrl.getIncomeCategoryList();
        }
            
        private void button1_Click(object sender, EventArgs e) //добавление категории
        {
            FormEditInCat FrmEditInCat = new FormEditInCat();
            DialogResult result = FrmEditInCat.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                cntrl.addIncomeCategory(FrmEditInCat.textBox1.Text);

                dataGridView1.DataSource = cntrl.getIncomeCategoryList();
            }
        }

        private void button2_Click(object sender, EventArgs e) //обновление категории
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                FormEditInCat FrmEditInCat = new FormEditInCat();

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                string name = dataGridView1[1, index].Value.ToString();

                FrmEditInCat.textBox1.Text = name;

                DialogResult result = FrmEditInCat.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    name = FrmEditInCat.textBox1.Text;
                    cntrl.updateOneIncomeCategory(id, name);

                    dataGridView1.DataSource = cntrl.getIncomeCategoryList();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //удаление категории
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить категорию?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                cntrl.deleteIncomeCategory(id);

                dataGridView1.DataSource = cntrl.getIncomeCategoryList();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) 
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                IncomeCategory income_category = cntrl.getOneIncomeCategory(id);
                dataGridView2.DataSource = income_category.IncomeSubcategorys;
            }
        }

        private void button4_Click(object sender, EventArgs e) //добавление подкатегории
        {
            if (dataGridView1.SelectedRows.Count == 1) {
                FormEditInSubcat FrmEditInSubcat = new FormEditInSubcat();

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);


                DialogResult result = FrmEditInSubcat.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    cntrl.addIncomeSubcategory(FrmEditInSubcat.textBox1.Text,id);
                }


            }
        }

        private void button5_Click(object sender, EventArgs e) //изменение подкатегории
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                FormEditInSubcat FrmEditInSubcat = new FormEditInSubcat();

                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                string name = dataGridView2[1, index].Value.ToString();
                
                FrmEditInSubcat.textBox1.Text = name;

                DialogResult result = FrmEditInSubcat.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    name = FrmEditInSubcat.textBox1.Text;
                    cntrl.updateOneIncomeSubcategory(id, name);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //удаление подкатегории
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить подкатегорию?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            if (dataGridView2.SelectedRows.Count == 1)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);

                cntrl.deleteIncomeSubcategory(id);
            }
        }
    }
}
