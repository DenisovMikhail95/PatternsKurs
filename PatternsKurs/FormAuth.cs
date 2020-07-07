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
    public partial class FormAuth : Form
    {
        Form1 frm1;
        public FormAuth()
        {
            InitializeComponent();
            frm1 = new Form1(this);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            Authorizator authrz = new Authorizator();

            bool check_auth = authrz.authorizate(textBoxUserName.Text,textBoxUserPassw.Text);

            if (check_auth)
            {
                
                frm1.labelUser.Text = textBoxUserName.Text;
                frm1.Show();

                this.Hide(); //скрываем форму авторизации
            }
            else
            {
                textBoxUserPassw.Clear();
                MessageBox.Show("Неправильный логин или пароль!");
            }

        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            FormRegistration FormReg = new FormRegistration();
            FormReg.ShowDialog();
        }
    }
}
