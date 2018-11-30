using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightMonitoring.Models;

namespace FlightMonitoring.Entity.Interfaces
{
    /*
     Auteur:AJ
     Cette interface contient les fonctions à implementer dans le service
    */
    /// <summary>
    /// Cette interface contient les fonctions d'ajout et de selection d'aéroports.
    /// </summary>
    interface IAirport
    {

        #region Fonctions d'ajout et de selection d'aéroports
        /// <summary>
        /// Cette fonction permet d'ajouter un aéroport
        /// </summary>
        /// <param name="airport">Represent un aéroport</param>
        void AddAirport(Airport airport);

        /// <summary>
        /// Cette fonction retourn une liste d'aéroport
        /// </summary>
        /// <returns>Liste d'aéroport</returns>
        IEnumerable<Airport> GetAirport();

        /// <summary>
        /// Cette fonction retourn une liste d'aéroport
        /// </summary>
        /// <param name="id">id de l'aéroport</param>
        /// <returns>Liste d'aéroport</returns>
        IEnumerable<Airport> GetAirport(int id);
        #endregion
    }
}
