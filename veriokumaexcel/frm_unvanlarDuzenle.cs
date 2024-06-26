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
    public partial class frm_unvanlarDuzenle : Form
    {
        public frm_unvanlarDuzenle()
        {
            InitializeComponent();
        }

        private void frm_unvanlarDuzenle_Load(object sender, EventArgs e)
        {
            try { listBox1.DataSource = main.unvanlarStrList.ToList(); }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = main.unvanlarStrList.Contains(textBox1.Text, StringComparer.OrdinalIgnoreCase);

                if (!found)
                {
                    main.unvanlarStrList.Add(textBox1.Text);
                    listBox1.DataSource = null;
                    listBox1.DataSource = main.unvanlarStrList.ToList();
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Bu veri zaten mevcut");
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Seçili öğeyi silmek istediğinize emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string temp = listBox1.SelectedItem.ToString();
                    main.unvanlarStrList.Remove(temp);
                    listBox1.DataSource = null;
                    listBox1.DataSource = main.unvanlarStrList.ToList();
                }
            }
            catch (Exception Ex) {
                Console.WriteLine(Ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kaydetmek istediğinize emin misiniz?, 'unvanlar.txt' dosyasına yazılacak", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                csvSaving.saveTxt(main.unvanlarStrList, Application.StartupPath + "/txtdata/unvanlar.txt");
                MessageBox.Show("Veriler kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
