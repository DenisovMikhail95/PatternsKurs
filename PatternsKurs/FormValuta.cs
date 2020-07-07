using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;


namespace PatternsKurs
{
    public partial class FormValuta : Form
    {
        Controller cntrl;
        public FormValuta()
        {
            InitializeComponent();
            cntrl = new Controller();
        }

        private void FormValuta_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void FormValuta_Activated(object sender, EventArgs e)
        {
            dataGridViewValuta.DataSource = cntrl.getValutaList();
        }

        private void button1_Click(object sender, EventArgs e) //добавление
        {
            FormEditValuta FormEdVal = new FormEditValuta();

            var valuta_list = cntrl.getValutaFromCB();
            FormEdVal.comboBoxValutas.DataSource = valuta_list;
            FormEdVal.comboBoxValutas.ValueMember = "Rate";
            FormEdVal.comboBoxValutas.DisplayMember = "Name";

            DialogResult result = FormEdVal.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if (result == DialogResult.OK)
            {
                Valuta added_valuta = (Valuta)FormEdVal.comboBoxValutas.SelectedItem;
                cntrl.addValuta(added_valuta.Name, added_valuta.Rate);

                dataGridViewValuta.DataSource = cntrl.getValutaList();
            }

        }

        private void button2_Click(object sender, EventArgs e) //удаление
        {
            if (dataGridViewValuta.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить валюту? Это удалит все данные доходы/расходы, связанные с этой валютой.", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No)
                    return;

                int index = dataGridViewValuta.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewValuta[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                cntrl.deleteValuta(id);

                dataGridViewValuta.DataSource = cntrl.getValutaList();
            }
        }


    }
}
