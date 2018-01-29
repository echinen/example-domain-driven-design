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
    public class PlanoController : Controller
    {
        private readonly IPlanoAppService _planoApp;

        public PlanoController(IPlanoAppService planoApp)
        {
            _planoApp = planoApp;
        }

        // GET: Plano
        public ActionResult Index()
        {
            var planoViewModel = Mapper.Map<IEnumerable<Plano>, IEnumerable<PlanoViewModel>>(_planoApp.GetAll());

            return View(planoViewModel);
        }

        // GET: Plano/Details/5
        public ActionResult Details(int id)
        {
            var plano = _planoApp.GetById(id);
            var planoViewModel = Mapper.Map<Plano, PlanoViewModel>(plano);

            return View(planoViewModel);
        }

        // GET: Plano/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plano/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlanoViewModel plano)
        {
            if (ModelState.IsValid)
            {
                plano.DataCadastro = DateTime.Now;

                var planoViewModel = Mapper.Map<PlanoViewModel, Plano>(plano);
                _planoApp.Add(planoViewModel);

                //TODO - Verificar por que não esta redirecionando
                return RedirectToAction("Index");
            }

            return View(plano);
        }

        // GET: Plano/Edit/5
        public ActionResult Edit(int id)
        {
            var plano = _planoApp.GetById(id);
            var planoViewModel = Mapper.Map<Plano, PlanoViewModel>(plano);

            return View(planoViewModel);
        }

        // POST: Plano/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlanoViewModel plano)
        {
            if (ModelState.IsValid)
            {
                var planoViewModel = Mapper.Map<PlanoViewModel, Plano>(plano);
                _planoApp.Add(planoViewModel);

                return RedirectToAction("Index");
            }

            return View(plano);
        }

        // GET: Plano/Delete/5
        public ActionResult Delete(int id)
        {
            var plano = _planoApp.GetById(id);
            var planoViewModel = Mapper.Map<Plano, PlanoViewModel>(plano);

            return View(planoViewModel);
        }

        // POST: Plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var plano = _planoApp.GetById(id);
            _planoApp.Remove(plano);

            return RedirectToAction("Index");
        }
    }
}
