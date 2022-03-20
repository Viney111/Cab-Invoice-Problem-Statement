using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Problem
{
    public class RideRepository
    {
        public static Dictionary<string, List<Ride>> mapRideForUser;

        public RideRepository()
        {
            mapRideForUser = new Dictionary<string, List<Ride>>();
        }

        public void AddRidesInMap(string userId, List<Ride> ridesList)
        {
            if (mapRideForUser.ContainsKey(userId))
            {
                mapRideForUser[userId] = ridesList;
            }
            else
            {
                mapRideForUser.Add(userId, ridesList);
            }
        }
        public static List<Ride> GetRideListByUserIDIfAny(string userId)
        {
            try
            {
                return mapRideForUser[userId];
            }
            catch (Exception ex)
            {
                throw new Exception("UserId does not exist");
            }
        }
    }
}
