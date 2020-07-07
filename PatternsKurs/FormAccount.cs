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
    public partial class FormAccounts : Form
    {
        Controller cntrl;
        string username;
        public FormAccounts(string user)
        {
            InitializeComponent();
            username = user;
            cntrl = new Controller();
        }

        private void FormAccounts_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cntrl.getAccountList(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEditAccount FrmEditAccount = new FormEditAccount();
            DialogResult result = FrmEditAccount.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                cntrl.addAccount(FrmEditAccount.textBox1.Text, username);

                dataGridView1.DataSource = cntrl.getAccountList(username);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                FormEditAccount FrmEditAccount = new FormEditAccount();

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                string name = dataGridView1[1, index].Value.ToString();

                FrmEditAccount.textBox1.Text = name;

                DialogResult result = FrmEditAccount.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if (result == DialogResult.OK)
                {
                    name = FrmEditAccount.textBox1.Text;
                    cntrl.updateOneAccount(id, name);

                    dataGridView1.DataSource = cntrl.getAccountList(username);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить счет? Это приведет к удалению данных, связанных с этим счетом.", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.No)
                return;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                cntrl.deleteAccount(id);

                dataGridView1.DataSource = cntrl.getAccountList(username);
            }
        }
    }
}
