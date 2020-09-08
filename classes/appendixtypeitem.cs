using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace doc_reviewer_1._2
{
    class appendixtypeitem
    {
        public string code { get; set; }

        public string message { get; set; }

        public Dictionary<string,object>  data { get; set; }

        public int total { get; set; }

        public List<listitem> list { get; set; }    

    }

    class listitem
    {
        public string model { get; set; }

        public string pk { get; set; }

        public Dictionary<string, object> fields { get; set; }

        public string name { get; set; }

        public int state { get; set; }
    }
}
