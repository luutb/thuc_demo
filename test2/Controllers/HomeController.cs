using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test2.Models;

namespace test2.Controllers
{
    public class HomeController : Controller
    {
        testEntities db = new testEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult index(string id)
        {
            var login = new login();
            login.username = this.Request.Form["username"];
            login.password = this.Request.Form["password"];

            var user = db.logins.Where(m => m.username.Equals(login.username) && m.password.Equals(login.password)).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("Employee");
            }

            return View(login);
        }

        public ActionResult Employee()
        {
            return View(db.Employees);

        }
        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(string id)
        {

            var ep = new Employee();
            ep.ma_sv = this.Request.Form["ma_sv"];
            ep.hoten = this.Request.Form["hoten"];
            ep.date = DateTime.ParseExact(this.Request.Form["date"], "dd/MM/yyyy", null);


            ep.address = this.Request.Form["address"];

            ep.sdt = this.Request.Form["sdt"];


            ep.email = this.Request.Form["email"];

            this.db.Employees.Add(ep);
            this.db.SaveChanges();

            return View(ep);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            db.Employees.Remove(db.Employees.Where(m => m.user_id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var ep = db.Employees.Where(m => m.user_id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Sua()
        {
            var ep = new Employee();
            ep.hoten = this.Request.Form["hoten"];
            ep.date = DateTime.ParseExact(this.Request.Form["date"],"dd/MM/yyyy", null);
            ep.hoten = this.Request.Form["hoten"];
            ep.hoten = this.Request.Form["hoten"];
            ep.hoten = this.Request.Form["hoten"];
            ep.hoten = this.Request.Form["hoten"];
            return View();
        }
    }

}