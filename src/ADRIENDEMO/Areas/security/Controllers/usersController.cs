using ADRIENDEMO.Areas.security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADRIENDEMO.Dal;
using System.Net;

namespace ADRIENDEMO.Areas.security.Controllers
{
    public class usersController : Controller
    {
        
        // GET: security/users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.users
                             select new userview
                         {
                             id = user.id,
                             Firstname = user.Firstname,
                             Lastname = user.Lastname,
                             Age = user.Age,
                             Gender = user.Gender
                         }).ToList();


                return View(users);
            }
        }

        // GET: security/users/Details/5
        public ActionResult Details(int id)
        {
            return View(GetUser(id));
         
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new List<SelectListItem> {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                {
                    Value = "Female",
                    Text = " Female" 
                }
            };
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(userview usermodel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                    db.users.Add(new User
                    {
                        Firstname = usermodel.Firstname,
                        Lastname = usermodel.Lastname,
                        Age = usermodel.Age,
                        Gender = usermodel.Gender

                    });
                    db.SaveChanges();
                }
                TempData["message"] = "Successfully created!";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetUser(id));

        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, userview usermodel)
        {
          
            try
            {
                if (ModelState.IsValid == false)
                    return View();
                using (var db = new DatabaseContext())
                {
                  var user = db.users.FirstOrDefault(u => u.id == id);
                    
                    user.Firstname = usermodel.Firstname;
                    user.Lastname = usermodel.Lastname;
                    user.Age = usermodel.Age;
                    user.Gender = usermodel.Gender;

                    db.SaveChanges();
                }
                


                TempData["editmsg"] = "Successfully modified!";
             
                return RedirectToAction("Index");
            }
           
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetUser(id));
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    var user = db.users.FirstOrDefault(u => u.id == id);
                    db.users.Remove(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        private userview GetUser(int id)
        {
            using (var db = new DatabaseContext())
            {
                return (from user in db.users
                        where user.id == id
                        select new userview
                        {
                            id = user.id,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname,
                            Age = user.Age,
                            Gender = user.Gender
                        }).FirstOrDefault();


            }

        }
    }
}