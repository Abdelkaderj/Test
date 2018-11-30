using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightMonitoring.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class Aircraft
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50,
        ErrorMessage = "The aircraft name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The fuel consumption must be entered")]
        public double FuelConsumptionPerKM { get; set; }




    }
}