using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L0_MVC_DAVH_AFPE.Models.Data;

namespace L0_MVC_DAVH_AFPE.Controllers
{
    public class ClientsController : Controller
    {
        // GET: StudentsController
        

        public ActionResult Index(int sb)
        {
            if (sb == 1)
            {
                Singleton.Instance.SortByName();
            }
            else if (sb == 2)
            {
                Singleton.Instance.SortByLastName();
            }
            return View(Singleton.Instance.ClientsList);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(string Name)
        {
            var detailsClient = Singleton.Instance.ClientsList.Find(x => x.Name == Name);
            return View(detailsClient);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newClient = new Models.ClientsModel
                {                    
                    Name = collection["Name"],
                    Lastname = collection["LastName"],
                    PhoneNumber = collection["PhoneNumber"],
                    Description = collection["Description"]
                };
                Singleton.Instance.ClientsList.Add(newClient);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(string Name)
        {
            var editClient = Singleton.Instance.ClientsList.Find(x => x.Name == Name);
            return View(editClient);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Name, IFormCollection collection)
        {
            try
            {
                int index = Singleton.Instance.ClientsList.IndexOf(Singleton.Instance.ClientsList.Find(x => x.Name == Name));
                var ClientEdited = new Models.ClientsModel
                {
                    Name = collection["Name"],
                    Lastname = collection["LastName"],
                    PhoneNumber = collection["PhoneNumber"],
                    Description = collection["Description"]
                };
                Singleton.Instance.ClientsList[index] = ClientEdited;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(string Name)
        {
            var Client = Singleton.Instance.ClientsList.Find(x => x.Name == Name);
            return View(Client);            
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string Name, IFormCollection collection)
        {
            try
            {
                Singleton.Instance.ClientsList.Remove(Singleton.Instance.ClientsList.Find(x => x.Name == Name));
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

       
    }
}
