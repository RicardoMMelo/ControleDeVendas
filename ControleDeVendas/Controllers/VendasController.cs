using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeVendas.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendasServico _vendasServico;

        public VendasController(VendasServico vendasServico)
        {
            _vendasServico = vendasServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd/MM/yyyy");
            var resultado = _vendasServico.FindByDate(minDate, maxDate);
            return View(resultado);
        }

        
        public IActionResult AgrupaBusca(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd/MM/yyyy");
            var resultado = _vendasServico.FindByDateGrouping(minDate, maxDate);
            return View(resultado);
        }
       
    }
}
