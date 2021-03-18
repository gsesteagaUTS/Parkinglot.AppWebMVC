using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Parkinglot.AppWebMVC.Commands.CommandExceptions;
using Parkinglot.AppWebMVC.Domain;
using Parkinglot.AppWebMVC.Repositories;

namespace Parkinglot.AppWebMVC.Commands.UserCommands
{
    public class CreateNewUserCommand : IRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int ControlNumber { get; set; }

    }

    public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand>
    {

        private readonly IUserRepository userRepository;

        public CreateNewUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<Unit> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
        {
            //Validations
            //Validar el Id
            var userInBD = userRepository.FindUser(request.ControlNumber);//1374
            if(userInBD != null)
                throw new UserRegisteredException();

            var user = new User(request.Id, request.FullName, request.ControlNumber);
            userRepository.AddUser(user);
            return Task.FromResult<Unit>(new Unit());
        }
    }
}
