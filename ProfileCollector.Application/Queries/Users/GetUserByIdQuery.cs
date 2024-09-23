using MediatR;
using ProfileCollector.Application.QueryHandlers.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Queries.Users
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
    {
        public string Id { get; set; }
    }
}
