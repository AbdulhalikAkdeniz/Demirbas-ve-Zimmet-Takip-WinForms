using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    public class Hiyerarsi
    {
        public static List<tur> turlerListesi = new List<tur>();

        public static List<tur> getTurler()
        {

            return turlerListesi;
        }
        public static List<marka> getMarkalar(string tur)
        {
            tur t = turBul(tur);
            if (t!=null)
            {
                return t.aitMarkalar;
            }
            else { return null; }

        }
        public static List<model> getModeller(string marka,string tur)
        {
            tur turr = turBul(tur);
            if (turr !=null)
            {
                marka mar = turr.markaBul(marka);
                if (mar!=null)
                {
                    return mar.aitModeller;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public static tur turBul(string turismi)
        {
            foreach (tur t in turlerListesi)
            {
                if (String.Equals(t.turismi, turismi, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                {
                    return t;
                }
            }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }
        public static marka markaBul(tur t,string markaismi)
        {
                if (t == null){return null;}

                foreach (marka m in t.aitMarkalar)
                {
                    if (String.Equals(m.markaismi, markaismi, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                    {
                        return m;
                    }
                }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }
        public static model modelBul(tur t,marka mar,string modelismi)
        {
            if (t == null || mar == null) { return null; }

            foreach (model mod in mar.aitModeller)
                {
                    if (String.Equals(mod.modelismi, modelismi, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                    {
                    return mod;
                    }
                }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }
    }
}
