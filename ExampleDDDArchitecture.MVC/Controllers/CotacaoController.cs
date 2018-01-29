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
    public class CotacaoController : Controller
    {
        private readonly ICotacaoAppService _cotacaoApp;
        //private readonly IProdutoAppService _produtoApp;
        private readonly IPlanoAppService _planoApp;

        public CotacaoController(ICotacaoAppService cotacaoApp, IPlanoAppService planoApp)
        {
            _cotacaoApp = cotacaoApp;
            //_produtoApp = produtoApp;
            _planoApp = planoApp;
        }

        // GET: cotacao
        public ActionResult Index()
        {
            var cotacaoViewModel = Mapper.Map<IEnumerable<Cotacao>, IEnumerable<CotacaoViewModel>>(_cotacaoApp.GetAll());

            return View(cotacaoViewModel);
        }

        // GET: Cotacao/Details/5
        public ActionResult Details(int id)
        {
            var cotacao = _cotacaoApp.GetById(id);
            var cotacaoViewModel = Mapper.Map<Cotacao, CotacaoViewModel>(cotacao);

            return View(cotacaoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            var lstPlano = _planoApp.GetAll();

            IEnumerable<SelectListItem> SliPlano = lstPlano.ToList().Select(i => new SelectListItem()
            {
                Text = i.TipoPlano,
                Value = i.PlanoId.ToString(),
            });

            ViewBag.TiposPlanos = SliPlano;

            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CotacaoViewModel cotacao)
        {
            if (ModelState.IsValid)
            {
                cotacao.DataCotacao = DateTime.Now;
                var cotacaoDomain = Mapper.Map<CotacaoViewModel, Cotacao>(cotacao);
                _cotacaoApp.Add(cotacaoDomain);

                return RedirectToAction("Index");
            }

            return View(cotacao);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var cotacao = _cotacaoApp.GetById(id);
            var cotacaoViewModel = Mapper.Map<Cotacao, CotacaoViewModel>(cotacao);

            return View(cotacaoViewModel);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CotacaoViewModel cotacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var cotacaoDomain = Mapper.Map<CotacaoViewModel, Cotacao>(cotacaoViewModel);
                _cotacaoApp.Update(cotacaoDomain);

                return RedirectToAction("Index");
            }

            return View(cotacaoViewModel);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int id)
        {
            var cotacao = _cotacaoApp.GetById(id);
            var cotacaoViewModel = Mapper.Map<Cotacao, CotacaoViewModel>(cotacao);

            return View(cotacaoViewModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cotacao = _cotacaoApp.GetById(id);
            _cotacaoApp.Remove(cotacao);

            return RedirectToAction("Index");
        }

        public ActionResult ValidateOrigemDDDDestinoDDD(string origemDDD, string destinoDDD)
        {
            var produto = _cotacaoApp.CheckIfTariffExist(origemDDD, destinoDDD);

            return Content(produto.ToString(), "text/plain");
        }

        public ActionResult NewQuotation(string origemDDD, string destinoDDD, int plano, int tempo)
        {
            var cotacaoDomain = _cotacaoApp.ToDoQuotation(origemDDD, destinoDDD, plano, tempo);

            var cotacaoViewModel = Mapper.Map<Cotacao, CotacaoViewModel>(cotacaoDomain);

            return Json(cotacaoViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}