using NUnit.Framework;
using Cab_Invoice_Problem;

namespace Cab_Invoice_Tests
{
    public class Tests
    {
        CabInvoiceGenerator cabInvoiceGenerator;
        Ride[] multipleRides;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
            multipleRides = new Ride[] { new Ride(2, 5), new Ride(3, 10),new Ride (0.1,0.5) };
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
            Assert.AreEqual(70, result);
        }

    }
}