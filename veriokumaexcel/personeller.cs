using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    internal class personeller
    {
        public static DataTable dtPersoneller = new DataTable();
        public static List<personel> PersonellerList = new List<personel>();


        public static void Olustur_PersonellerListFromDT()
        {
            try
            {
                PersonellerList = new List<personel>();
                for (int i = 0; i < dtPersoneller.Rows.Count; i++)
                {
                    personel tempObjPersonel = new personel();
                    tempObjPersonel.pid = int.Parse(dtPersoneller.Rows[i]["pid"].ToString());
                    tempObjPersonel.adsoyad = dtPersoneller.Rows[i]["adsoyad"].ToString();
                    tempObjPersonel.unvan = dtPersoneller.Rows[i]["unvan"].ToString();
                    tempObjPersonel.sicil = dtPersoneller.Rows[i]["sicil"].ToString();
                    tempObjPersonel.birimad = dtPersoneller.Rows[i]["birim"].ToString();

                    PersonellerList.Add(tempObjPersonel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        public static void csvLoadPersonelToNewDataTable()
        {
            try
            {
                dtPersoneller = new DataTable();
                using (StreamReader reader = new StreamReader(main.CSVPersonellerFileName))
                {
                    string[] headers = reader.ReadLine().Split(';'); // Noktalı virgülle ayrıldığını belirtin
                    foreach (string header in headers)
                    {
                        if (header == "pid")
                        {
                            dtPersoneller.Columns.Add("pid", typeof(Int32));
                        }
                        else
                        {
                            dtPersoneller.Columns.Add(header);
                        }
                    }

                    while (!reader.EndOfStream)
                    {


                        try
                        {
                            string[] rows = reader.ReadLine().Split(';'); // Noktalı virgülle ayrıldığını belirtin
                            dtPersoneller.Rows.Add(rows);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public static bool isPersonelSicilExitsBool(string sicil)
        {
            foreach (personel p in PersonellerList)
            {
                if (String.Equals(p.sicil, sicil, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public static personel personelBul(string sicilno)
        {
            foreach (personel p in PersonellerList)
            {
                if (String.Equals(p.sicil, sicilno, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                {
                    return p;
                }
            }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }

        public static personel personelBul_IDile(int pid)
        {
            foreach (personel p in PersonellerList)
            {
                if (p.pid == pid)
                {
                    return p;
                }
            }

            return null;
        }


        public static int getMaxPID()
        {
            int maxPid = 0;

            foreach (personel p in PersonellerList)
            {
                int currentPid = p.pid;
                if (currentPid > maxPid)
                {
                    maxPid = currentPid;
                }
            }

            return maxPid;
        }
    }
}
