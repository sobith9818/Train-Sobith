using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobith_forma
{
    internal class Train
    {

        public string train_no { get; set; }
        public string train_name { get; set; }
         public string from_stn_code { get; set; }
        public string source_stn_code { get; set; }

        public string dstn_stn_name { get; set; }
        public string dstn_stn_code { get; set; }

        public string to_time { get; set; }
        public string from_time { get; set; }

        public string duration { get; set; }
        public string distance { get; set; }

        public string running_days { get; set; }
        public string to_stn_code { get; set; }
       
    }
}
