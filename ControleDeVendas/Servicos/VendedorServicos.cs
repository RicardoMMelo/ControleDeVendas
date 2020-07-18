using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models;
using ControleDeVendas.Servicos;
using ControleDeVendas.Servicos.Excesoes;
using Microsoft.EntityFrameworkCore;

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

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            try
            {
                var obj = _context.Vendedor.Find(id);
                _context.Vendedor.Remove(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException("Não é possível apagar este Vendedor porque tem Vendas cadastradas.");
            }
        }

        public void Update(Vendedor obj)
        {
            if(!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Vendedor não Encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
