using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightMonitoring.Service.Interfaces;
using FlightMonitoring.Service.Constants;
using FlightMonitoring.Entity.Interfaces;
using FlightMonitoring.Entity.DataAccessLayer;
using FlightMonitoring.Models;

namespace FlightMonitoring.Service.Classes
{
    /*
    Auteur:AJ
    La classe DistanceCalculator
    Contient le service du calcule de la distance
   */
    /// <summary>
    /// La classe <c>DistanceCalculator</c> contient les fonctions service qui permet le calcule de la
    /// de distance entre deux aéroports 
    /// </summary>
    public class DistanceCalculator : IDistanceCalculator,IAircraft,IAirport, IFlight
    {

        #region Variables public

        public double AngleA { get; set; }//Angle A 
        public double AngleB { get; set; } //Angle B
        public double AngleC { get; set; } //Angle C

        public double DistanceLatitude { get; set; } //Distance de Latitude
        public double DistanceLongitude { get; set; }//Distance de Longitude

        public double Distance { get; set; }//La distance calculée

        public FlightMonitoringDbContext FlightMonitoringDAL;// Instance FlightMonitoringDAL pour l'accès aux données

        #endregion

        #region Service initialisation

        /// <summary>
        /// Fonction de l'initialisation du service
        /// </summary>
        public virtual void InitializeService()
        {

            FlightMonitoringDAL = new FlightMonitoringDbContext();
        }

        /// <summary>
        /// Constructeur de la classe <c>DistanceCalculator</c>
        /// </summary>
        public DistanceCalculator()
        {
            InitializeService();
        }
        #endregion

        #region Fonctions publiques
        /// <summary>
        /// Cette fonction retourne la distance entre deux positions GPS (latitude et longitude)
        /// </summary>
        /// <param name="latitude1">Latitude du premier aéroport  </param>
        /// <param name="longitude1">Longitude du premier aéroport </param>
        /// <param name="latitude2">Latidude du deuxieme aéroport</param>
        /// <param name="longitude2">Longitude du deuxieme aéroport</param>
        /// <returns>La distance entre deux aéroports </returns>
        public virtual double GetDistanceFromLatitudeLongitudeInKM(double latitude1, double longitude1, double latitude2, double longitude2)
        {   
            //Récupération de la distance pour la latitude
            DistanceLatitude = GetDegreeToRadiusConvertion(latitude2 - latitude1);

            //Récupération de la distance pour la Longitude 
            DistanceLongitude = GetDegreeToRadiusConvertion(longitude2 - longitude1);
            //Calcule du degree Angle A
            AngleA = Math.Sin(DistanceLatitude / 2) * Math.Sin(DistanceLongitude / 2) +
            Math.Cos(GetDegreeToRadiusConvertion(latitude1)) * Math.Cos(GetDegreeToRadiusConvertion(latitude2)) *
            Math.Sin(DistanceLongitude / 2) * Math.Sin(DistanceLongitude / 2);

            //Calcule du degree Angle C
            AngleC = 2 * Math.Atan2(Math.Sqrt(AngleA), Math.Sqrt(1 - AngleA));

            //récupértion de la valeur de la convertion radian
            Distance = ContantsStruct.EarthRadiusInKM * AngleC;

            return Math.Round(Distance, 2);
        }

        /// <summary>
        /// Cette fonction retourne la valeur de la convertion radian
        /// </summary>
        /// <param name="degree">Le degree des coordonnées latitude et longitude </param>
        /// <returns>La convertion radion</returns>
        public virtual double GetDegreeToRadiusConvertion(double degree)
        {
            return degree * (Math.PI / ContantsStruct.EarthMeridian);
        }

        /// <summary>
        /// Cette fonction retourne la consommation de l'avion pour une distance
        /// </summary>
        /// <param name="consumptionPerKM">La consommation de l'avion par KM</param>
        /// <param name="totalDistance">La distance totale du trajet</param>
        /// <returns> la consommation de l'avion pour une distance</returns>
        public virtual double ComputeFuelConsumption(double consumptionPerKM, double totalDistance)
        {
            return Math.Round(consumptionPerKM * totalDistance, 2);
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un avion
        /// </summary>
        /// <param name="aircraft">Représente un avion</param>
        public virtual void AddAircraft(Aircraft aircraft)
        {
            FlightMonitoringDAL.AddAircraft(aircraft);
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un aéroport
        /// </summary>
        /// <param name="airport">Represent un aéroport</param>
        public virtual void AddAirport(Airport airport)
        {
            FlightMonitoringDAL.AddAirport(airport);
        }

        /// <summary>
        /// Cette fonction retourn une liste d'aéroport
        /// </summary>
        /// <returns>Liste d'aéroport</returns>
        public virtual IEnumerable<Airport> GetAirport()
        {
            return FlightMonitoringDAL.GetAirport();
        }

        /// <summary>
        /// Cette fonction retourn une liste d'aéroport
        /// </summary>
        /// <param name="id">id de l'aéroport</param>
        /// <returns>Liste d'aéroport</returns>
        public virtual IEnumerable<Airport> GetAirport(int id)
        {

            return FlightMonitoringDAL.GetAirport(id);
        }

        /// <summary>
        /// Cette fonction retourne une liste d'avion
        /// </summary>
        /// <returns>Une liste d'avion</returns>
        public virtual IEnumerable<Aircraft> GetAircraft()
        {
            return FlightMonitoringDAL.GetAircraft();
        }

        /// <summary>
        /// Cette fonction retourne une liste d'avion
        /// </summary>
        /// <param name="id">identifiant de l'avion</param>
        /// <returns>Une liste d'avion</returns>
        public virtual IEnumerable<Aircraft> GetAircraft(int id)
        {
            return FlightMonitoringDAL.GetAircraft(id);
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un vol
        /// </summary>
        /// <param name="Flight">Vol</param>
        public virtual void AddFlight(Flights Flight)
        {
            FlightMonitoringDAL.AddFlight(Flight);
        }

        /// <summary>
        /// Cette fonction retourne les vols.
        /// </summary>
        /// <returns>La liste des vols</returns>
        public virtual IEnumerable<Flights> GetFlight()
        {
            return FlightMonitoringDAL.GetFlight();
        }

        #endregion

    }

  
}