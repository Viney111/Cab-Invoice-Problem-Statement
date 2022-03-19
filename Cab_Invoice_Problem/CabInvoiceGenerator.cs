using System;
using System.Collections.Generic;

namespace Cab_Invoice_Problem
{
    public class CabInvoiceGenerator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FARE = 5;
        public double GetTotalFare(double distance, double time)
        {
            double singleRideFare = distance * COST_PER_KM + time * COST_PER_MINUTE;
            if (singleRideFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return singleRideFare;
        }
    }
}
