using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            if (userlist != null)
            {
                return View(userlist);
            }
            else
            {
                return View("Error"); // or another appropriate view
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist?.Find(user => user.Id == id);
            if (user != null)
            {
                return View(user);
            }
            return View("Error"); // or another appropriate view
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Implement the Create method here
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // Implement the Create method here
                userlist.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error"); // or another appropriate view
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Implement the Edit method here
            var user = userlist?.Find(user => user.Id == id);
            if (user != null)
            {
                return View(user);
            }
            return View("Error"); // or another appropriate view
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                // Implement the Edit method here
                var existingUser = userlist?.Find(u => u.Id == id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    // Update other fields as necessary
                    return RedirectToAction(nameof(Index));
                }
                return View("Error"); // or another appropriate view
            }
            catch
            {
                return View("Error"); // or another appropriate view
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            var user = userlist?.Find(user => user.Id == id);
            if (user != null)
            {
                return View(user);
            }
            return View("Error"); // or another appropriate view
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Implement the Delete method here
                var user = userlist?.Find(user => user.Id == id);
                if (user != null)
                {
                    userlist.Remove(user);
                    return RedirectToAction(nameof(Index));
                }
                return View("Error"); // or another appropriate view
            }
            catch
            {
                return View("Error"); // or another appropriate view
            }
        }
    }
}
