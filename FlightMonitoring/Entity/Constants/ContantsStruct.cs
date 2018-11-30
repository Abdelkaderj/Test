using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightMonitoring.Service.Constants
{

    /*
    Auteur:AJ
    Structure des constants utilisée dans le calcule de la distance
   */
    /// <summary>
    /// Cette sturcture contient les contants utilisées dans la calculation de la distance entre deux aéroports 
    /// </summary>
    public struct ContantsStruct
    {
        #region Constants du rayon et méridien de la terre
        public const double EarthRadiusInKM = 6371;
        public const double EarthMeridian = 180;
        #endregion


    }
}