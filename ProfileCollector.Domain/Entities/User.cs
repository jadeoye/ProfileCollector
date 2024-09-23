using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using ProfileCollector.Domain.Interfaces;
using ProfileCollector.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Domain.Entities
{
    public class User : Entity<string>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? MiddleName { get; private set; }
        public virtual Address? Address { get; private set; }

        private User()
        {
            Id = Guid.NewGuid().ToString();
        }

        private User(string firstName, string lastName, string? middleName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public static User Create(string firstName, string lastName, string? middleName)
        {
            firstName = (firstName ?? string.Empty).Trim();
            lastName = (lastName ?? string.Empty).Trim();

            Guard.Against.Null(firstName, nameof(firstName));
            Guard.Against.Null(lastName, nameof(lastName));

            return new User(firstName, lastName, middleName);
        }

        public void UpdateAddress(Address address)
        {
            Guard.Against.Null(address, nameof(address)); ;

            Address = address;
        }
    }
}
