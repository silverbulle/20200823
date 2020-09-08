using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doc_reviewer_1._2
{
    class FileJsonItem
    {
        public string code { get; set; }

        public string message { get; set; }

        public Dictionary<string, object> data { get; set; }

        public int total { get; set; }

        public List<main_ListItem> list { get; set; }
    }
    class main_ListItem
    {
        public string model { get; set; }

        public string pk { get; set; }

        public Dictionary<string, object> fields { get; set; }

        public string name { get; set; }

        public int type { get; set; }

        public string content { get; set; }

        public string returncontent { get; set; }

        public string url { get; set; }

        public string filename { get; set; }

        public string submissionunit { get; set; }

        public long submissiontime { get; set; }

        public string reviewopinion { get; set; }

        public string lastedittime { get; set; }

        public int state { get; set; }

        public string reviewwordurl { get; set; }

        public Dictionary<string,object> appendix { get; set; }

        public int total { get; set; }

        public List<appendixListItem> list { get; set; }

        public Dictionary<string, object> needappendix { get; set; }

        public List<needappendixListItem> list1 { get; set; }
    }

    class appendixListItem
    {
        public string model { get; set; }

        public string pk { get; set; }

        public Dictionary<string, object> fields { get; set; }

        public int file_id { get; set; }

        public string url { get; set; }

        public int appendixtype_id { get; set; }

        public int state { get; set; }
    }

    class needappendixListItem
    {
        public string model { get; set; }

        public string pk { get; set; }

        public Dictionary<string, object> fields { get; set; }

        public int file_id { get; set; }

        public string url { get; set; }

        public int appendixtype_id { get; set; }

        public int state { get; set; }
    }
}
