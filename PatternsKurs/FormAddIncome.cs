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
    public partial class FormAddIncome : Form
    {
        Controller cntrl;
        public FormAddIncome()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void comboBoxCat_SelectedValueChanged(object sender, EventArgs e)
        {
            IncomeCategory in_cat = (IncomeCategory)comboBoxCat.SelectedItem;

            if(in_cat !=null)
            if (in_cat.IncomeSubcategorys.Count == 0)
            {
                comboBoxSubcat.Text = "";
                comboBoxSubcat.DataSource = new List<IncomeCategory>();
            }
            else
            {
                comboBoxSubcat.DataSource = in_cat.IncomeSubcategorys;
                comboBoxSubcat.ValueMember = "Id";
                comboBoxSubcat.DisplayMember = "Name";
            }
        }
    }
}
