using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Office.Interop.Excel;


namespace veriokumaexcel
{

    public partial class Form1 : Form
    {


        public string filePath = "ornek.csv";
        public string deneme = "";
        private Form existingFormurunler;
        private Form existingFormpersoneller;
        private Form existingFormzimmetler;
        private Form existingFormHakkinda;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FirstControl.denetim();

                demirbaslar.csvLoadUrunToNewDataTable();
                demirbaslar.Olustur_UrunlerListFromDT();

                personeller.csvLoadPersonelToNewDataTable();
                personeller.Olustur_PersonellerListFromDT();

                zimmetler.NewZimmetDataTableFromCSV();
                zimmetler.Olustur_ZimmetlerListFromDT();

                txtReading.turleriOku();
                txtReading.markalarOku();
                txtReading.modellerOku();
                txtReading.birimlerOku();
                txtReading.unvanlarOku();
                foreach (personel p in personeller.PersonellerList)
                {
                    main.adsoyadStrList.Add(p.adsoyad);
                    main.sicillerStrList.Add(p.sicil);
                }
                foreach (urun u in demirbaslar.UrunlerList)
                {
                    main.markamodelStrList.Add(u.marka + " " + u.model);
                    main.serinoStrList.Add(u.serino);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            if (existingFormurunler == null || existingFormurunler.IsDisposed)
            {
                existingFormurunler = new frm_urunler(this);
                existingFormurunler.Show();
            }
            else
            {
                existingFormurunler.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            urun u1;
            u1 = demirbaslar.urunBul(textBox1.Text);

            try
            {
                MessageBox.Show(u1.marka + " " + u1.model + " id " + u1.uid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (existingFormpersoneller == null || existingFormpersoneller.IsDisposed)
            {
                existingFormpersoneller = new frm_personeller();
                existingFormpersoneller.Show();
            }
            else
            {
                existingFormpersoneller.BringToFront();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                personel p1;
                p1 = personeller.personelBul(textBox1.Text);
                MessageBox.Show(p1.adsoyad + " " + p1.unvan + " " + p1.birimad + " pid " + p1.pid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (existingFormzimmetler == null || existingFormzimmetler.IsDisposed)
            {
                existingFormzimmetler = new frm_zimmetler();
                existingFormzimmetler.Show();
            }
            else
            {
                existingFormzimmetler.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int aranan = int.Parse(textBox3.Text);
                foreach (zimmet z in zimmetler.ZimmetlerList)
                {
                    Console.WriteLine(z.zid);
                    if (z.zid == aranan)
                    {
                        MessageBox.Show("zimmet bulundu: " + z.zimmetlenenUrunMarkaModel + " - " + z.PERteslimAlan.adsoyad);
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (existingFormHakkinda == null || existingFormHakkinda.IsDisposed)
            {
                existingFormHakkinda = new hakkinda();
                existingFormHakkinda.Show();
            }
            else
            {
                existingFormHakkinda.BringToFront();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            int uzunluk = zimmetler.ZimmetlerList.Count;
            MessageBox.Show(uzunluk.ToString());
            int sayac = 0;
            for (int i = 0; i < uzunluk; i++)
            {
                zimmet z = zimmetler.ZimmetlerList[i];
                Console.WriteLine(z.zid.ToString());
            }
            MessageBox.Show(sayac.ToString());

        }
      }
         
    }
