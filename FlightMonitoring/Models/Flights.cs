using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FlightMonitoring.Models
{
    public class Flights
    {

        public int Id { get; set; }

        public double Distance { get; set; }

        [Required]
        [Display(Name = "Aircraft")]
        public int SelectedAircraft { get; set; }

        public double FuelRequired { get; set; }

        [Required]
        [Display(Name = "Airport Departure")]
        public int SelectedAirportDeparture { get; set; }


        [Required]
        [Display(Name = "Airport Departure")]
        public int SelectedAirportArrival { get; set; }
        public virtual Aircraft AirCraft { get; set; }

        public virtual Airport AirportDeparture { get; set; }

        public virtual Airport AirportArrival { get; set; }

    }
}