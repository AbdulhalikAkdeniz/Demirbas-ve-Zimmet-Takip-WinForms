using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    public class marka
    {
        public string markaismi;
        public tur turobj;
        public List<model> aitModeller = new List<model>();
        public model modelBul(string modelisim)
        {
            foreach (model mod in aitModeller)
            {
                if (String.Equals(mod.modelismi, modelisim, StringComparison.OrdinalIgnoreCase)) //büyük küçük harf duyarlılığı olmadan string eşitliğini karşılaştırdık
                {
                    return mod;
                }
            }

            return null; // Serino eşleşmesi bulunamadıysa null döndürülür
        }

        public marka(string markaismi,tur turr)
        {
            this.markaismi = markaismi;
            this.turobj = turr;
        }
        public override string ToString()
        {
            return markaismi;
        }
    }
}
