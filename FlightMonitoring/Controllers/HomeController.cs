using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlightMonitoring.Models;
using FlightMonitoring.Entity.Middle;


namespace FlightMonitoring.Controllers
{

    /*
   Auteur:AJ
   La classe HomeController
   Contient les actions du HomeController
  */

    /// <summary>
    /// La classe <c>HommeController</c> contient les actions du controlleur. 
    /// </summary>
    public class HomeController : Controller
    {

        #region Variables public
        public DistanceCalculatorMiddle DistanceCalculatorMiddle; //
        public IList<Airport> AirportList;//List des aéroports 
        public IList<Aircraft> AircraftList;//List des avions 
        public Airport DepartAirport;//L'aéroport de départ
        public Airport ArrivalAirport;// L'aéroport de d'arrivée 
        public Aircraft AircraftObject; //Objet de type aircraft
        public FlightViewModel FlightViewModel;//View Model de Flight
        public double TotalDistance;//La distance totale 
        public double AircraftFuelRequired;//La distance totale 
        #endregion




        #region Functions d'initialisation du controleur

        /// <summary>
        /// Méthode d'initialisation du service
        /// </summary>
        public void InitializeService()
        {
            DistanceCalculatorMiddle = new DistanceCalculatorMiddle();
            AirportList = DistanceCalculatorMiddle.GetAirport().ToList();
            AircraftList = DistanceCalculatorMiddle.GetAircraft().ToList();
        }

        /// <summary>
        /// Constructeur de la classe <c>HomeController</c>
        /// </summary>
        public HomeController()
        {
            InitializeService();
        }

        #endregion


        #region Actions du controlleur

        /// <summary>
        /// Action de la vue index
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action de la vue ComputedDistance
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public ActionResult ComputedDistance(FlightViewModel model)
        {
            return View(model);
        }


        /// <summary>
        /// Action permet la sauvegarde d'un vol 
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Save(FlightViewModel model)
        {
            Flights FlyingAircraft = CreateFlight(model);

            DistanceCalculatorMiddle.AddFlight(FlyingAircraft);

            return View("ComputedDistance");
        }

        /// <summary>
        /// Action permettant l'accès du view model à la vue report
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult ComputedDistance()
        {

            return RedirectToAction("Report", FlightViewModel);
        }

        /// <summary>
        /// Action  de la vue airport 
        /// </summary>
        public ActionResult Airport()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }

        /// <summary>
        /// Action qui permet l'ajout d'un aéroport
        /// </summary>
        /// <param name="airport">aéroport à ajouter</param>
        /// <returns>un</returns>
        [HttpPost]
        public ActionResult Airport(Airport airport)
        {
            if (ModelState.IsValid)
            {
                DistanceCalculatorMiddle.AddAirport(airport);
                return View(airport);
            }
            return View(airport);
        }


        /// <summary>
        /// Action qui retourne la vue aircraft
        /// </summary>
        /// <returns></returns>
        public ActionResult Aircraft()
        {

            return View();
        }

