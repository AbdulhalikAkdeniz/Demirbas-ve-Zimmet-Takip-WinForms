using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    internal class keepLog
    {
        public string readTxt(string filepath)
        {
            try
            {
                // Dosyayı açıp içeriğini okuma
                string content = File.ReadAllText(filepath);

                // Okunan içeriği ekrana yazdırma
                Console.WriteLine("Dosya İçeriği:");
                Console.WriteLine(content);
                return content;
            }
            catch (FileNotFoundException)
            {
                // Dosya bulunamazsa hata mesajı yazdırma
                Console.WriteLine("Dosya bulunamadı!");
            }
            catch (Exception ex)
            {
                // Diğer hatalar için genel hata mesajı yazdırma
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
            return "";
        }

        public void addTxt(string filepath,string content)
        {
            try
            {
                // Dosyanın sonuna içeriği ekleme
                File.AppendAllText(filepath, content + Environment.NewLine);

                // Ekleme işleminin başarıyla tamamlandığını bildirme
                Console.WriteLine("Dosyaya içerik eklendi.");
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajı yazdırma
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }

        public void clearTxt(string filepath)
        {
            try
            {
                // Dosyanın içeriğini temizleme
                File.WriteAllText(filepath, string.Empty);

                // Temizleme işleminin başarıyla tamamlandığını bildirme
                Console.WriteLine("Dosya içeriği temizlendi.");
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajı yazdırma
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }


    }
}
