using NUnit.Framework;
using Cab_Invoice_Problem;
using System.Collections.Generic;
using System.Linq;

namespace Cab_Invoice_Tests
{
    public class Tests
    {
        CabInvoiceGenerator cabInvoiceGenerator;
        RideRepository rideRepository;
        List<Ride> multipleRides1;
        List<Ride> multipleRides2;

        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
            multipleRides1 = new List<Ride> { new Ride(2, 10), new Ride(3, 10),new Ride (0.1,0.5),new Ride (0.1,0.5) };
            multipleRides2 = new List<Ride> { new Ride(0.1, 0.5), new Ride(0.1, 0.5) };
            rideRepository = new RideRepository();
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
            double result = cabInvoiceGenerator.GetTotalFareMultipleRide(multipleRides1);
            Assert.AreEqual(80, result);
        }
        [Test]
        public void GivenDistanceAndTimeForMultipleRide_InvoiceGenerator_ReturnListofInvoiceDetails()
        {
            var invoiceDetails = cabInvoiceGenerator.GetInvoiceDetailsOfRides(multipleRides1);
            Assert.AreEqual(20,invoiceDetails.averageFarePerRide);           
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnAverageFare()
        {
            rideRepository.AddRidesInMap("Viney111", multipleRides1);
            rideRepository.AddRidesInMap("Yash111", multipleRides2);
            var invoiceDetailsFor_Viney = cabInvoiceGenerator.GetInvoiceByUserId("Viney111");
            var invoiceDetailsFor_Yash = cabInvoiceGenerator.GetInvoiceByUserId("Yash111");
            Assert.AreEqual(20, invoiceDetailsFor_Viney.averageFarePerRide);
            Assert.AreEqual(5, invoiceDetailsFor_Yash.averageFarePerRide);
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnTotalFare()
        {
            rideRepository.AddRidesInMap("Viney111", multipleRides1);
            rideRepository.AddRidesInMap("Yash111", multipleRides2);
            var invoiceDetailsFor_Viney = cabInvoiceGenerator.GetInvoiceByUserId("Viney111");
            var invoiceDetailsFor_Yash = cabInvoiceGenerator.GetInvoiceByUserId("Yash111");
            Assert.AreEqual(80, invoiceDetailsFor_Viney.totalFare);
            Assert.AreEqual(10, invoiceDetailsFor_Yash.totalFare);
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnNumberOfRides()
        {
            rideRepository.AddRidesInMap("Viney111", multipleRides1);
            rideRepository.AddRidesInMap("Yash111", multipleRides2);
            var invoiceDetailsFor_Viney = cabInvoiceGenerator.GetInvoiceByUserId("Viney111");
            var invoiceDetailsFor_Yash = cabInvoiceGenerator.GetInvoiceByUserId("Yash111");
            Assert.AreEqual(4, invoiceDetailsFor_Viney.totalNumberOfRides);
            Assert.AreEqual(2, invoiceDetailsFor_Yash.totalNumberOfRides);
        }
    }
}