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
    public partial class frm_kayitlimarkamodeller : Form
    {
        
        frm_urunKayit fUkayit;
        public frm_kayitlimarkamodeller(frm_urunKayit fUkayit)
        {
            InitializeComponent();
            this.fUkayit = fUkayit;

        }

        private void frm_kayitlimarkamodeller_Load(object sender, EventArgs e)
        {
            doldur_lbturler();

        }

        private void visibleMarkaModelPaneller(bool deger)
        {
            try
            {
                panel_markaKisim.Visible = deger;
                panel_modelKisim.Visible = deger;
                txtModel.Text = "";
                txtMarka.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void visibleModelPanel(bool deger)
        {
            try
            {
                panel_modelKisim.Visible = deger;
                txtModel.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            
        }
        private void lb_markalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lb_markalar.SelectedIndex != -1)
                {
                    visibleModelPanel(true);
                    string secili_tur = lb_turler.SelectedItem.ToString();
                    string secili_marka = lb_markalar.SelectedItem.ToString();
                    
                    lb_modeller.DataSource = null;
                    lb_modeller.DataSource = Hiyerarsi.getModeller(secili_marka,secili_tur);
                }
                else
                {
                    visibleModelPanel(false);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void lb_modeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lb_modeller.SelectedIndex != -1)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        private void button1_Click(object sender, EventArgs e) 
        {
            try
            {
                string eklenecek_marka = txtMarka.Text;
                tur seciliTur = (tur)lb_turler.SelectedItem;
                marka aranan = seciliTur.markaBul(eklenecek_marka);
                if (aranan == null && seciliTur != null)
                {
                    marka eklenecekMarka = new marka(eklenecek_marka, seciliTur);
                    List<marka> liste = Hiyerarsi.getMarkalar(seciliTur.ToString());
                    if (liste != null)
                    {
                        liste.Add(eklenecekMarka);
                        lb_modeller.DataSource = null;
                        lb_markalar.DataSource = null;
                        lb_markalar.DataSource = liste;
                        lb_markalar.SelectedIndex = lb_markalar.Items.Count - 1;
                    }

                }
                else
                {
                    MessageBox.Show("Bu marka zaten kayıtlarda mevcut");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            


        }

        private void btnModelEkle_Click(object sender, EventArgs e)
        {
            try
            {
                tur secili_tur = (tur)lb_turler.SelectedItem;
                marka seciliMarka = (marka)lb_markalar.SelectedItem;
                string eklenecek_model = txtModel.Text;
                model aranan = Hiyerarsi.modelBul(secili_tur, seciliMarka, eklenecek_model);

                if (aranan == null && seciliMarka != null)
                {
                    model eklenecekModel = new model(seciliMarka, eklenecek_model);
                    List<model> liste = Hiyerarsi.getModeller(seciliMarka.ToString(), secili_tur.ToString());
                    if (liste != null)
                    {
                        liste.Add(eklenecekModel);
                        lb_modeller.DataSource = null;
                        lb_modeller.DataSource = liste;
                        lb_modeller.SelectedIndex = lb_modeller.Items.Count - 1;
                    }

                }
                else
                {
                    MessageBox.Show("Bu model zaten kayıtlarda mevcut");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }

        private void button5_Click(object sender, EventArgs e) //btn KAYDET
        {

            DialogResult result = MessageBox.Show("Kaydetmek istediğinize emin misiniz? veriler 'markalar.txt' ve 'modeller.txt' dosyasına yazılacak", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {

                    dosyayaKaydet_TurMarkaModel();
                    MessageBox.Show("Veriler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void dosyayaKaydet_TurMarkaModel()
            {
                try
                {
                string dosyaYoluTur = Application.StartupPath + "/txtdata/demirbasturleri.txt";
                    string dosyaYoluMarka = Application.StartupPath + "/txtdata/markalar.txt";
                    string dosyaYoluModel = Application.StartupPath + "/txtdata/modeller.txt";

                    HashSet<string> turlerSet = new HashSet<string>();
                    HashSet<string> markalarSet = new HashSet<string>();
                    HashSet<string> modellerSet = new HashSet<string>();

                    foreach (tur t in Hiyerarsi.turlerListesi)
                    {
                    turlerSet.Add(t.turismi);
                        foreach (marka mar in t.aitMarkalar)
                        {
                            string satirMarka = string.Format("{0};{1}", t.turismi, mar.markaismi);
                            markalarSet.Add(satirMarka);
                            foreach (model mod in mar.aitModeller)
                            {
                                string satirModel = string.Format("{0};{1};{2}", t.turismi, mar.markaismi,mod.modelismi);
                                modellerSet.Add(satirModel);
                            }
                        }
                    //
                }
                    File.WriteAllLines(dosyaYoluTur, turlerSet);
                    File.WriteAllLines(dosyaYoluMarka, markalarSet);
                    File.WriteAllLines(dosyaYoluModel, modellerSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosyaya kaydedilirken hata oluştu.", "Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        private void button3_Click(object sender, EventArgs e) //marka sil
        {
            try
            {
                DialogResult result = MessageBox.Show("Seçili markayı silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (lb_markalar.SelectedIndex != -1)
                    {
                        string secili_tur = lb_turler.SelectedItem.ToString();
                        marka seciliMarka = (marka)lb_markalar.SelectedItem;
                        Hiyerarsi.getMarkalar(secili_tur).Remove(seciliMarka);
                        //
                        lb_markalar.DataSource = null;
                        lb_markalar.DataSource = Hiyerarsi.getMarkalar(secili_tur);
                        lb_modeller.DataSource = null;
                    }
                    MessageBox.Show("Marka silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
                    

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void button4_Click(object sender, EventArgs e) //modelSil
        {
            try
            {
                DialogResult result = MessageBox.Show("Seçili modeli silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (lb_modeller.SelectedIndex != -1)
                    {
                        string secili_tur = lb_turler.SelectedItem.ToString();
                        string secili_marka = lb_markalar.SelectedItem.ToString();
                        model seciliModel = (model)lb_modeller.SelectedItem;
                        Hiyerarsi.getModeller(secili_marka, secili_tur).Remove(seciliModel);
                        //
                        lb_modeller.DataSource = null;
                        lb_modeller.DataSource = Hiyerarsi.getModeller(secili_marka, secili_tur);
                    }
                    MessageBox.Show("Model silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                  
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        private void button2_Click(object sender, EventArgs e) //btn_turekle
        {
            try
            {
                string eklenecek_tur = txtTur.Text;
                tur aranan = Hiyerarsi.turBul(eklenecek_tur);
                if (aranan == null)
                {
                    tur eklenecekTur = new tur(eklenecek_tur);
                    Hiyerarsi.turlerListesi.Add(eklenecekTur);
                    
                    lb_modeller.DataSource = null;
                    lb_markalar.DataSource = null;
                    lb_turler.DataSource = null;
                    lb_turler.DataSource = Hiyerarsi.turlerListesi;
                    lb_turler.SelectedIndex = lb_turler.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Bu demirbaş türü kayıtlarda zaten mevcut");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            
        }

        private void button1_Click_1(object sender, EventArgs e) //btn_turSil
        {
            try
            {
                DialogResult result = MessageBox.Show("Bu demirbaş türünü silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (lb_turler.SelectedIndex != -1)
                    {
                        tur secili_tur = (tur)lb_turler.SelectedItem;
                        Hiyerarsi.turlerListesi.Remove(secili_tur);
                        lb_turler.DataSource = null;
                        lb_turler.DataSource = Hiyerarsi.turlerListesi;
                        lb_markalar.DataSource = null;
                        lb_modeller.DataSource = null;
                    }
                    MessageBox.Show("Demirbaş türü silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                

                    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        private void lb_turler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lb_turler.SelectedIndex != -1)
                {
                    visibleMarkaModelPaneller(true);
                    string secili_tur = lb_turler.SelectedItem.ToString();
                    lb_modeller.DataSource = null;
                    lb_markalar.DataSource = null;

                    lb_markalar.DataSource = Hiyerarsi.getMarkalar(secili_tur);
                }
                else
                {
                    visibleMarkaModelPaneller(false);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void doldur_lbturler()
        {
            lb_turler.Items.Clear();
            try
            {
                lb_turler.DataSource = Hiyerarsi.getTurler();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
