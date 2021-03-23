using System;
namespace Parkinglot.AppWebMVC.Commands.CommandExceptions
{
    public class NotAddedAccessControl : Exception
    {
        public NotAddedAccessControl()
            : base("No se actualizó en base de datos")
        {

        }
        public NotAddedAccessControl(string message)
            : base(message)
        {

        }
    }
}