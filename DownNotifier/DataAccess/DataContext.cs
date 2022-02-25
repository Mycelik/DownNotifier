using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace DataAccess
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("server=.;database=DownNotifierDB;trusted_connection=true;");
        }
        public virtual DbSet<App> Apps { get; set; }
    }
}
