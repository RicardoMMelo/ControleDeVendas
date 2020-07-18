using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeVendas.Models;
using ControleDeVendas.Servicos;
using Microsoft.AspNetCore.Mvc;
using ControleDeVendas.Controllers;
using ControleDeVendas.Models.ViewModels;
using ControleDeVendas.Servicos.Excesoes;
using System.Diagnostics;

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
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new{message = "Id Nulo"});
            }

            var obj = _vendedorServicos.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new{message = "Id não Encontrado"});
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _vendedorServicos.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new{message = "Id nulo"});
            }

            var obj = _vendedorServicos.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new{message = "Id não Encontrado"});
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new{message = "Id Nulo"});
            }

            var obj = _vendedorServicos.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new{message = "Id não Encontrado"});
            }

            List<Departamento> departamentos = _departamentoServico.FindAll();
            VendedorViewModel viewModel = new VendedorViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Não Corresponde" });
            }
            try
            {
                _vendedorServicos.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new{message = e.Message});
            }
           
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier

            };
            return View(viewModel);
        }
    }
}
