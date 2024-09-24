using MediatR;
using ProfileCollector.Application.Common.Exceptions;
using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Application.Queries.Users;
using ProfileCollector.Application.QueryHandlers.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.QueryHandlers.Users
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException("Id", "Cannot find User with the specified Id");

            var response = new GetUserByIdResponse();

            response.User = new GetUserByIdQueryDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName
            };

            if (user.Address != null)
            {
                response.User.Address = new GetUserByIdQueryAddressDto
                {
                    City = user.Address.City,
                    State = user.Address.State,
                    Street = user.Address.Street,
                    Zip = user.Address.Zip,
                    Country = user.Address.Country
                };
            }

            return response;
        }
    }
}
