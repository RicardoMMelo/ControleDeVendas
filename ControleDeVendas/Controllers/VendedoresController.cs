using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models;
using ControleDeVendas.Servicos;
using Microsoft.AspNetCore.Mvc;
using ControleDeVendas.Controllers;
using ControleDeVendas.Models.ViewModels;

namespace ControleDeVendas.Controllers
{
    public class VendedoresController : Controller
    {
        //Injeção de dependência
        private readonly VendedorServicos _vendedorServicos;
        private readonly DepartamentoServico _departamentoServico;

        public VendedoresController(VendedorServicos vendedorServicos, DepartamentoServico departamentoServico)
        {
            _vendedorServicos = vendedorServicos;
            _departamentoServico = departamentoServico;
        }
        // Termina a injeção
        public IActionResult Index()
        {
            var lista = _vendedorServicos.FindAll();

            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoServico.FindAll();
            var viewModel = new VendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServicos.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServicos.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
