using ControleDeVendas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeVendas.Servicos
{
    public class VendasServico
    {
        private readonly ControleDeVendasContext _context;

        public VendasServico(ControleDeVendasContext context)
        {
            _context = context;
        }
        public List<Vendas> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Vendas select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate);
            }
            return resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToList();
        }
        public List<IGrouping<Departamento,Vendas>> FindByDateGrouping(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Vendas select obj;
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= maxDate);
            }
            return resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToList();
        }
    }
}
