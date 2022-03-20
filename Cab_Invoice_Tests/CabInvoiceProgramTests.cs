using NUnit.Framework;
using Cab_Invoice_Problem;
using System.Collections.Generic;

namespace Cab_Invoice_Tests
{
    public class Tests
    {
        CabInvoiceGenerator cabInvoiceGenerator;
        List<EnhancedInvoiceDetails> enhancedInvoiceList;
        Ride[] multipleRides;

        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
            multipleRides = new Ride[] { new Ride(2, 10), new Ride(3, 10),new Ride (0.1,0.5),new Ride (0.1,0.5) };
            enhancedInvoiceList = cabInvoiceGenerator.GetInvoiceDetailsOfRides(multipleRides);
        }

        [Test]
        public void GivenDistanceAndTimeForSingleRide_InvoiceGenerator_ReturnTotalFare()
        {
            double result = cabInvoiceGenerator.GetTotalFareSingleRide(5,10);
            Assert.AreEqual(60,result);
        }
        [Test]
        public void GivenDistanceAndTimeForSingleRide_LessThanMinFare_InvoiceGenerator_ReturnMinimumFare()
        {
            double result = cabInvoiceGenerator.GetTotalFareSingleRide(0.1, 0.5);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void GivenDistanceAndTimeForMultipleRide_InvoiceGenerator_ReturnTotalFare()
        {
            double result = cabInvoiceGenerator.GetTotalFareMultipleRide(multipleRides);
            Assert.AreEqual(80, result);
        }
        [Test]
        public void GivenDistanceAndTimeForMultipleRide_InvoiceGenerator_ReturnListofInvoiceDetails()
        {
            var details = enhancedInvoiceList[0];
            double totalFare = details.totalFare; double avgFare = details.averageFarePerRide; int noOfRides = details.totalNumberOfRides;
            Assert.AreEqual(80, totalFare);
            Assert.AreEqual(20, avgFare);
            Assert.AreEqual(4, noOfRides);
        }
    }
}