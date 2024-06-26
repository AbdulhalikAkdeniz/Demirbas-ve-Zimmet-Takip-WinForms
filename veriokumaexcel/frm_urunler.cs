using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace veriokumaexcel
{
    public partial class frm_urunler : Form
    {
        private int urunID=0;
        private Form1 fm;
        private Form existingFormurunKayit;
        public frm_urunler(Form1 fm1)
        {
            fm = fm1;
            InitializeComponent();
        }


        private void frm_urunler_Load(object sender, EventArgs e)
        {
            try {

                dGridUrunler.DataSource = demirbaslar.dtUrunler;
                dGridUrunler.DefaultCellStyle.Font = new Font("Arial", 11);
                dGridUrunler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                txtTur.AutoCompleteCustomSource.AddRange(main.turlerStrList.ToArray());
                txtMarka.AutoCompleteCustomSource.AddRange(main.sadecemarkaStrList.ToArray());
                txtSerino.AutoCompleteCustomSource.AddRange(main.serinoStrList.ToArray());
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e) //verileri kaydet csv
        {
            DialogResult result = MessageBox.Show("verileri kaydetmek istediğinize emin misiniz? \ndemirbaslar.csv üzerine yazılacak", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                csvSaving.saveCSV_urunler();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (existingFormurunKayit == null || existingFormurunKayit.IsDisposed)
            {
                existingFormurunKayit = new frm_urunKayit(this);
                existingFormurunKayit.Show();
            }
            else
            {
                existingFormurunKayit.BringToFront();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                kayitSil();
            }
        }

        public void kayitSil()
        {
            try
            {
                urun u = demirbaslar.urunBul_IDile(urunID);
                if (u != null)
                {
                    demirbaslar.UrunlerList.Remove(u);
                    MessageBox.Show("Kayıt silindi");
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı");
                }
                DataRow[] rows = demirbaslar.dtUrunler.Select("uid = '" + urunID + "'");
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    demirbaslar.dtUrunler.Rows.Remove(row);
                    dGridUrunler.DataSource = demirbaslar.dtUrunler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kayitGuncelle();
        }
        public void kayitGuncelle()
        {
            try
            {
                //
                urun u = demirbaslar.urunBul_IDile(urunID);
                if (u != null)
                {
                    u.marka = txtMarka.Text;
                    u.model = txtModel.Text;
                    u.serino = txtSerino.Text;
                    u.tur = txtTur.Text;
                    u.dem_no = txt_demno.Text;
                    MessageBox.Show("Kayıt güncellendi");
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı");
                    
                }


                DataRow[] rows = demirbaslar.dtUrunler.Select("uid = '" + urunID.ToString() + "'");
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    row["serino"] = txtSerino.Text;
                    row["marka"] = txtMarka.Text;
                    row["model"] = txtModel.Text;
                    row["tur"] = txtTur.Text;
                    row["dem_no"] = txt_demno.Text;
                }
                //
                DataTable beforeFilterTable = demirbaslar.dtUrunler;
                main.anlikFiltre("", beforeFilterTable, dGridUrunler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dGridUrunler_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen hücrenin bulunduğu satırı al
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçildiğinden emin olun
            {
                try
                {
                    DataGridViewRow selectedRow = dGridUrunler.Rows[e.RowIndex];

                    object uidValue = selectedRow.Cells["uid"].Value;
                    if (uidValue != null)
                    {
                        urunID = int.Parse(uidValue.ToString());
                        label4.Text = urunID.ToString();
                    }
                    txtTur.Text = selectedRow.Cells["tur"].Value.ToString();
                    txtMarka.Text = selectedRow.Cells["marka"].Value.ToString();
                    txtModel.Text = selectedRow.Cells["model"].Value.ToString();
                    txtSerino.Text = selectedRow.Cells["serino"].Value.ToString();
                    txt_demno.Text = selectedRow.Cells["dem_no"].Value.ToString();
                }
                catch (Exception ex)
                {
                    
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if(checkBox1.Checked == false)
            {
                DataTable beforeFilterTable = demirbaslar.dtUrunler;
                main.anlikFiltre(searchText, beforeFilterTable, dGridUrunler);
            }
            else
            {
                DataTable beforeFilterTable = degiskenDemirbaslar.dtOlusturZimmetlenecek();
                main.anlikFiltre(searchText, beforeFilterTable, dGridUrunler);
            }
            
        }

        private void dGridUrunler_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dGridUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            object dataSource = dGridUrunler.DataSource;

            if (dataSource is DataTable dataTable)
            {
                interactExcel.ConvertDataTableToExcelAndShow(dataTable);
            }
            else
            {
                Console.WriteLine("dGridUrunler'in veri kaynağı DataTable tipinde değil.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string searchText = "";
            if (checkBox1.Checked == false)
            {
                DataTable beforeFilterTable = demirbaslar.dtUrunler;
                main.anlikFiltre(searchText, beforeFilterTable, dGridUrunler);
            }
            else
            {
                DataTable beforeFilterTable = degiskenDemirbaslar.dtOlusturZimmetlenecek();
                main.anlikFiltre(searchText, beforeFilterTable, dGridUrunler);
            }
        }
    }
}
