using System;

namespace Parkinglot.AppWebMVC.Domain
{
    public class ContainmentBar
    {
        public AccessType AccessType { get; private set; }
        public ServoMotor ServiMotor { get; private set; }

        public ContainmentBar()
        {
            
        }
        public ContainmentBar(AccessType accessType, ServoMotor serviMotor)
        {
            AccessType = accessType;
            ServiMotor = serviMotor;
        }
    }
}
