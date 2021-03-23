using System;

namespace Parkinglot.AppWebMVC.Domain
{
    public enum AccessType
    {
        Entry = 0,
        Exit = 1,
        Other
    }

    public enum SensorType {
        Analog=0,
        Digital,
        PWM
    }

    public enum ParkingSpotType{
        Car=0,
        Motorcycle,
    }

}
