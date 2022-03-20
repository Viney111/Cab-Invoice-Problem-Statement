using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Problem
{
    public class EnhancedInvoiceDetails : CabInvoiceGenerator
    {
        public int totalNumberOfRides { get; set; }
        public double totalFare { get; set; }
        public double averageFarePerRide { get; set; }

        public object GettingDetailsOfInvoiceInObject(Ride[] rides)
        {
            this.totalFare = GetTotalFareMultipleRide(rides);
            this.totalNumberOfRides = rides.Length;
            this.averageFarePerRide = this.totalFare / this.totalNumberOfRides;
            return this;
        }
    }
}
