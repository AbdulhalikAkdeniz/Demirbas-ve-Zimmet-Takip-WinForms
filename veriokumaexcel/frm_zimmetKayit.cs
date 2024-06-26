using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace veriokumaexcel
{
    public partial class frm_zimmetKayit : Form
    {
        private Form existingFormbirimlerDuzenle;
        private string parca;
        private string temp;
        private int seciliTablo;
        DateTime now;

        string nowdate;

        public frm_zimmetKayit()
        {
            InitializeComponent();
        }

        private void zimmetKayit_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 11);
            try
            {

                cbTanimla();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void cbTanimla()
        {
            List<string> birimlerListe = main.birimlerStrList.ToList();
            cbBirimler.DataSource = birimlerListe;
            cbBirimler.Text = "";
        }
        

        private void tablodanSecDB()
        {
            seciliTablo = 1;
            dataGridView1.DataSource = personeller.dtPersoneller;//null
            txtArama.Text = "";
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = degiskenDemirbaslar.dtOlusturZimmetlenecek();

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tablodanSecDB();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            
            string aramaMetni = txtArama.Text.ToLower();
            try
            {

                if (seciliTablo == 1)
                {
                    main.anlikFiltre(txtArama.Text, degiskenDemirbaslar.dtOlusturZimmetlenecek(), dataGridView1);
                    
                }
                else if (seciliTablo == 2)
                {
                    DataView dv = personeller.dtPersoneller.DefaultView;
                    dv.RowFilter = string.Format("birim LIKE 'BİLGİ İŞLEM ŞEFLİĞİ' AND pid LIKE '%{0}%' OR adsoyad LIKE '%{0}%' OR unvan LIKE '%{0}%' OR sicil LIKE '%{0}%'", aramaMetni);

                    dataGridView1.DataSource = dv;
                    
                }
                else if (seciliTablo == 3)
                {
                    main.anlikFiltre(txtArama.Text, personeller.dtPersoneller, dataGridView1);
                    
                }
            }
            catch (Exception exx)
            {

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            seciliTablo = 2;
            BindingSource bindingSource = new BindingSource();
            DataTable dtTemp = personeller.dtPersoneller.Copy();
            bindingSource.DataSource = dtTemp;

            bindingSource.Filter = "birim LIKE 'BİLGİ İŞLEM ŞEFLİĞİ'";
            
            dataGridView1.DataSource = bindingSource; 

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //dataGridView1.Visible = true;
            seciliTablo = 3;
            dataGridView1.DataSource = degiskenDemirbaslar.dtOlusturZimmetlenecek(); //null
            txtArama.Text = ""; 
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = personeller.dtPersoneller;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ZKayit_Click(object sender, EventArgs e)
        {
            if (cbBirimler.Text.Length < 1)
            {
                MessageBox.Show("Zimmet birimi boş bırakılamaz.");
                return;
            }
            //null nesne hatası
            //eğer bir ürün zaten zimmetlenmişse kayıta izin vermesin
            string content;
            keepLog l1 = new keepLog();
            zimmet arananZimmet = zimmetler.mevcutMuUrun_Zimmetler(txtSerino.Text);
            if ( arananZimmet == null)
            {

                zimmet z = new zimmet();
                string aranacakSicilTeslimEden = txtTeslimEdenSicilNo.Text;
                string aranacakSicilTeslimAlan = txtTeslimAlanSicilNo.Text;
                string aranacakSeriNoUrun = txtSerino.Text;
                personel teslimEden = personeller.personelBul(aranacakSicilTeslimEden);
                personel teslimAlan = personeller.personelBul(aranacakSicilTeslimAlan);
                urun zimmetlenecekUrun = demirbaslar.urunBul(aranacakSeriNoUrun);
                
                if (teslimEden != null && teslimAlan != null && zimmetlenecekUrun != null)
                {
                    z.zid = zimmetler.getMaxZID() + 1;
                    z.zimmetbirim = cbBirimler.Text;
                    z.aciklama = txtAciklama.Text;
                    z.zimmetlenenUrunMarkaModel = (zimmetlenecekUrun.marka + " " + zimmetlenecekUrun.model);
                    z.URUN = zimmetlenecekUrun;
                    z.PERteslimAlan = teslimAlan;
                    z.PERteslimEden = teslimEden;
                    zimmetler.ZimmetlerList.Add(z);
                    now = DateTime.Now;
                    nowdate = now.ToString("dd/MM/yyyy") + " - " + now.ToString("HH:mm:ss");
                    content = " (zimmet kaydı eklendi - " +nowdate + ") \n" + z.zid + " - " + z.zimmetbirim + " - " + z.PERteslimAlan.adsoyad + " - " + z.PERteslimAlan.unvan + " - " + z.PERteslimAlan.sicil + " - " + z.URUN.dem_no + " - " + z.zimmetlenenUrunMarkaModel + " - " + z.URUN.serino + " - " + z.PERteslimEden.sicil + " - " + z.PERteslimEden.adsoyad + " - " + z.PERteslimEden.unvan + " - " + z.aciklama + "\n";

                    zimmetlenecekUrun.zimmetalan = teslimAlan;

                    // Yeni bir satır oluşturun ve değerlerini ayarlayın
                    DataRow newRow = zimmetler.dtZimmetler.NewRow();
                    newRow["zid"] = z.zid;//main.getMaxZID() + 1;
                    newRow["birim"] = z.zimmetbirim;
                    newRow["teslimalansicil"] = z.PERteslimAlan.sicil;//txtTeslimAlanSicilNo.Text;
                    newRow["teslimalanadsoyad"] = z.PERteslimAlan.adsoyad;//txtTeslimAlanADSOYAD.Text;
                    newRow["teslimalanunvan"] = z.PERteslimAlan.unvan;// txtTeslimAlanUnvan.Text;
                    newRow["dem_no"] = z.URUN.dem_no;//cbSerino.Text;
                    newRow["dbserino"] = z.URUN.serino;//cbSerino.Text;
                    newRow["dbmarkamodel"] = (zimmetlenecekUrun.marka + " " + zimmetlenecekUrun.model);
                    newRow["teslimedenadsoyad"] = z.PERteslimEden.adsoyad;// txtTeslimEdenADSOYAD.Text;
                    newRow["teslimedensicil"] = z.PERteslimEden.sicil; // txtTeslimEdenSicilNo.Text;
                    newRow["teslimedenunvan"] = z.PERteslimEden.unvan; //cbTeslimEdenUnvan.Text;
                    newRow["aciklama"] = z.aciklama;

                    // Satırı DataTable'a ekle
                    zimmetler.dtZimmetler.Rows.Add(newRow);
                    MessageBox.Show("Zimmet kaydı eklendi, zid:"+z.zid, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    l1.addTxt("logs_zimmet.txt",content);
                    tablodanSecDB();
                }
                else
                {
                    MessageBox.Show("Zimmet eklenirken hata oluştu, verileri kontrol ediniz");
                }
            }
            else
            {
                MessageBox.Show("Bu ürün önceden zimmetlenmiş \n" + arananZimmet.zimmetlenenUrunMarkaModel + " - " + arananZimmet.URUN.serino + "\nTeslim alan: " + arananZimmet.PERteslimAlan.adsoyad + " - " + arananZimmet.PERteslimAlan.sicil + "\nTeslim eden: " + arananZimmet.PERteslimEden.adsoyad + " - " + arananZimmet.PERteslimEden.sicil + "\nZimmet ID: "+arananZimmet.zid);
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void cbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen hücrenin bulunduğu satırı al
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçildiğinden emin olun
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    if (seciliTablo == 1)
                    {
                        txtMarka.Text = selectedRow.Cells["marka"].Value.ToString();
                        txtModel.Text = selectedRow.Cells["model"].Value.ToString();
                        txtSerino.Text = selectedRow.Cells["serino"].Value.ToString();
                        label13.Text = selectedRow.Cells["dem_no"].Value.ToString();
                        
                    }
                    else if (seciliTablo == 2) //teslimeden
                    {
                        txtTeslimEdenADSOYAD.Text = selectedRow.Cells["adsoyad"].Value.ToString();
                        txtTeslimEdenUnvan.Text = selectedRow.Cells["unvan"].Value.ToString();
                        txtTeslimEdenSicilNo.Text = selectedRow.Cells["sicil"].Value.ToString();
                    }
                    else if (seciliTablo == 3) //teslimalan
                    {
                        txtTeslimAlanADSOYAD.Text = selectedRow.Cells["adsoyad"].Value.ToString();
                        txtTeslimAlanUnvan.Text = selectedRow.Cells["unvan"].Value.ToString();
                        txtTeslimAlanSicilNo.Text = selectedRow.Cells["sicil"].Value.ToString();
                    }
                    dataGridView1.DataSource = null;
                    SystemSounds.Beep.Play();
                    

                }
                catch (Exception ex)
                {
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label13_TextChanged(object sender, EventArgs e)
        {
            if (label13.Text.Length > 10)
            {
                label13.Text = label13.Text.Substring(0, 10);
            }
            else
            {
                label13.Text = label13.Text;
            }
        }

    }
}
