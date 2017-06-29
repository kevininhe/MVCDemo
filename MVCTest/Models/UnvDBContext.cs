using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class UnvDBContext: DbContext
    {
        public UnvDBContext() { }

        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}