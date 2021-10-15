using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPU_Project.Models
{
    public class Salesorder
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Module { get; set; }
        public string Salesorder_No { get; set; }
        public string Line_Item { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
        public bool InTheModule { get; set; }
        public bool Completed { get; set; }
    }
}