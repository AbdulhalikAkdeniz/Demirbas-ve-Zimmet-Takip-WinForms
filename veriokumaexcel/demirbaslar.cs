using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriokumaexcel
{
    internal class demirbaslar
    {
        public static DataTable dtUrunler = new DataTable();
        public static List<urun> UrunlerList = new List<urun>();
        public static BindingSource bndSrc_Demirbaslar = new BindingSource();
        public static void Olustur_UrunlerListFromDT()
        {
            try
            {
                string deger;
                UrunlerList = new List<urun>();
                for (int i = 0; i < dtUrunler.Rows.Count; i++)
                {
                    urun tempObjUrun = new urun();
                    deger = dtUrunler.Rows[i]["uid"].ToString();
                    tempObjUrun.uid = int.Parse(deger);

                    tempObjUrun.tur = dtUrunler.Rows[i]["tur"].ToString();
                    tempObjUrun.marka = dtUrunler.Rows[i]["marka"].ToString();
                    tempObjUrun.model = dtUrunler.Rows[i]["model"].ToString();
                    tempObjUrun.serino = dtUrunler.Rows[i]["serino"].ToString();
                    tempObjUrun.dem_no = dtUrunler.Rows[i]["dem_no"].ToString();
                    UrunlerList.Add(tempObjUrun);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static bool isUrunSNOExitsBool(string sno)
        {
            foreach (urun u in UrunlerList)
            {
                if (String.Equals(u.serino, sno, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isUrundemNOExitsBool(string dem_no)
        {
            foreach (urun u in UrunlerList)
            {
                if (String.Equals(u.dem_no, dem_no, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public static urun urunBul(string sno)
        {
            foreach (urun u in UrunlerList)
            {
                if (String.Equals(u.serino, sno, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                {
                    return u;
                }
            }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }


        public static urun urunBul_IDile(int uid)
        {
            foreach (urun u in UrunlerList)
            {
                if (u.uid == uid)
                {
                    return u;
                }
            }

            return null;
        }

        public static void csvLoadUrunToNewDataTable()
        {
            try
            {
                dtUrunler = new DataTable();
                using (StreamReader reader = new StreamReader(main.CSVUrunlerFileName, Encoding.UTF8))
                {
                    string[] headers = reader.ReadLine().Split(';'); // Noktalı virgülle ayrıldığını belirtin
                    foreach (string header in headers)
                    {
                        if (header == "uid")
                        {
                            try { dtUrunler.Columns.Add("uid", typeof(Int32)); } catch (Exception ex) { }
                        }
                        else
                        {
                            dtUrunler.Columns.Add(header);
                        }

                    }

                    while (!reader.EndOfStream)
                    {
                        try { string[] rows = reader.ReadLine().Split(';'); dtUrunler.Rows.Add(rows); }
                        catch (Exception ex) { }


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static int getMaxUID()
        {
            int maxUid = 0;

            foreach (urun u in UrunlerList)
            {
                int currentUid = u.uid;
                if (currentUid > maxUid)
                {
                    maxUid = currentUid;
                }
            }

            return maxUid;
        }

    }
}
