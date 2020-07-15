using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models;
using ControleDeVendas.Servicos;

namespace ControleDeVendas.Servicos
{
    public class VendedorServicos
    {
        private readonly ControleDeVendasContext _context;

        public VendedorServicos(ControleDeVendasContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
