using chnprjct.Areas.Privacy.Models;
using chnprjct.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chnprjct.Areas.Privacy.Controllers
{
    public class UsersController : Controller
    {
          private  IList<UsersViewModel> Users
        {
              get
            {
                  if (Session["data"] == null )
                  {
                      Session["data"] = new List<UsersViewModel>() { 
                          new UsersViewModel {
                             ID = Guid.NewGuid(),
                             FirstName = "Chona", 
                             LastName = "Caspe", 
                             Age = 19    
                          },
                           new UsersViewModel {
                             ID = Guid.NewGuid(),
                             FirstName = "China", 
                             LastName = "Town", 
                             Age = 18  
                      }
                  };
            }
            return Session["data"] as List<UsersViewModel>;
       }
   }


        //-----------------------------------------------------------
        // GET: Privacy/Users/Details
        public ActionResult Index()
          {
            using(var db = new DatabaseContext())
            {
            
                var users = (from user in db.Users
                             select new UsersViewModel
                {
                    ID = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Gender = user.Gender
                }).ToList();
             return View(users);
            }
              
          }


        //-----------------------------------------------------------
        // GET: Privacy/Users/Details/5
        public ActionResult Details(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.ID == id);
            return View(u);
        }

        
         


        //------------------------------------------------------------
        // GET: Privacy/Users/Create
        public ActionResult Create ()
        {
            ViewBag.Gender = new List<SelectListItem>
            {
                    new SelectListItem
                    {
                        Value = "Male",
                        Text = "Male"
                    },

                    new SelectListItem
                    {
                        Value = "Female",
                        Text = "Female"
                    }
            };
            return View();
        }

        // POST: Privacy/Users/Create
        [HttpPost]
        public ActionResult Create(UsersViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();

                using (var db = new DatabaseContext())
                              
                {
                    db.Users.Add(new User

                    {
                    Id = Guid.NewGuid(),
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Age = viewModel.Age,
                    Gender = viewModel.Gender
                    });
                db.SaveChanges();
            }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //------------------------------------------------------------
        // GET: Privacy/Users/Edit/5
        public ActionResult Edit (Guid id)
        {
            var u = Users.FirstOrDefault(user => user.ID == id);
            return View();
        }

        // POST: Privacy/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UsersViewModel usersmodel)
        {
            try
            {
                // TODO: Add update logic here
                var u = Users.FirstOrDefault(user => user.ID == id);
                u.FirstName = usersmodel.FirstName;
                u.LastName = usersmodel.LastName;
                u.Age = usersmodel.Age;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //------------------------------------------------------------
        // GET: Privacy/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.ID == id);
            return View(u);
        }

        // POST: Privacy/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var u = Users.FirstOrDefault(user => user.ID == id);
                Users.Remove(u);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
