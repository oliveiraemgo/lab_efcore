using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class LojaContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }

        public LojaContext() { }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                // informando o banco e a connection string que será utilizado            
                builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LaboratorioLojaVirtual;Trusted_Connection=true;");
            }
        }
    }
}
