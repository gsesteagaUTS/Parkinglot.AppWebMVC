using System;

namespace Parkinglot.AppWebMVC.Domain
{
    public class ParkingSpot
    {
        public int Number { get; private set; }
        public bool IsAvailable { get; private set; }

        public ParkingSpotType ParkingSpotType { get; set; }
    
        public Pir Pir { get; private set; }

        public ParkingSpot()
        {
        }

        public ParkingSpot(int number, bool isAvailable, ParkingSpotType parkingSpotType, Pir pir )
        {
            Number = number;
            ParkingSpotType = parkingSpotType;
            Pir = pir;
            IsAvailable = isAvailable;
        }
    }
}
