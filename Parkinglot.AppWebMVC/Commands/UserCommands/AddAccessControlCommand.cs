using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Parkinglot.AppWebMVC.Domain;
using Parkinglot.AppWebMVC.RabbitMq;
using Parkinglot.AppWebMVC.Repositories;

namespace Parkinglot.AppWebMVC.Commands.UserCommands
{
    public class AddAccessControlCommand : IRequest
    {
        public DateTime FullDate { get; set; }

        public string UserId { get; set; }
        public string Value { get; set; }

        public AccessType AccessType { get; set; }
    }

    public class AddAccessControlCommandHandler : IRequestHandler<AddAccessControlCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IRabbitMqPublish rabbitMqPublish;

        public AddAccessControlCommandHandler(IUserRepository userRepository, IRabbitMqPublish rabbitMqPublish)
        {
            this.userRepository = userRepository;
            this.rabbitMqPublish = rabbitMqPublish;
        }

        public Task<Unit> Handle(AddAccessControlCommand request, CancellationToken cancellationToken)
        {
            // 1.- Guardar en BD
            Domain.AccessType accessType = Enum.Parse<Domain.AccessType>(request.AccessType.ToString());
            var accessControl = new AccessControl(request.FullDate, request.UserId, accessType);
            userRepository.AddAccesControl(accessControl);

            // 2.- MITOTEAR a RabbitMq
            // var message = new MessageClean("OpenServo");
            var message = new MoveServo(3, 90);
            var result = rabbitMqPublish.Publish<MoveServo>(message, "DataFromAspNetCore");

            if(result==false)
                throw new Exception("No se ha notificado a Arduino");


            return Task.FromResult<Unit>(new Unit());
        }
    }
}
