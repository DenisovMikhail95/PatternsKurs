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
    public partial class FormAddExpense : Form
    {
        Controller cntrl;
        public FormAddExpense()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void comboBoxCat_SelectedValueChanged(object sender, EventArgs e)
        {
            ExpenseCategory ex_cat = (ExpenseCategory)comboBoxCat.SelectedItem;

            if(ex_cat !=null)
            if (ex_cat.ExpenseSubcategorys.Count == 0 )
            {
                comboBoxSubcat.Text = "";
                comboBoxSubcat.DataSource = new List<ExpenseCategory>();
            }
            else
            {
                comboBoxSubcat.DataSource = ex_cat.ExpenseSubcategorys;
                comboBoxSubcat.ValueMember = "Id";
                comboBoxSubcat.DisplayMember = "Name";
            }

        }
    }
}
