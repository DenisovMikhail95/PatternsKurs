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
    public partial class FormEditRemind : Form
    {
        public FormEditRemind()
        {
            InitializeComponent();
        }

        private void comboBoxType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((RemindType)comboBoxType.SelectedItem).Id == 1)
            {
                dateTimePicker1.Enabled = false;
            }
            else
                dateTimePicker1.Enabled = true;
        }
    }
}
