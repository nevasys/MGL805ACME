using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class ReservationsController : Controller
    {
        
        private ApplicationDbContext _dbContext;

        public ReservationsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Reservations
        public ActionResult Index()
        {

            var reservations = _dbContext.Reservations.ToList();

            return View(reservations);
        }


        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var reservation = _dbContext.Reservations.SingleOrDefault(v => v.Id == id);

            if (reservation == null)
                return HttpNotFound();

            return View(reservation);
        }

        [HttpPost]
        public ActionResult Update(Reservation reservation)
        {
            var reservationInDb = _dbContext.Reservations.SingleOrDefault(v => v.Id == reservation.Id);

            if (reservationInDb == null)
                return HttpNotFound();

            reservationInDb.ClientId = reservation.ClientId;
            reservationInDb.CarInventoryId = reservation.CarInventoryId;
            reservationInDb.DailyRate = reservation.DailyRate;
            reservationInDb.DateEnd = reservation.DateEnd;
            reservationInDb.DateStart = reservation.DateStart;
            reservationInDb.Days = reservation.Days;
            reservationInDb.Discount = reservation.Discount;
            reservationInDb.OdometerEnd = reservation.OdometerEnd;
            reservationInDb.OdometerStart = reservation.OdometerStart;
            reservationInDb.ReservationStatus = reservation.ReservationStatus;
            reservationInDb.Tax = reservation.Tax;
            reservationInDb.IsActive = reservation.IsActive;
            reservationInDb.CreatedBy = reservation.CreatedBy;
            reservationInDb.CreatedOn = reservation.CreatedOn;
            reservationInDb.ModifiedBy = reservation.ModifiedBy;
            reservationInDb.ModifiedOn = reservation.ModifiedOn;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var reservation = _dbContext.Reservations.SingleOrDefault(v => v.Id == id);

            if (reservation == null)
                return HttpNotFound();

            return View(reservation);
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var reservation = _dbContext.Reservations.SingleOrDefault(v => v.Id == id);
            if (reservation == null)
                return HttpNotFound();
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}