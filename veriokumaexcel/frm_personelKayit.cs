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
    public partial class frm_personelKayit : Form
    {
        private frm_personeller fmp;
        private Form existingFormunvanlarDuzenle;
        private Form existingFormbirimlerDuzenle;
        public frm_personelKayit(frm_personeller fm1)
        {
            InitializeComponent();
            fmp = fm1;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayit();
            fmp.filtreTemizle();

        }

        private void kayit()
        {
            try
            {
                if (personeller.isPersonelSicilExitsBool(txtSicil.Text) == true)
                {
                    MessageBox.Show("Bu sicil numarasına sahip personel zaten kayıtlarda mevcut");
                }
                else
                {
                    personel p = new personel();
                    p.pid = personeller.getMaxPID() + 1;
                    p.adsoyad = txtAdsoyad.Text;
                    p.unvan = cbUnvan.Text;
                    p.sicil = txtSicil.Text;
                    p.birimad = cbBirim.Text;
                    personeller.PersonellerList.Add(p);
                    
                    DataRow newRow = personeller.dtPersoneller.NewRow();
                    newRow["pid"] = p.pid;
                    newRow["adsoyad"] = p.adsoyad;
                    newRow["unvan"] = p.unvan;
                    newRow["sicil"] = p.sicil;
                    newRow["birim"] = p.birimad;

                    // Satırı DataTable'a ekle
                    personeller.dtPersoneller.Rows.Add(newRow);
                    MessageBox.Show("Personel kaydı eklendi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frm_personelKayit_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string s in main.birimlerStrList)
                {
                    cbBirim.Items.Add(s);
                }
                foreach (string x in main.unvanlarStrList)
                {
                    cbUnvan.Items.Add(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (existingFormunvanlarDuzenle == null || existingFormunvanlarDuzenle.IsDisposed)
            {
                existingFormunvanlarDuzenle = new frm_unvanlarDuzenle();
                existingFormunvanlarDuzenle.Show();
            }
            else
            {
                existingFormunvanlarDuzenle.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (existingFormbirimlerDuzenle == null || existingFormbirimlerDuzenle.IsDisposed)
            {
                existingFormbirimlerDuzenle = new frm_birimlerDuzenle();
                existingFormbirimlerDuzenle.Show();
            }
            else
            {
                existingFormbirimlerDuzenle.BringToFront();
            }
        }
    }
}
