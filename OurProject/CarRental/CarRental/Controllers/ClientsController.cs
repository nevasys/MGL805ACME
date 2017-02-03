using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ClientsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Clients
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpUnauthorizedResult();
            }
            if (!User.IsInRole("Admin") && !User.IsInRole("Agence"))
            {
                return new HttpUnauthorizedResult();
            }

            var clients = _dbContext.Clients.ToList();

            return View(clients);
            
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var client = _dbContext.Clients.SingleOrDefault(v => v.Id == id);

            if (client == null)
                return HttpNotFound();

            return View(client);
        }

        [HttpPost]
        public ActionResult Update(Client client)
        {
            var clientInDb = _dbContext.Clients.SingleOrDefault(v => v.Id == client.Id);

            if (clientInDb == null)
                return HttpNotFound();

            clientInDb.BirthDate = client.BirthDate;
            clientInDb.DriverLicenseNUmber = client.DriverLicenseNUmber;
            clientInDb.HasValidDriverLicense = client.HasValidDriverLicense;
            clientInDb.IsActive = client.IsActive;
            clientInDb.CreatedBy = client.CreatedBy;
            clientInDb.CreatedOn = client.CreatedOn;
            clientInDb.ModifiedBy = client.ModifiedBy;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var client = _dbContext.Clients.SingleOrDefault(v => v.Id == id);

            if (client == null)
                return HttpNotFound();

            return View(client);
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var client = _dbContext.Clients.SingleOrDefault(v => v.Id == id);
            if (client == null)
                return HttpNotFound();
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}