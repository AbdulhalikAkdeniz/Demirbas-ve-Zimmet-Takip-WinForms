using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    public class model
    {
        public marka mrk;
        public string modelismi;

        public model(marka mrk,string modelismi)
        {
            this.mrk = mrk;
            this.modelismi = modelismi;
        }
        public override string ToString()
        {
            return modelismi;
        }
    }
}
