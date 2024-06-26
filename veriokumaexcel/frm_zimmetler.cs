using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriokumaexcel
{

    public partial class frm_zimmetler : Form
    {
        private int zimmetID;
        private Form existingFormZimmetFiltre;
        private Form existingFormZimmetKayit;
        DateTime now;

        // Mesaj içeriğini oluştur
        string nowdate;
        public frm_zimmetler()
        {
            InitializeComponent();
        }

        public void gridViewRefresh()
        {
            dgZimmetler.Columns["dbserino"].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
            dgZimmetler.Columns["birim"].DefaultCellStyle.BackColor = Color.LightCyan;
            dgZimmetler.Columns["dbmarkamodel"].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
            dgZimmetler.Columns["teslimalansicil"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgZimmetler.Columns["teslimalanadsoyad"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgZimmetler.Columns["teslimalanunvan"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgZimmetler.Columns["teslimedensicil"].DefaultCellStyle.BackColor = Color.LightCyan;
            dgZimmetler.Columns["teslimedenadsoyad"].DefaultCellStyle.BackColor = Color.LightCyan;
            dgZimmetler.Columns["teslimedenunvan"].DefaultCellStyle.BackColor = Color.LightCyan;
            dgZimmetler.Columns["aciklama"].DefaultCellStyle.BackColor = Color.LightYellow;
            dgZimmetler.Columns["dem_no"].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 204);
            dgZimmetler.DefaultCellStyle.Font = new Font("Arial", 11);
            dgZimmetler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frm_zimmetler_Load(object sender, EventArgs e)
        {
            
            try
            {
                cbSyfismi.DataSource = Hiyerarsi.turlerListesi;
                dgZimmetler.DataSource = null;
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = zimmetler.dtZimmetler;

                bindingSource.Filter = "";

                // DataGridView'i yeniden bağla
                dgZimmetler.DataSource = bindingSource;
                gridViewRefresh();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (existingFormZimmetKayit == null || existingFormZimmetKayit.IsDisposed)
            {
                existingFormZimmetKayit = new frm_zimmetKayit();
                existingFormZimmetKayit.Show();
            }
            else
            {
                existingFormZimmetKayit.BringToFront();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("verileri kaydetmek istediğinize emin misiniz? \nzimmetler.csv üzerine yazılacak", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                csvSaving.saveCSV_zimmetler();
            }
            else if (result == DialogResult.No)
            {

            }

        }


        private void dgZimmetler_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen hücrenin bulunduğu satırı al
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçildiğinden emin olun
            {
                try
                {
                    DataGridViewRow selectedRow = dgZimmetler.Rows[e.RowIndex];

                    object zidValue = selectedRow.Cells["zid"].Value;
                    if (zidValue != null)
                    {
                        zimmetID = int.Parse(zidValue.ToString());
                        label3.Text = zimmetID.ToString();
                        label7.Text = (e.RowIndex+1).ToString();
                    }
                    
                }
                catch (Exception ex)
                {}

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (zimmetID > 0)
            {
                zimmet z = zimmetler.zimmetBul_IDile(zimmetID);
                if (z != null)
                {
                    Raporla(z);
                }
                else
                {
                    MessageBox.Show("Bu zimmet tanımsız");
                }
                
            }
        }
        private void ExcelApp_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook wb, ref bool Cancel)
        {

        }

        private void Raporla(zimmet z)
        {
            string excelFilePath = System.Windows.Forms.Application.StartupPath + "/excel/zimmetfisi.xlsx";
            
            try
            {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);

            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;

                if (z != null)
                {
                    string teslimalanadsoyad = z.PERteslimAlan.adsoyad;
                    string teslimalansicilno = z.PERteslimAlan.sicil;
                    string teslimalanunvan = z.PERteslimAlan.unvan;
                    string teslimedenunvan = z.PERteslimEden.unvan;
                    string teslimedensicilno = z.PERteslimEden.sicil;
                    string teslimedenadsoyad = z.PERteslimEden.adsoyad;
                    string serino = z.URUN.serino.ToString();
                    string markamodel = z.zimmetlenenUrunMarkaModel;
                    string birim = z.zimmetbirim;
                    string dem_no = z.URUN.dem_no;

                    worksheet.Cells[22, 7].Value = teslimalanadsoyad;
                    worksheet.Cells[23, 7].Value = teslimalansicilno;
                    worksheet.Cells[24, 7].Value = teslimalanunvan;
                    worksheet.Cells[24, 3].Value = teslimedenunvan;
                    worksheet.Cells[23, 3].Value = teslimedensicilno;
                    worksheet.Cells[22, 3].Value = teslimedenadsoyad;
                    worksheet.Cells[11, 4].Value = serino;
                    worksheet.Cells[9, 4].Value = markamodel;
                    worksheet.Cells[6, 4].Value = birim;
                    //4,10
                    worksheet.Cells[4, 10].Value = dem_no;
                }
                else
                {
                    MessageBox.Show("Zimmet bulunamadı");
                }

                //6,4

            excelApp.Visible = true;
            }
            catch (Exception ex)
            {
            MessageBox.Show("Hata: " + ex.Message);

            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                kayitSil();
            }
            else if (result == DialogResult.No)
            {

            }
        }
        public void kayitSil()
        {
            string content=""; //log tutmak için içerik tutulacak
            keepLog log1 = new keepLog();
            try
            {
                zimmet z = zimmetler.zimmetBul_IDile(zimmetID);
                DataRow[] rows = zimmetler.dtZimmetler.Select("zid = '" + zimmetID + "'");
                if (z == null)
                {
                    MessageBox.Show("Kayıt bulunamadı");
                    Console.WriteLine("z null mu : " + (z == null).ToString() + "rows lenght: " + rows.Length.ToString());

                }
                else
                {
                    now = DateTime.Now;
                    nowdate = now.ToString("dd/MM/yyyy") + " - " + now.ToString("HH:mm:ss");
                    content = " (zimmet kaydı silindi - " + nowdate + ") \n" + z.zid + " - " + z.zimmetbirim + " - " + z.PERteslimAlan.adsoyad + " - " + z.PERteslimAlan.unvan + " - " + z.PERteslimAlan.sicil + " - " + z.URUN.dem_no + " - " + z.zimmetlenenUrunMarkaModel + " - " + z.URUN.serino + " - " + z.PERteslimEden.sicil + " - " + z.PERteslimEden.adsoyad + " - " + z.PERteslimEden.unvan + " - " + z.aciklama + "\n";
                    
                    z.URUN.zimmetalan = null;
                    zimmetler.ZimmetlerList.Remove(z);
                    
                    Console.WriteLine("Kayıt silindi");

                }

                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    zimmetler.dtZimmetler.Rows.Remove(row);
                    dgZimmetler.DataSource = zimmetler.dtZimmetler;
                    log1.addTxt("logs_zimmet.txt", content);
                    MessageBox.Show("Kayıt silindi");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgZimmetler_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            frm_gecmis f1 = new frm_gecmis();
            f1.Show();
        }

        private void dgZimmetler_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgZimmetler_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dgZimmetler_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgZimmetler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            label8.Text = (dgZimmetler.RowCount - 1).ToString() + " kayıt gösteriliyor";
        }

        private void dgZimmetler_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgZimmetler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            label8.Text = (dgZimmetler.RowCount-1).ToString() + " kayıt gösteriliyor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fn = txtDosyaadi.Text;
                string shname = cbSyfismi.Text;
                interactExcel.writeExcelFromDGView(dgZimmetler, fn, shname);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void dgZimmetler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FiltrelemeAc();

        }

        private void FiltrelemeAc()
        {
            if (existingFormZimmetFiltre == null || existingFormZimmetFiltre.IsDisposed)
            {
                existingFormZimmetFiltre = new frm_zimmetFiltre(this);
                existingFormZimmetFiltre.Show();
            }
            else
            {
                existingFormZimmetFiltre.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FiltreyiTemizle();
        }

        private void FiltreyiTemizle()
        {
            dgZimmetler.DataSource = null;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = zimmetler.dtZimmetler;

            bindingSource.Filter = "";

            dgZimmetler.DataSource = bindingSource;
            gridViewRefresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.WriteLine(zimmetler.debugZimmetTara());
        }

        private void cbSyfismi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
