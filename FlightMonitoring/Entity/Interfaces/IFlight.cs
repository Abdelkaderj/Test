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
    /// Cette interface contient les fonctions d'ajout et de selection d'un vol.
    /// </summary>
    interface IFlight
    {
        #region
        /// <summary>
        /// Cette fonction permet d'ajouter un vol
        /// </summary>
        /// <param name="Flight">Vol</param>
        void AddFlight(Flights Flight);

        /// <summary>
        /// Cette fonction retourne les vols.
        /// </summary>
        /// <returns>La liste des vols</returns>
        IEnumerable<Flights> GetFlight();
        #endregion

    }
}