        /// <summary>
        /// Action permettant d'ajouter un aéroport 
        /// </summary>
        /// <param name="aircraft">aircraft</param>
        /// <returns>aircraft</returns>
        [HttpPost]
        public ActionResult Aircraft(Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                DistanceCalculatorMiddle.AddAircraft(aircraft);
                return View(aircraft);
            }
            return View(aircraft);
        }

        /// <summary>
        /// Action permettant de remplir la dropdownlist
        /// </summary>
        /// <returns></returns>
        public ActionResult Distance()
        {
            Flight FlyingAircraftModel = new Flight();
            FillViewDrobDownList(FlyingAircraftModel);

            return View(FlyingAircraftModel);
        }




        /// <summary>
        /// Action permettant d'initialiser les ViewModels pour l'affichage dans le rapport 
        /// </summary>
        /// <returns></returns>
        public ActionResult FlightReport()
        {
            IEnumerable<Flights> FlightsReport;
            IEnumerable<Airport> AirportDeparture, AirportArrival;
            IEnumerable<Aircraft> Aircraft;
            List<FlightViewModel> FlightViewModel;
            FlightViewModel FlightViewModelObject;
            InitializeViewModel(out FlightsReport, out FlightViewModel, out FlightViewModelObject);

            foreach (var FlightReport in FlightsReport)
            {
                //Récupération de l'aéroport de départ
                AirportDeparture = DistanceCalculatorMiddle.GetAirport(FlightReport.SelectedAirportDeparture);
                
                foreach (var Airport in AirportDeparture)
                {
                    FlightViewModelObject.AirportDepartureName = Airport.Name;

                }

                //Récupération de l'aéroport d'arrivée
                AirportArrival = DistanceCalculatorMiddle.GetAirport(FlightReport.SelectedAirportArrival);
                foreach (var Airport in AirportArrival)
                {
                    FlightViewModelObject.AirportArrivalName = Airport.Name;

                }
                //Récupération de l'avion du vol
                Aircraft = DistanceCalculatorMiddle.GetAircraft(FlightReport.SelectedAircraft);
                foreach (var aircraft in Aircraft)
                {
                    FlightViewModelObject.AircraftName = aircraft.Name;
                }

                //Récupération de la distance
                FlightViewModelObject.Distance = FlightReport.Distance;
                //Récupération du carburant requis 
                FlightViewModelObject.FuelRequired = FlightReport.FuelRequired;
                //Récupération de l'identifant de l'avion du vol
                FlightViewModelObject.Id = FlightReport.Id;
                //Construction du view model et ajout dans le view model
                FlightViewModel.Add(FlightViewModelObject);
            }

            return View(FlightViewModel);


        }

        /// <summary>
        /// Action permettant le calcule de la distance entre les aéroports
        /// </summary>
        /// <param name="model">Flight model</param>
        /// <returns>FlightViewModel</returns>
        [HttpPost]
        public ActionResult Distance(Flight model)
        {
            ArrivalAirport = new Airport();
            DepartAirport = new Airport();
            AircraftObject = new Aircraft();
            //Parcours de la liste des aéroports
            foreach (var Airport in AirportList)
            {
                if (Airport.Id.Equals(model.SelectedAirportDeparture))
                {
                    DepartAirport = Airport;
                }

                if (Airport.Id.Equals(model.SelectedAirportArrival))
                {
                    ArrivalAirport = Airport;
                }
            }
            //Parcours de la liste des avions
            foreach (var Aircraft in AircraftList)
            {
                if (Aircraft.Id.Equals(model.SelectedAircraft))
                {
                    AircraftObject = Aircraft;
                }
            }

            //Calcule de distance totale
            TotalDistance = DistanceCalculatorMiddle.GetDistanceFromLatitudeLongitudeInKM(DepartAirport.Latitude, DepartAirport.Longititude, ArrivalAirport.Latitude, ArrivalAirport.Longititude);

            //Calcule du carburant 
            AircraftFuelRequired = DistanceCalculatorMiddle.ComputeFuelConsumption(AircraftObject.FuelConsumptionPerKM, TotalDistance);

            //Initialisation du view model
            InizialiseFlightViewModel();
            return RedirectToAction("ComputedDistance", FlightViewModel);
        }

        #endregion



        #region Fonctions privées d'initialisation des views models et des DropDownLists

        /// <summary>
        /// Function d'initialisation des view models
        /// </summary>
        /// <param name="FlightsReport">FlightsReport</param>
        /// <param name="FlightViewModelList">FlightViewModelList</param>
        /// <param name="FlightViewModel">FlightViewModel</param>
        private void InitializeViewModel(out IEnumerable<Flights> FlightsReport, out List<FlightViewModel> FlightViewModelList, out FlightViewModel FlightViewModel)
        {
            FlightsReport = DistanceCalculatorMiddle.GetFlight();
            FlightViewModelList = new List<FlightViewModel>();
            FlightViewModel = new FlightViewModel();
        }

        /// <summary>
        /// Fonction d'initialisation du FlyingAircraftModel
        /// </summary>
        /// <param name="FlyingAircraftModel">FlyingAircraftModel</param>
        private void FillViewDrobDownList(Flight FlyingAircraftModel)
        {
            FlyingAircraftModel.AirportDeparture = new SelectList(AirportList, "Id", "Name");
            FlyingAircraftModel.AirportArrival = new SelectList(AirportList, "Id", "Name");
            FlyingAircraftModel.AirCraft = new SelectList(AircraftList, "Id", "Name");
        }

        /// <summary>
        /// Fonction d'initialisation du FlightViewModel
        /// </summary>
        private void InizialiseFlightViewModel()
        {
            FlightViewModel = new FlightViewModel
            {
                SelectedAircraft = AircraftObject.Id,
                Distance = TotalDistance,
                FuelRequired = AircraftFuelRequired,
                SelectedAirportArrival = ArrivalAirport.Id,
                AirportArrivalName = ArrivalAirport.Name,
                AirportDepartureName = DepartAirport.Name,
                AircraftName = AircraftObject.Name,
                SelectedAirportDeparture = DepartAirport.Id
            };
        }

        /// <summary>
        /// Fonction pertmettant de créer un vol
        /// </summary>
        /// <param name="model">FlightViewModel</param>
        /// <returns></returns>
        private static Flights CreateFlight(FlightViewModel model)
        {
            return new Flights
            {
                Distance = model.Distance,
                SelectedAircraft = model.SelectedAircraft,
                FuelRequired = model.FuelRequired,
                SelectedAirportArrival = model.SelectedAirportArrival,
                SelectedAirportDeparture = model.SelectedAirportDeparture
            };
        }

        #endregion


    }
}