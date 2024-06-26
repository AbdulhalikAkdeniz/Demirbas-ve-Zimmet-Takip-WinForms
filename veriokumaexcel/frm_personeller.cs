using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace veriokumaexcel
{
    public partial class frm_personeller : Form
    {
        private int personelID = 0;
        private Form existingFormpersonelKayit;
        public frm_personeller()
        {
            InitializeComponent();
        }


        private void frm_personeller_Load(object sender, EventArgs e)
        {
            try {
                dGridPersoneller.DataSource = personeller.dtPersoneller;
                dGridPersoneller.DefaultCellStyle.Font = new Font("Arial", 11);
                dGridPersoneller.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                txtBirim.AutoCompleteCustomSource.AddRange(main.birimlerStrList.ToArray());
                txtUnvan.AutoCompleteCustomSource.AddRange(main.unvanlarStrList.ToArray());

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void filtreTemizle()
        {
            try
            {
                DataTable beforeFilterTable = personeller.dtPersoneller;
                main.anlikFiltre("", beforeFilterTable, dGridPersoneller);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBox5.Text.Trim();
                DataTable beforeFilterTable = personeller.dtPersoneller;
                main.anlikFiltre(searchText, beforeFilterTable, dGridPersoneller);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (existingFormpersonelKayit == null || existingFormpersonelKayit.IsDisposed)
                {
                    existingFormpersonelKayit = new frm_personelKayit(this);
                    existingFormpersonelKayit.Show();
                }
                else
                {
                    existingFormpersonelKayit.BringToFront();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


        }

        

        private void dGridPersoneller_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dGridPersoneller_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen hücrenin bulunduğu satırı al
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçildiğinden emin olun
            {
                try
                {
                    DataGridViewRow selectedRow = dGridPersoneller.Rows[e.RowIndex];

                    // Seçilen satırdaki verileri TextBox'lara yansıt
                    object pidValue = selectedRow.Cells["pid"].Value;
                    if (pidValue != null)
                    {
                        personelID = int.Parse(pidValue.ToString());
                        label5.Text = personelID.ToString();
                        // Dönüşüm başarılı, uygun işlemleri gerçekleştirin
                    }

                    txtAdsoyad.Text = selectedRow.Cells["adsoyad"].Value.ToString();
                    txtUnvan.Text = selectedRow.Cells["unvan"].Value.ToString();
                    txtSicil.Text = selectedRow.Cells["sicil"].Value.ToString();
                    txtBirim.Text = selectedRow.Cells["birim"].Value.ToString();
                }
                catch (Exception ex)
                {
                    
                }

            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("verileri kaydetmek istediğinize emin misiniz? \npersoneller.csv üzerine yazılacak", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    csvSaving.saveCSV_personeller();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


        }


        private void button7_Click(object sender, EventArgs e)
        {
            kayitGuncelle();
            filtreTemizle();
        }

        public void kayitGuncelle()
        {
            try
            {

                personel p = personeller.personelBul_IDile(personelID);
                if (p != null)
                {
                    p.adsoyad = txtAdsoyad.Text;
                    p.sicil = txtSicil.Text;
                    p.unvan = txtUnvan.Text;
                    p.birimad = txtBirim.Text;

                    MessageBox.Show("Kayıt güncellendi");
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı");
                }


                DataRow[] rows = personeller.dtPersoneller.Select("pid = '" + personelID.ToString() + "'");

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    row["adsoyad"] = txtAdsoyad.Text;
                    row["sicil"] = txtSicil.Text;
                    row["birim"] = txtBirim.Text;
                    row["unvan"] = txtUnvan.Text;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        public void kayitSil()
        {
            try
            {
                personel p = personeller.personelBul_IDile(personelID);
                if (p != null)
                {
                    personeller.PersonellerList.Remove(p);
                    MessageBox.Show("Kayıt silindi");
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı");
                }

                //

                DataRow[] rows = personeller.dtPersoneller.Select("pid = '" + personelID.ToString() + "'");
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    personeller.dtPersoneller.Rows.Remove(row);

                    // DataGridView'ı güncelle
                    dGridPersoneller.DataSource = personeller.dtPersoneller;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    kayitSil();
                    filtreTemizle();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            object dataSource = dGridPersoneller.DataSource;

            if (dataSource is DataTable dataTable)
            {
                interactExcel.ConvertDataTableToExcelAndShow(dataTable);
            }
            else
            {
                Console.WriteLine("dGridPersoneller'in veri kaynağı DataTable tipinde değil.");
            }
        }
    }
}
