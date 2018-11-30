using NUnit.Framework;
using FlightMonitoring.Service.Classes;
using System;



namespace Tests
{
    public class DistanceCalculatorTests
    {


        [SetUp]
        public void Setup()
        {
            DistanceCalculator Service = new DistanceCalculator();

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}