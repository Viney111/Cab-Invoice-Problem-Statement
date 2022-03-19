using NUnit.Framework;
using Cab_Invoice_Problem;

namespace Cab_Invoice_Tests
{
    public class Tests
    {
        CabInvoiceGenerator cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        [Test]
        public void GivenDistanceAndTimeForSingleRide_InvoiceGenerator_ReturnTotalFare()
        {
            double result = cabInvoiceGenerator.GetTotalFare(5,10);
            Assert.AreEqual(60,result);
        }
        [Test]
        public void GivenDistanceAndTimeForSingleRide_LessThanMinFare_InvoiceGenerator_ReturnMinimumFare()
        {
            double result = cabInvoiceGenerator.GetTotalFare(0.1, 0.5);
            Assert.AreEqual(5, result);
        }
    }
}