﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio.LojaVirtual
{
    public class LojaContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public LojaContext() { }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // pk composta
            modelBuilder
                .Entity<PromocaoProdutos>()
                .HasKey(
                    pp => new 
                    { 
                        pp.PromocaoId, 
                        pp.ProdutoId 
                    });

            // table name
            modelBuilder
                .Entity<Endereco>().
                ToTable("Enderecos");

            // shadow property
            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            // a pk de Endereco terá o mesmo valor da pk de Cliente
            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);
        }

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
