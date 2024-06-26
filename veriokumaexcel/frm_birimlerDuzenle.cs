using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriokumaexcel
{
    public partial class frm_birimlerDuzenle : Form
    {
        string temp;
        public frm_birimlerDuzenle()
        {
            InitializeComponent();
        }

        private void frm_birimlerDuzenle_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = main.birimlerStrList.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool found = main.birimlerStrList.Contains(textBox1.Text, StringComparer.OrdinalIgnoreCase);

            if (!found)
            {
                main.birimlerStrList.Add(textBox1.Text);
                listBox1.DataSource = null;
                listBox1.DataSource = main.birimlerStrList.ToList();
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Bu öğe zaten mevcut");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçili öğeyi silmek istediğinize emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string temp = listBox1.SelectedItem.ToString();
                main.birimlerStrList.Remove(temp);
                listBox1.DataSource = null;
                listBox1.DataSource = main.birimlerStrList.ToList();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kaydetmek istediğinize emin misiniz?, 'birimler.txt' dosyasına yazılacak", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                csvSaving.saveTxt(main.birimlerStrList, Application.StartupPath + "/txtdata/birimler.txt");
                MessageBox.Show("Veriler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
        }
    }
}
