using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.QueryHandlers.Users.Dtos
{
    public class GetUserByIdQueryDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        private string NormalizedMiddleName => string.IsNullOrWhiteSpace(MiddleName) ? " " : $" {MiddleName} ";
        public string FullName => $"{FirstName}{NormalizedMiddleName}{LastName}";

        public GetUserByIdQueryAddressDto Address { get; set; }
    }
}
