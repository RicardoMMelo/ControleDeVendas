using ControleDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVendas.Servicos
{
    public class DepartamentoServico
    {
        private readonly ControleDeVendasContext _context;

        public DepartamentoServico(ControleDeVendasContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
