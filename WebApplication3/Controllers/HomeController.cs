using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name can't be empty");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Password can't be empty");
            }
            else if (model.Password.Length<8)
            {
                ModelState.AddModelError("Password", "Password too short");

            }
            else if(string.IsNullOrEmpty(model.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "This field can't be empty");
            }else if (!model.Password.Equals(model.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords are not the same");
            }
            if(model.age < 18)
            {
                ModelState.AddModelError("age", "Age can't be less than 18");
            }
            if (model.age > 65)
            {
                ModelState.AddModelError("age", "Age can't be lover 65");
            }
            try {
                var buf= new System.Net.Mail.MailAddress(model.Email);
            }catch{
                ModelState.AddModelError("Email", "Email is not valid");
            }
            if(!ModelState.IsValid) return View(model);
            ViewBag.Login = model.Name;
            ViewBag.Password = model.Password;
            return View("Success");
        }

    }
}