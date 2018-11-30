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
   /// Cette interface contient les fonctions d'ajout et de selection d'avion.
   /// </summary>
    interface IAircraft
    {

        #region Fonctions d'ajout et de selection d'avion 
        /// <summary>
        /// Cette fonction permet d'ajouter un avion
        /// </summary>
        /// <param name="aircraft">Représente un avion</param>
        void AddAircraft(Aircraft aircraft);

        /// <summary>
        /// Cette fonction retourne une liste d'avion
        /// </summary>
        /// <returns>Une liste d'avion</returns>
        IEnumerable<Aircraft> GetAircraft();
    
        /// <summary>
        /// Cette fonction retourne une liste d'avion
        /// </summary>
        /// <param name="id">identifiant de l'avion</param>
        /// <returns>Une liste d'avion</returns>
        IEnumerable<Aircraft> GetAircraft(int id);
        #endregion



    }
}
