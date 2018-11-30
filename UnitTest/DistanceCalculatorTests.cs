using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightMonitoring.Service.Classes;



namespace UnitTest
{
    [TestClass]
    public class DistanceCalculatorTests
    {
        private DistanceCalculator Service;

        public DistanceCalculatorTests() {
            Service = new DistanceCalculator();
        }
        //Cas de test 1
        [TestMethod]
        public void ReturnDistanceGivenGpsCoordinates()
        {
            var TotalDistanceInKm = Service.GetDistanceFromLatitudeLongitudeInKM(50.9151165, -2.1853714, 40.622202, -104.344002);
            Assert.AreEqual(8192.24, TotalDistanceInKm);
        }

        //Cas de test 2
        [TestMethod]
        public void ReturnPositiveDistanceGivenGpsCoordinates()
        {
            var TotalDistanceInKm = Service.GetDistanceFromLatitudeLongitudeInKM(50.9151165, -2.1853714, 40.622202, -104.344002);
            Assert.AreEqual(8192.24, TotalDistanceInKm);
        }

        [TestMethod]
        public void ReturnComputedFuelConsumptionGivenAircraftFuelConsumptionAndDistance()
        {
            var TotalDistanceInKm = Service.GetDistanceFromLatitudeLongitudeInKM(50.9151165, -2.1853714, 40.622202, -104.344002);
            var ConsumedFuel = Service.ComputeFuelConsumption(1203, TotalDistanceInKm);
            Assert.AreEqual(9855264.72, ConsumedFuel);
        }

        [TestMethod]
        public void ReturnNotNullGetAircraft()
        {
            Assert.IsNotNull(Service.GetAircraft());

        }

        [TestMethod]
        public void ReturnNotNullGetAirport()
        {
            Assert.IsNotNull(Service.GetAirport());

        }

        [TestMethod]
        public void ReturnNotNullGetAirportById()
        {
            Assert.IsNotNull(Service.GetAirport(1));

        }

        [TestMethod]
        public void ReturnNotNullGetFlights()
        {
            Assert.IsNotNull(Service.GetFlight());

        }

        [TestMethod]
        public void ReturnNotNullGetAircraftById()
        {
            Assert.IsNotNull(Service.GetAircraft(1));

        }






    }
}
