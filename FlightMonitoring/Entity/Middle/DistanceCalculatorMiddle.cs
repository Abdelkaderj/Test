using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightMonitoring.Service.Classes;
using FlightMonitoring.Models;



namespace FlightMonitoring.Entity.Middle
{
    /*
    Auteur:AJ
    La classe DistanceCalculatorMiddle
    Contient les appeles aux service
   */
   /// <summary>
   /// La classe <c>DistanceCalculatorMiddle</c> contient les appels aux méthodes services.
   /// </summary>

    public class DistanceCalculatorMiddle : DistanceCalculator
    {

        #region Variables public
        //Variable d'initialisation du service
        public DistanceCalculator DistanceCalulatorService;

        #endregion


        #region Service initialisation


        /// <summary>
        /// Fonction de l'initialisation du service
        /// </summary>
        public override void InitializeService()
        {

            DistanceCalulatorService = new DistanceCalculator();


        }
        /// <summary>
        /// Constructeur de la classe <c>DistanceCalculatorMiddle</c>
        /// </summary>
        public DistanceCalculatorMiddle()
        {

            InitializeService();

        }
        #endregion

        #region Fonctions public

        /// <summary>
        /// Cette fonction retourne la distance entre deux positions GPS (latitude et longitude)
        /// </summary>
        /// <param name="latitude1">Latitude du premier aéroport  </param>
        /// <param name="longitude1">Longitude du premier aéroport </param>
        /// <param name="latitude2">Latidude du deuxieme aéroport</param>
        /// <param name="longitude2">Longitude du deuxieme aéroport</param>
        /// <returns>La distance entre deux aéroports </returns>
        public override double GetDistanceFromLatitudeLongitudeInKM(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            return DistanceCalulatorService.GetDistanceFromLatitudeLongitudeInKM(latitude1, longitude1, latitude2, longitude2);
        }

        /// <summary>
        /// Cette fonction retourne la consommation de l'avion pour une distance
        /// </summary>
        /// <param name="consumptionPerKM">La consommation de l'avion par KM</param>
        /// <param name="totalDistance">La distance totale du trajet</param>
        /// <returns> la consommation de l'avion pour une distance</returns>
        public override double ComputeFuelConsumption(double consumptionPerKM, double totalDistance)
        {
            return DistanceCalulatorService.ComputeFuelConsumption(consumptionPerKM, totalDistance);
        }


        /// <summary>
        /// Cette fonction permet d'ajouter un avion
        /// </summary>
        /// <param name="aircraft">Représente un avion</param>
        public override void AddAircraft(Aircraft aircraft)
        {
            DistanceCalulatorService.AddAircraft(aircraft);
        }

        /// <summary>
        /// Cette fonction permet d'ajouter un aéroport
        /// </summary>
        /// <param name="airport">Represent un aéroport</param>
        public override void AddAirport(Airport airport)
        {
            DistanceCalulatorService.AddAirport(airport);
        }

        /// <summary>
        /// Cette fonction retourn une liste d'aéroport
        /// </summary>
        /// <returns>Liste d'aéroport</returns>
        public override IEnumerable<Airport> GetAirport()
        {
            return DistanceCalulatorService.GetAirport();
        }

        /// <summary>
        /// Cette fonction retourn une liste d'aéroport
        /// </summary>
        /// <param name="id">id de l'aéroport</param>
        /// <returns>Liste d'aéroport</returns>
        public override IEnumerable<Airport> GetAirport(int id)
        {
            return DistanceCalulatorService.GetAirport(id);
        }

        /// <summary>
        /// Cette fonction retourne une liste d'avion
        /// </summary>
        /// <returns>Une liste d'avion</returns>
        public override IEnumerable<Aircraft> GetAircraft()
        {
            return DistanceCalulatorService.GetAircraft();
        }

        /// <summary>
        /// Cette fonction retourne une liste d'avion
        /// </summary>
        /// <param name="id">identifiant de l'avion</param>
        /// <returns>Une liste d'avion</returns>
        public override IEnumerable<Aircraft> GetAircraft(int id) {
            return DistanceCalulatorService.GetAircraft(id);

        }

        /// <summary>
        /// Cette fonction permet d'ajouter un vol
        /// </summary>
        /// <param name="Flight">Vol</param>
        public override void AddFlight(Flights flight)
        {
            DistanceCalulatorService.AddFlight(flight);

        }

        /// <summary>
        /// Cette fonction retourne les vols.
        /// </summary>
        /// <returns>La liste des vols</returns>
        public override IEnumerable<Flights> GetFlight()
        {
            return DistanceCalulatorService.GetFlight();
        }


    }
    #endregion
}