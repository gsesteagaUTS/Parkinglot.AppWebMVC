using System;

namespace Parkinglot.AppWebMVC.RabbitMq
{
    public class MoveServo
    {

       
        //public string k { get; set; }   //Key
        public int p { get; set; }//PIN
        public int v { get; set; }//Value

        public MoveServo()
        {
            
        }
        
        public MoveServo(int pin, int value) 
        {
                this.p = pin;
                this.v = value;
        }

    }
}
