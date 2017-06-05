using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Models
{
    public class TenderDatabase
    {
        public int id               { get; set; }
        public  String Name         { get; set; }
        public String Address       { get; set; }
        public String Contact_Email { get; set; }
        public String Contact_Name  { get; set; }
    }
}