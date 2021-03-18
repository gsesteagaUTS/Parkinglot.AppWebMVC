using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Parkinglot.AppWebMVC.Domain;
using Parkinglot.AppWebMVC.Repositories;

namespace Parkinglot.AppWebMVC.Commands.UserCommands
{
    public class AddAccessControlCommand : IRequest
    {
        public DateTime FullDate { get; set; }

        public string UserId { get; set; }

        public AccessType AccessType { get; set; }
    }

    public class AddAccessControlCommandHandler : IRequestHandler<AddAccessControlCommand>
    {
        private readonly IUserRepository userRepository;

        public AddAccessControlCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddAccessControlCommand request, CancellationToken cancellationToken)
        {
            var accessControl = new AccessControl();//DateTime.Now, "3216565", Domain.AccessType );
            userRepository.AddAccesControl(accessControl);
            return new Unit();
        }
    }
}
