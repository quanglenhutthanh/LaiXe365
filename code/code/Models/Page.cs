using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace code.Models
{
    public class Page
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public bool IsHomePage { get; set; }
    }
}