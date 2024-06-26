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
    public partial class frm_gecmis : Form
    {
        public frm_gecmis()
        {
            InitializeComponent();
        }

        private void frm_gecmis_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            readLog();
         }

        private void sonSatir()
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }
        private void readLog()
        {
            keepLog log1 = new keepLog();
            richTextBox1.Text = log1.readTxt("logs_zimmet.txt");
            sonSatir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Zimmet geçmişini temizlemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                keepLog log1 = new keepLog();
                log1.clearTxt("logs_zimmet.txt");
                richTextBox1.Text = "";
                MessageBox.Show("Zimmet geçmişi silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            readLog();
        }
    }
}
