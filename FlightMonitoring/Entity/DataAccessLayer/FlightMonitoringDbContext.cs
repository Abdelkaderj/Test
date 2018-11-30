using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FlightMonitoring.Models;
using FlightMonitoring.Entity.Interfaces;



namespace FlightMonitoring.Entity.DataAccessLayer
{
    /*
     Auteur:AJ
     La classe FlightMonitoringDbContext
     Contient toutes les méthodes d'accès à la base de données
    */
    /// <summary>
    /// La class <c>FlightMonitoringDbContext</c> contient les méthodes d'accès à la base de données
    /// </summary>
    public class FlightMonitoringDbContext : DbContext,IAircraft, IAirport,IFlight
    {
        #region Variables de context
        public DbSet<Aircraft> AircraftDb { get; set; }
        public DbSet<Airport> AirportDb { get; set; }
        public DbSet<Flights> FlighsDb { get; set; }

        #endregion

        /// <summary>
        /// Cette fonction ajoute un avion dans la base de donnée.
        /// </summary>
        /// <param name="aircraft">un objet de type aircraft</param>
        public void AddAircraft(Aircraft aircraft)
        {
            AircraftDb.Add(aircraft);
            this.SaveChanges();  

        }
        /// <summary>
        /// Cette fonction ajoute un aéroport dans la base de donnée.
        /// </summary>
        /// <param name="airport">un objet de type airport</param>
        public void AddAirport(Airport airport)
        {
            AirportDb.Add(airport);
            this.SaveChanges();
        }

        /// <summary>
        /// Cette fonction ajoute un vol dans la base de donnée.
        /// </summary>
        /// <param name="flights">un objet de type flights</param>
        public void AddFlight(Flights flights)
        {
            FlighsDb.Add(flights);
            this.SaveChanges();
        }

        /// <summary>
        /// Cette fonction Retourne une liste des avions
        /// </summary>
        /// <returns>la liste des avions</returns>
        public IEnumerable<Aircraft> GetAircraft() {


            return AircraftDb.Select(a => a);

        }

        /// <summary>
        /// Cette fonction retourne un avion
        /// </summary>
        /// <param name="id">Identifiant de l'avion</param>
        /// <returns>La liste des avions</returns>
        public IEnumerable<Aircraft> GetAircraft(int id)
        {

            return AircraftDb.Where(a => a.Id == id).Select(a => a);

        }

        /// <summary>
        /// Cette fonction retourne une liste d'aéroports
        /// </summary>
        /// <returns>La liste des avions</returns>
        public IEnumerable<Airport> GetAirport() {

            return AirportDb.Select(a => a);

        }

        /// <summary>
        /// Cette fonction retourn un aéroport
        /// </summary>
        /// <param name="id">Identifiant de l'avion</param>
        /// <returns>un avion</returns>
        public IEnumerable<Airport> GetAirport(int id)
        {

            return AirportDb.Where(a => a.Id == id).Select(a => a);

        }

        /// <summary>
        /// Cette fonction retourn une liste de vols
        /// </summary>
        /// <returns>Liste de vols</returns>
        public IEnumerable<Flights> GetFlight()
        {
            return FlighsDb.Select(a => a);
        }
    }
}