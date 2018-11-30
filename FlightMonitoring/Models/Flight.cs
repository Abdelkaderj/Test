using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FlightMonitoring.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public double Distance { get; set; }

        [Required]
        [Display(Name = "Aircraft")]
        public int SelectedAircraft { get; set; }

        public double FuelRequired { get; set; }

        [Required]
        public SelectList AirCraft { get; set; }

        [Required]
        [Display(Name = "Airport Arrival")]
        public int SelectedAirportArrival { get; set; }

        public SelectList AirportArrival { get; set; }

        [Required]
        [Display(Name = "Airport Departure")]
        public int SelectedAirportDeparture { get; set; }

        public SelectList AirportDeparture { get; set; }


    }
}