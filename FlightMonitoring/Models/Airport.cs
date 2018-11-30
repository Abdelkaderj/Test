using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightMonitoring.Models
{
    public class Airport
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        [Required]
        [StringLength(50,
        ErrorMessage = "The airport name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The airport Latitude must be entred")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "The airport Longititude must be entred")]
        public double Longititude { get; set; }
       


    }
}