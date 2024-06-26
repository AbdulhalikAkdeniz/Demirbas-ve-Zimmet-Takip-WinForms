using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriokumaexcel
{
    internal class FirstControl
    {
        public static string secilenKlasor;
        public static string klasorCSV;
        public static string klasorTXT;
        public static string csvPER_YOL;
        public static string csvDEM_YOL;
        public static string csvZIM_YOL;

        public static void dosyalariOlustur()
        {
            Console.WriteLine(csvPER_YOL);
            using (StreamWriter sw = new StreamWriter(csvPER_YOL, false, Encoding.UTF8))
            {
                sw.WriteLine("pid;adsoyad;unvan;sicil;birim"); // Sütun başlıkları
                Console.WriteLine("personeller.csv oluşturuldu");
            }

            using (StreamWriter sw = new StreamWriter(csvDEM_YOL, false, Encoding.UTF8))
            {
                sw.WriteLine("uid;tur;serino;marka;model;dem_no"); // Sütun başlıkları
                Console.WriteLine("demirbaslar.csv oluşturuldu");
            }

            using (StreamWriter sw = new StreamWriter(csvZIM_YOL, false, Encoding.UTF8))
            {
                sw.WriteLine("zid;birim;teslimalanadsoyad;teslimalanunvan;teslimalansicil;dem_no;dbmarkamodel;dbserino;teslimedensicil;teslimedenadsoyad;teslimedenunvan;aciklama"); // Sütun başlıkları
                Console.WriteLine("zimmetler.csv oluşturuldu");
            }

        }
        public static void denetim()
        {
            string cfgYol = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbdir.cfg");

            if (File.Exists(cfgYol))
            {
                //MessageBox.Show("dbdir.cfg dosyası mevcut.");
            }
            else
            {
                MessageBox.Show("Lütfen verilerin kaydedileceği klasörü seçiniz");
                using (var folderDialog = new FolderBrowserDialog())
                {
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        secilenKlasor = folderDialog.SelectedPath;
                        //string dosyaYolu2 = Path.Combine(secilenKlasor, "veri.txt");
                    }
                }
                klasorCSV = secilenKlasor + "\\orduzimmet\\vt\\";
                klasorTXT = secilenKlasor + "\\orduzimmet\\txtdata\\";
                Directory.CreateDirectory(klasorCSV);
                Directory.CreateDirectory(klasorTXT);
                csvPER_YOL = klasorCSV + "\\personeller.csv";
                csvDEM_YOL = klasorCSV + "\\demirbaslar.csv";
                csvZIM_YOL = klasorCSV + "\\zimmetler.csv";
                Console.WriteLine(klasorTXT);
                Console.WriteLine(klasorCSV);
                File.WriteAllText(cfgYol, secilenKlasor);
                Console.WriteLine("afdghfgf");
                dosyalariOlustur();
                //MessageBox.Show("dbdir.cfg dosyası oluşturuldu ve içeriği yazıldı.");
            }
        }


        public static void CSVdosyalarDenetim()
        {
            if (!File.Exists(csvPER_YOL))
            {
                using (StreamWriter sw = new StreamWriter(csvPER_YOL, false, Encoding.UTF8))
                {
                    sw.WriteLine("pid;adsoyad;unvan;sicil;birim"); // Sütun başlıkları
                    Console.WriteLine("personeller.csv oluşturuldu");
                }
            }

            if (!File.Exists(csvDEM_YOL))
            {
                using (StreamWriter sw = new StreamWriter(csvDEM_YOL, false, Encoding.UTF8))
                {
                    sw.WriteLine("uid;tur;serino;marka;model;dem_no"); // Sütun başlıkları
                    Console.WriteLine("demirbaslar.csv oluşturuldu");
                }
            }

            if (!File.Exists(csvZIM_YOL))
            {
                using (StreamWriter sw = new StreamWriter(csvZIM_YOL, false, Encoding.UTF8))
                {
                    sw.WriteLine("zid;birim;teslimalanadsoyad;teslimalanunvan;teslimalansicil;dem_no;dbmarkamodel;dbserino;teslimedensicil;teslimedenadsoyad;teslimedenunvan;aciklama"); // Sütun başlıkları
                    Console.WriteLine("zimmetler.csv oluşturuldu");
                }
            }

        }

        public static void txtDosyalarDenetim()
        {

        }

    }
}
