using MediatR;
using ProfileCollector.Application.CommandHandlers.Users.Dtos;
using ProfileCollector.Application.Commands.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public CreateUserAddressDto? Address { get; set; }
    }
}
