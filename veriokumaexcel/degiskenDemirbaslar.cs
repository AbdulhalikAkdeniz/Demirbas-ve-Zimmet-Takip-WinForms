using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace veriokumaexcel
{
    internal class degiskenDemirbaslar
    {
        public static DataTable dtZimmetlenecek;
        public static DataTable dtZimmetlenmis;

        public static void dtOlusturUrunGibi(DataTable dt)
        {
            dt.Columns.Add("uid", typeof(int));
            dt.Columns.Add("tur", typeof(string));
            dt.Columns.Add("serino", typeof(string));
            dt.Columns.Add("marka", typeof(string));
            dt.Columns.Add("model", typeof(string));
            dt.Columns.Add("dem_no", typeof(string));
        }
        public static void dtSatirEkle(DataTable dt, urun u)
        {
            DataRow newRow = dt.NewRow();
            newRow["uid"] = u.uid;
            newRow["tur"] = u.tur;
            newRow["serino"] = u.serino;
            newRow["marka"] = u.marka;
            newRow["model"] = u.model;
            newRow["dem_no"] = u.dem_no;

            dt.Rows.Add(newRow);
        }

        public static DataTable dtOlusturZimmetlenecek()
        {
            dtZimmetlenecek = new DataTable();
            dtOlusturUrunGibi(dtZimmetlenecek);
            foreach (urun u in demirbaslar.UrunlerList)
            {
                if (u.zimmetalan == null)
                {
                    dtSatirEkle(dtZimmetlenecek,u);
                }
            }
            return dtZimmetlenecek;
        }
        public static DataTable dtOlusturZimmetlenmis()
        {
            dtZimmetlenmis = new DataTable();
            dtOlusturUrunGibi(dtZimmetlenmis);
            foreach (urun u in demirbaslar.UrunlerList)
            {
                if (u.zimmetalan != null)
                {
                    dtSatirEkle(dtZimmetlenmis, u);
                }
            }
            return dtZimmetlenmis;
        }

    }
}
