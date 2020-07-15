using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleDeVendas.Models;

namespace ControleDeVendas.Models
{
    public class ControleDeVendasContext : DbContext
    {
        public ControleDeVendasContext (DbContextOptions<ControleDeVendasContext> options)
            : base(options)
        {
        }

        public DbSet<ControleDeVendas.Models.Departamento> Departamento { get; set; }
        public DbSet<ControleDeVendas.Models.Vendas> Vendas { get; set; }
        public DbSet<ControleDeVendas.Models.Vendedor> Vendedor { get; set; }
    }
}
