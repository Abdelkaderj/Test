using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightMonitoring.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        public double Distance { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        [Required]
        [Display(Name = "Aircraft")]
        public int SelectedAircraft { get; set; }

        [Required]
        [StringLength(50,
        ErrorMessage = "The aircraft name cannot be longer than 50 characters")]
        public string AircraftName { get; set; }

        public double FuelRequired { get; set; }


        [Required]
        [Display(Name = "Airport Arrival")]
        public int SelectedAirportArrival { get; set; }


        public String AirportArrivalName { get; set; }


        [Required]
        [Display(Name = "Airport Departure")]
        public int SelectedAirportDeparture { get; set; }

        public String AirportDepartureName { get; set; }

    }
}