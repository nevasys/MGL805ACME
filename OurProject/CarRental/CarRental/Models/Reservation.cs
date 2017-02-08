using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CarInventory")]
        public int CarInventoryId { get; set; }
        public virtual CarInventory CarInventory { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int OdometerStart { get; set; }
        public int OdometerEnd { get; set; }
        public int Days { get; set; }
        public float DailyRate { get; set; }
        public float Tax { get; set; }
        public float Discount { get; set; }
        public reservationStatus ReservationStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }

    public enum reservationStatus
    {
        Réservé = 1,
        SurLaRoute,
        Retourné,
        CancelléParClient,
        CancelléParAgence,
        CancelléParAdmin
    }
}