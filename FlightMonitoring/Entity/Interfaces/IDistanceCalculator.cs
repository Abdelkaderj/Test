using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightMonitoring.Service.Interfaces
{

    /*
    Auteur:AJ
    Cette interface contient les fonctions à implementer dans le service
   */
    /// <summary>
    /// Cette interface contient les fonctions de calcule de la distance.
    /// </summary>
    interface IDistanceCalculator
    {

        #region Fonctions de calcule de la distance
        /// <summary>
        /// Cette fonction retourne la distance entre deux positions GPS (latitude et longitude)
        /// </summary>
        /// <param name="latitude1">Latitude du premier aéroport  </param>
        /// <param name="longitude1">Longitude du premier aéroport </param>
        /// <param name="latitude2">Latidude du deuxieme aéroport</param>
        /// <param name="longitude2">Longitude du deuxieme aéroport</param>
        /// <returns>La distance entre deux aéroports </returns>
        double GetDistanceFromLatitudeLongitudeInKM(double latitude1, double longitude1, double latitude2, double longitude2);

        /// <summary>
        /// Cette fonction retourne la valeur de la convertion radian
        /// </summary>
        /// <param name="degree">Le degree des coordonnées latitude et longitude </param>
        /// <returns>La convertion radian</returns>
        double GetDegreeToRadiusConvertion(double degree);

        #endregion

    }
}
