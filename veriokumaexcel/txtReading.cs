using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace veriokumaexcel
{
    public static class txtReading
    {
        public static string dosyaYoluMarkalar = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txtdata/markalar.txt");
        public static string dosyaYoluModeller = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txtdata/modeller.txt");
        public static string dosyaYoluBirimler = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txtdata/birimler.txt");
        public static string dosyaYoluUnvanlar = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txtdata/unvanlar.txt");
        public static string dosyaYoluTurler = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "txtdata/demirbasturleri.txt");
        public static void unvanlarOku()
        {
            if (File.Exists(dosyaYoluUnvanlar))
            {
                string[] satirlar = File.ReadAllLines(dosyaYoluUnvanlar);

                foreach (string satir in satirlar)
                {
                    main.unvanlarStrList.Add(satir);
                }
            }
            else
            {
                Console.WriteLine("unvanlar.txt dosyası bulunamadı.");
            }
        }

        public static void birimlerOku()
        {
            if (File.Exists(dosyaYoluBirimler))
            {
                string[] satirlar = File.ReadAllLines(dosyaYoluBirimler);

                foreach (string satir in satirlar)
                {
                    main.birimlerStrList.Add(satir);
                }
            }
            else
            {
                Console.WriteLine("birimler.txt dosyası bulunamadı.");
            }
        }

        public static void modellerOku()
        {
            if (File.Exists(dosyaYoluModeller))
            {
                string[] satirlar = File.ReadAllLines(dosyaYoluModeller);
                string[] temp = new string[3];
                foreach (string satir in satirlar)
                {
                    temp = satir.Split(';'); //üçlü dizi [0] [1] [2]
                    tur turr = Hiyerarsi.turBul(temp[0]);
                    marka mar = Hiyerarsi.markaBul(turr,temp[1]);
                    if (turr != null && mar != null)
                    {
                        mar.aitModeller.Add(new model(mar, temp[2]));
                    }
                    else
                    {
                        MessageBox.Show("tür veya marka bulunamadı");
                    }

                }
            }
            else
            {
                Console.WriteLine("modeller.txt dosyası bulunamadı.");
            }
        }

        public static void markalarOku()
        {
            if (File.Exists(dosyaYoluMarkalar))
            {
                string[] satirlar = File.ReadAllLines(dosyaYoluMarkalar);
                string[] temp = new string[2]; 
                foreach (string satir in satirlar)
                {
                    temp = satir.Split(';');
                    tur turr = Hiyerarsi.turBul(temp[0]);
                    if (turr!=null)
                    {
                        turr.aitMarkalar.Add(new marka(temp[1],turr));
                    }
                    else
                    {
                        MessageBox.Show("Marka bulunamadı");
                    }

                }
            }
            else
            {
                Console.WriteLine("markalar.txt dosyası bulunamadı.");
            }
        }

        public static void turleriOku()
        {
            if (File.Exists(dosyaYoluTurler))
            {
                string[] satirlar = File.ReadAllLines(dosyaYoluTurler);

                foreach (string satir in satirlar)
                {
                    main.turlerStrList.Add(satir);
                    tur eklenecek = new tur(satir);
                    Hiyerarsi.turlerListesi.Add(eklenecek);
                }
            }
            else
            {
                Console.WriteLine("demirbasturleri.txt dosyası bulunamadı.");
            }
        }

    }
}
