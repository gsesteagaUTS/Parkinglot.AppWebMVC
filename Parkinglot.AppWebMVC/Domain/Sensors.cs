using System;

namespace Parkinglot.AppWebMVC.Domain
{
    public class Sensor
    {
        //int A0 = 25;
        public int Pin { get; protected set; }
        public int Value { get; protected set; }
        public SensorType SensorType { get; protected set; }
        public string Name { get; protected set; }
        
        public Sensor ()
        {
            
        }

        public Sensor(int pin, int value, SensorType sensorType, string name)
        {
            Pin = pin;
            Value = value;
            SensorType = sensorType;
            Name = name;
        }
    }
    public class ServoMotor : Sensor
    {
        public ServoMotor()
            : base()
        {
        }
        public ServoMotor(int pin, int value, SensorType sensorType, string name)
            : base(pin, value, sensorType, name)
        {

        }
    }
    public class Pir : Sensor
    {
        public Pir()
            : base()
        {
        }
        public Pir(int pin, int value, SensorType sensorType, string name)
            : base(pin, value, sensorType, name)
        {
        }
    }
}
