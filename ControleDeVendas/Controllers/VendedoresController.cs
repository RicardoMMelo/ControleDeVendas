using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models;
using ControleDeVendas.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeVendas.Controllers
{
    public class VendedoresController : Controller
    {
        //Injeção de dependência
        private readonly VendedorServicos _vendedorServicos;

        public VendedoresController(VendedorServicos vendedorServicos)
        {
            _vendedorServicos = vendedorServicos;
        }
        // Termina a injeção
        public IActionResult Index()
        {
            var lista = _vendedorServicos.FindAll();

            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServicos.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
