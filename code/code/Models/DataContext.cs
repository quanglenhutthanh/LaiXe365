using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace code.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DataConnectionString") { }
        public DbSet<Page> Pages { get; set; }
    }
}