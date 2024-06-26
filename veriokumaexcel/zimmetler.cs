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
    internal class zimmetler
    {
        public static DataTable dtZimmetler = new DataTable();
        public static List<zimmet> ZimmetlerList = new List<zimmet>();

        public static void Olustur_ZimmetlerListFromDT()
        {
            try
            {
                ZimmetlerList = new List<zimmet>();

                for (int i = 0; i < dtZimmetler.Rows.Count; i++)
                {
                    zimmet tempObjZimmet = new zimmet();
                    string aranacakSicilTeslimEden = dtZimmetler.Rows[i]["teslimedensicil"].ToString();
                    string aranacakSicilTeslimAlan = dtZimmetler.Rows[i]["teslimalansicil"].ToString();
                    string aranacakSeriNoUrun = dtZimmetler.Rows[i]["dbserino"].ToString();
                    personel teslimEden = personeller.personelBul(aranacakSicilTeslimEden);
                    personel teslimAlan = personeller.personelBul(aranacakSicilTeslimAlan);
                    urun zimmetlenmisUrun = demirbaslar.urunBul(aranacakSeriNoUrun);

                    if (teslimEden != null && teslimAlan != null && zimmetlenmisUrun != null)
                    {
                        tempObjZimmet.zid = int.Parse(dtZimmetler.Rows[i]["zid"].ToString());
                        tempObjZimmet.URUN = zimmetlenmisUrun;
                        tempObjZimmet.PERteslimAlan = teslimAlan;
                        tempObjZimmet.PERteslimEden = teslimEden;
                        tempObjZimmet.zimmetlenenUrunMarkaModel = zimmetlenmisUrun.marka + " " + zimmetlenmisUrun.model;
                        tempObjZimmet.zimmetbirim = dtZimmetler.Rows[i]["birim"].ToString();
                        tempObjZimmet.aciklama = dtZimmetler.Rows[i]["aciklama"].ToString();
                        zimmetlenmisUrun.zimmetalan = teslimAlan;

                        ZimmetlerList.Add(tempObjZimmet);
                    }
                    else
                    {
                        int zid = -1;
                        int.TryParse(dtZimmetler.Rows[i]["zid"].ToString(), out zid);
                        Console.WriteLine("null değer zimmet id " + zid.ToString());
                        dtZimmet_SatirSil(zid);
                        //dtZimmet içerisinde satır silme işlemi
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void dtZimmet_SatirSil(int zimmetID)
        {
            DataRow[] rows = zimmetler.dtZimmetler.Select("zid = '" + zimmetID + "'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                dtZimmetler.Rows.Remove(row);
            }
        }
        public static zimmet mevcutMuUrun_Zimmetler(string sno)
        {
            foreach (zimmet z in ZimmetlerList)
            {
                if (String.Equals(z.URUN.serino, sno, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                {
                    return z;
                }
            }
            return null;
        }


        public static zimmet zimmetBul_IDile(int zid)
        {
            foreach (zimmet z in ZimmetlerList)
            {
                if (z.zid == zid)
                {
                    return z;
                }
            }

            return null;
        }


        public static void NewZimmetDataTableFromCSV()
        {
            try
            {
                dtZimmetler = new DataTable();
                using (StreamReader reader = new StreamReader(main.CSVZimmetlerFileName))
                {

                    string[] headers = reader.ReadLine().Split(';'); // Noktalı virgülle ayrıldığını belirtin
                    foreach (string header in headers)
                    {
                        if (header == "zid")
                        {
                            dtZimmetler.Columns.Add("zid", typeof(Int32));
                        }
                        else
                        {
                            dtZimmetler.Columns.Add(header);
                        }
                    }

                    while (!reader.EndOfStream)
                    {
                        try
                        {
                            string[] rows = reader.ReadLine().Split(';'); // Noktalı virgülle ayrıldığını belirtin
                            dtZimmetler.Rows.Add(rows);
                        }
                        catch (Exception exx)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static int getMaxZID()
        {
            int maxZid = 0;

            foreach (zimmet z in ZimmetlerList)
            {
                int currentZid = z.zid;
                if (currentZid > maxZid)
                {
                    maxZid = currentZid;
                }
            }

            return maxZid;
        }

        public static string debugZimmetTara()
        {
            List<string> list = new List<string>();
            foreach (zimmet z in ZimmetlerList)
            {
                list.Add(z.zid + " - " + z.URUN.serino);
            }
            return string.Join(Environment.NewLine, list); ;
        }

    }
}
