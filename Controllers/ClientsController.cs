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
        public ActionResult Index()
        {

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
                    Id = Singleton.Instance.ClientsList.Count,
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                int index = Singleton.Instance.ClientsList.IndexOf(Singleton.Instance.ClientsList.Find(x => x.Id == id));
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private char[] Abecedario = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        private bool GreaterThan(string A, string B)
        {
            int WordLength = A.Length;
            if(B.Length < WordLength)
            {
                WordLength = B.Length;
            }
            for (int j = 0; j < WordLength; j++)
            {
                int IndexOfA = -1;
                int IndexOfB = -1;
                for (int i = 0; i < Abecedario.Length; i++)
                {
                    if (Abecedario[i] == A[j])
                    {
                        IndexOfA = i;
                    }
                    if (Abecedario[i] == B[j])
                    {
                        IndexOfB = i;
                    }
                    if (IndexOfB >= 0 && IndexOfA >= 0)
                    {
                        break;
                    }
                }
                if(IndexOfA > IndexOfB)
                {
                    return true;
                }
                else if(IndexOfA < IndexOfB)
                {
                    return false;
                }
            }
            if(B.Length < A.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult SortByName()
        {

            for (int i = 0; i < Singleton.Instance.ClientsList.Count - 1; i++)
            {
                for (int j = i; j < Singleton.Instance.ClientsList.Count; j++)
                {
                    if (GreaterThan(Singleton.Instance.ClientsList[j].Name, Singleton.Instance.ClientsList[i].Name))
                    {
                        var temp = Singleton.Instance.ClientsList[i];
                        Singleton.Instance.ClientsList[i] = Singleton.Instance.ClientsList[j];
                        Singleton.Instance.ClientsList[j] = temp;
                    }
                }
            }

            return View();
        }

        public ActionResult SortByLastName()
        {

            for (int i = 0; i < Singleton.Instance.ClientsList.Count - 1; i++)
            {
                for (int j = i; j < Singleton.Instance.ClientsList.Count; j++)
                {
                    if (GreaterThan(Singleton.Instance.ClientsList[j].Lastname, Singleton.Instance.ClientsList[i].Lastname))
                    {
                        var temp = Singleton.Instance.ClientsList[i];
                        Singleton.Instance.ClientsList[i] = Singleton.Instance.ClientsList[j];
                        Singleton.Instance.ClientsList[j] = temp;
                    }
                }
            }
            return View();
        }
    }
}
