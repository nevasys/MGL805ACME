using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set;  }
        public string model { get; set;  }
        public string Description { get; set; }
        public carType Type { get; set; }
        public int HorsePower { get; set; }
        public numberOfDoor NumberOfDoors { get; set; }
        public float DailyRate { get; set;  }
        public Boolean IsActive { get; set; }
        public numberOfPassenger NumberOfPassenger { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }

    public enum carType
    {
        SousCompacte = 1,
        Compacte,
        Moyenne,
        Grande,
        ToutTerrains,
        Luxe
    }

    public enum numberOfDoor
    {
        Une=1,
        Deux,
        Trois,
        Quatre,
        Cinq,
        Six
    }

    public enum numberOfPassenger
    {
        Un = 1,
        Deux,
        Trois,
        Quatre,
        Cinq,
        Six,
        Sept
    }
}