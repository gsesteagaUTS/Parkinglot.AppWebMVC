using System;

namespace Parkinglot.AppWebMVC.Commands.CommandExceptions
{
    public class UserRegisteredException : Exception
    {
        public UserRegisteredException()
            :base("Usuario ya registrado")
        {
        }
    }
}
