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
    public partial class frm_urunKayit : Form
    {
        frm_urunler frmu;
        private string seciliMarka;
        private Form existingForm;
        public frm_urunKayit(frm_urunler frmu)
        {
            InitializeComponent();
            this.frmu = frmu;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            char firstChar = ' ';
            if (txt_demno.Text.Length > 0)
            {
                firstChar = txt_demno.Text[0];
            }
            if (cbTur.Text == "BİLGİSAYAR" && firstChar != 'B')
            {
                MessageBox.Show("BİLGİSAYAR türüne ait demirbaş numarası 'B' ile başlamalıdır.");
                return;
            }
            else if (cbTur.Text == "YAZICI" && firstChar != 'Y')
            {
                MessageBox.Show("YAZICI türüne ait demirbaş numarası 'Y' ile başlamalıdır.");
                return;
            }
            else if (cbTur.Text == "TARAYICI" && firstChar != 'T')
            {
                MessageBox.Show("TARAYICI türüne ait demirbaş numarası 'T' ile başlamalıdır.");
                return;
            }
            kayit();

        }
        private void kayit()
        {
            try
            {

                if (demirbaslar.isUrunSNOExitsBool(txtSerino.Text) == true)
                {
                    MessageBox.Show("Bu seri numaraya sahip demirbaş zaten kayıtlarda mevcut");
                    return;

                }
                else if (demirbaslar.isUrundemNOExitsBool(txt_demno.Text) == true)
                {
                    MessageBox.Show("Bu demirbaş numarasına sahip kayıt zaten mevcut");
                    return;
                }
                else
                {
                    urun u = new urun();
                    u.uid = demirbaslar.getMaxUID() + 1;
                    u.marka = cbMarka.Text;
                    u.model = cbModel.Text;
                    u.serino = txtSerino.Text;
                    u.tur = cbTur.Text;
                    u.dem_no = txt_demno.Text;
                    demirbaslar.UrunlerList.Add(u);
                    
                    DataRow newRow = demirbaslar.dtUrunler.NewRow();
                    newRow["uid"] = u.uid; 
                    newRow["tur"] = u.tur;
                    newRow["serino"] = u.serino; 
                    newRow["marka"] = u.marka; 
                    newRow["model"] = u.model; 
                    newRow["dem_no"] = u.dem_no;

                    // Satırı DataTable'a ekle
                    demirbaslar.dtUrunler.Rows.Add(newRow);
                    MessageBox.Show("Demirbaş kaydı başarıyla eklendi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frm_urunKayit_Load(object sender, EventArgs e)
        {
            try
            {
                cbTur.DataSource = null;
                cbTur.DataSource = Hiyerarsi.turlerListesi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                marka seciliMarka = (marka)cbMarka.SelectedItem;
                cbModel.Text = "";
                if (seciliMarka != null && cbMarka.SelectedIndex != -1)
                {
                    cbModel.DataSource = seciliMarka.aitModeller;
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (existingForm == null || existingForm.IsDisposed)
            {
                existingForm = new frm_kayitlimarkamodeller(this);
                existingForm.Show();
            }
            else
            {
                existingForm.BringToFront();
            }


        }

        private void cbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            tur seciliTur = (tur)cbTur.SelectedItem;
            cbMarka.Text = "";
            cbModel.Text = "";
            if (seciliTur != null && cbTur.SelectedIndex != -1)
            {
                cbMarka.DataSource = null;
                cbMarka.DataSource = seciliTur.aitMarkalar;
            }
            if (cbTur.Text == "BİLGİSAYAR")
            {
                txt_demno.Text = "B";
            }
            else if (cbTur.Text == "YAZICI")
            {
                txt_demno.Text = "Y";
            }
            else if (cbTur.Text == "TARAYICI")
            {
                txt_demno.Text = "T";
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSerino_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSerino_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void txtSerino_Leave(object sender, EventArgs e)
        {
            txtSerino.Text = txtSerino.Text.ToUpper();
        }

        private void txt_demno_Leave(object sender, EventArgs e)
        {
            txt_demno.Text = txt_demno.Text.ToUpper();
        }
    }
}
