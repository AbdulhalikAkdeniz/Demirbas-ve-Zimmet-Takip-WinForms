using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    public class tur
    {

        public string turismi;
        public List<marka> aitMarkalar = new List<marka>();
        public marka markaBul(string markaisim)
        {
            //sno = sno.ToLower();
            foreach (marka mar in aitMarkalar)
            {
                if (String.Equals(mar.markaismi, markaisim, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                {
                    return mar;
                }
            }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }

        public tur(string turismi)
        {
            this.turismi = turismi;
        }

        public override string ToString()
        {
            return turismi;
        }

    }
}
