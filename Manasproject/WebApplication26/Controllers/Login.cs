using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication26.Models;

namespace WebApplication26.Controllers
{
    public class Login : Controller
    {
        private readonly project1211Context _context;
        public Login(project1211Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return PartialView();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("name", "");
            HttpContext.Session.SetString("Type", "");
            HttpContext.Session.SetString("Email", "");
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Index(Logincs objs)
        { var ac= (from s in _context.MstUsers
                                 where s.Email == objs.Username
                                 select s).SingleOrDefault();
            if ((!ModelState.IsValid) || ac == null)
            {
                ModelState.AddModelError("", "Failed");
                return PartialView(objs);
            }
            else
            {
                if ((objs.Username == ac.Email) && (objs.Password == ac.Pswd) &&(objs.checktype==ac.FkRoleId))
                {
                    if (objs.checktype == 1)
                    {
                        HttpContext.Session.SetString("Email", ac.Email);
                        HttpContext.Session.SetString("name", ac.Fname + ac.Lname);
                        HttpContext.Session.SetString("Type", ac.FkRoleId.ToString());
                        return RedirectToAction("Myprofilee", "StudentDetails");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Email", ac.Email);
                        HttpContext.Session.SetString("name", ac.Fname + ac.Lname);
                        HttpContext.Session.SetString("Type", ac.FkRoleId.ToString());
                        //this.Session.SetString("TransId", "x001");
                        //Session["UserId"] = Guid.NewGuid();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Failed");
                    return PartialView(objs);
                }
            }
        }
    }
}
