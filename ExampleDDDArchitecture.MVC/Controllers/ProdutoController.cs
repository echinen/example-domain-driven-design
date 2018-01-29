using AutoMapper;
using ExampleDDDArchitecture.Application.Interface;
using ExampleDDDArchitecture.Domain.Entities;
using ExampleDDDArchitecture.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleDDDArchitecture.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoApp;

        public ProdutoController(IProdutoAppService produtoApp)
        {
            _produtoApp = produtoApp;
        }

        // GET: Produto
        public ActionResult Index()
        {
            var produtoVIewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            return View(produtoVIewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                produto.DataCadastro = DateTime.Now;

                var produtoViewModel = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoViewModel);

                //TODO - Verificar por que não esta redirecionando
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoViewModel = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoViewModel);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);

            return RedirectToAction("Index");
        }
    }
}
