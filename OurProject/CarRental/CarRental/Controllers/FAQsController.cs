using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class FAQsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public FAQsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: FAQs
        public ActionResult Index()
        {

            var faqs = _dbContext.Reservations.ToList();

            return View(faqs);
        }


        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(FAQ faq)
        {
            _dbContext.FAQs.Add(faq);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var faq = _dbContext.FAQs.SingleOrDefault(v => v.Id == id);

            if (faq == null)
                return HttpNotFound();

            return View(faq);
        }

        [HttpPost]
        public ActionResult Update(FAQ faq)
        {
            var faqInDb = _dbContext.FAQs.SingleOrDefault(v => v.Id == faq.Id);

            if (faqInDb == null)
                return HttpNotFound();

            faqInDb.Question = faq.Question;
            faqInDb.Answer = faq.Answer;
            faqInDb.IsActive = faq.IsActive;
            faqInDb.CreatedBy = faq.CreatedBy;
            faqInDb.CreatedOn = faq.CreatedOn;
            faqInDb.ModifiedBy = faq.ModifiedBy;
            faqInDb.ModifiedOn = faq.ModifiedOn;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var faq = _dbContext.Reservations.SingleOrDefault(v => v.Id == id);

            if (faq == null)
                return HttpNotFound();

            return View(faq);
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var faq = _dbContext.Reservations.SingleOrDefault(v => v.Id == id);
            if (faq == null)
                return HttpNotFound();
            _dbContext.Reservations.Remove(faq);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}