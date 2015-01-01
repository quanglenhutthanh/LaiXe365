using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace code.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
       
        public string Username { get; set; }
        
  
        public string Password { get; set; }
        
        public string ConfirmedPass { get; set; }
    }
}