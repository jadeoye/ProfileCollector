using MediatR;
using ProfileCollector.Application.CommandHandlers.Users.Dtos;
using ProfileCollector.Application.Commands.Users;
using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Domain.Entities;
using ProfileCollector.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.CommandHandlers.Users
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.FirstName, request.LastName, request.MiddleName);

            if (request.Address != null)
            {
                var addressResult = Address.Create(request.Address.Street, request.Address.City,
                    request.Address.State, request.Address.Zip, request.Address.Country);

                if (addressResult.IsFailure)
                    throw new Exception(addressResult.Error);

                user.UpdateAddress(addressResult.Value);
            }

            await _userRepository.AddAsync(user, saveChanges: true, cancellationToken);

            return new CreateUserResponse { UserId = Guid.Parse(user.Id) };
        }
    }
}
