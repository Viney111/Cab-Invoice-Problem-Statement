using System;
using System.Collections.Generic;

namespace Cab_Invoice_Problem
{
    public class CabInvoiceGenerator
    {

        public double GetTotalFareSingleRide(TypeOfRide ride, double distance, double time)
        {
            RideType rideType = new RideType();
            rideType.InitializingDetailsAsPerRideType(ride);
            double singleRideFare = distance * rideType.COST_PER_KM + time * rideType.COST_PER_MINUTE;
            if (singleRideFare < rideType.MINIMUM_FARE)
            {
                return rideType.MINIMUM_FARE;
            }
            return singleRideFare;
        }
        public double GetTotalFareMultipleRide(TypeOfRide typeRides,List<Ride> rides)
        {
            double multipleRideFare = 0;
            foreach(Ride ride in rides)
            {
                multipleRideFare += GetTotalFareSingleRide(typeRides ,ride.distance, ride.time);
            }
            return multipleRideFare;
        }
        public EnhancedInvoiceDetails GetInvoiceDetailsOfRides(TypeOfRide typeRides,List<Ride> rides)
        {
            EnhancedInvoiceDetails invoiceDetails = new EnhancedInvoiceDetails();
            invoiceDetails.GettingDetailsOfInvoiceInObject(typeRides,rides);
            return invoiceDetails;
        }
        public EnhancedInvoiceDetails GetInvoiceByUserId(TypeOfRide typeRides,string userId)
        {
            var userRideList = RideRepository.GetRideListByUserIDIfAny(userId);
            var invoiceDetailsByUserId = GetInvoiceDetailsOfRides(typeRides,userRideList);
            return invoiceDetailsByUserId;
        }
    }
}
