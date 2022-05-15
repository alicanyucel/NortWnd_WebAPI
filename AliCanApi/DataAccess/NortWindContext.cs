using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AliCanApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
namespace AliCanApi.DataAccess
{
    public class NortWindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IDEA-PC\SQLEXPRESS01;Database=NORTHWND;Trusted_Connection=True");

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
