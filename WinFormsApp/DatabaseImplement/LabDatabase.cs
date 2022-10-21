using App.DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DatabaseImplement
{
    public class LabDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H80LAH0\SQLEXPRESS;Initial Catalog=LabDatabase;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Lab> Labs { set; get; }

        public virtual DbSet<Subject> Subjects { set; get; }
    }
}
