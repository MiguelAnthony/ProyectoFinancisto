using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinasistoCloneWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FinasistoCloneWeb.Controllers
{
    public class AccountController : Controller
    {
        private FinansistoContext _context;
        public AccountController(FinansistoContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            //var context = _context.Accounts.ToList();
            ViewBag.Accounts = _context.Accounts.ToList();
            return View("Index");
        }

        [HttpGet]

        public ActionResult Create() //GET
        {
            return View("Create");
        }



        [HttpPost]
        public ActionResult Create(Account account)  //POST //En mi metodo le paso la clase completa y el nombre que quiero que tenga
        {
            //if (DatosAccount.Name == null || DatosAccount.Name == "")
            //{
            //    ModelState.AddModelError("name1", "Compo requerido");
            //}

            if (ModelState.IsValid)//por defecto true
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create");
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
        ViewBag.Types = new List<string> { "Efectivo", "Debito", "Credito", "BCP", "BBVA", "MasterdCard" };
        ViewBag.Account = _context.Accounts.Where(o => o.Id == id).FirstOrDefault();
        return View("Edit");
    }
       
        [HttpPost]
        public ActionResult Edit(Account account)
        {
            //var a = _context.Accounts.Where(o => o.Id == account.Id).FirstOrDefault();
            //a.Name = account.Name;
            //_context.SaveChanges();   
            //a es un nuevo objeto
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account = account;
            return View("edit");
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = _context.Accounts.Where(o => o.Id == id).FirstOrDefault();
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

