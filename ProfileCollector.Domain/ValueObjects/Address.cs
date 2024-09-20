using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
        public string Country { get; }

        private Address(string street, string city, string state, string zip, string country)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }

        public static Result<Address> Create(string street, string city, string state, string zip, string country)
        {
            street = (street ?? string.Empty).Trim();
            city = (city ?? string.Empty).Trim();
            state = (state ?? string.Empty).Trim();
            zip = (zip ?? string.Empty).Trim();
            country = (country ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(street))
                return Result.Failure<Address>("Street should not be empty");

            if (string.IsNullOrWhiteSpace(city))
                return Result.Failure<Address>("City should not be empty");

            if (string.IsNullOrWhiteSpace(state))
                return Result.Failure<Address>("State should not be empty");

            if (string.IsNullOrWhiteSpace(zip))
                return Result.Failure<Address>("Zip should not be empty");

            if (string.IsNullOrWhiteSpace(country))
                country = "Canada";

            return Result.Success(new Address(street, city, state, zip, country));
        }

        protected override bool EqualsCore(Address other)
        {
            return Street == other.Street
                  && City == other.City
                  && Zip == other.Zip
                  && State == other.State
                  && Country == other.Country;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Street.GetHashCode();
                hashCode = (hashCode * 397) ^ Street.GetHashCode();
                hashCode = (hashCode * 397) ^ City.GetHashCode();
                hashCode = (hashCode * 397) ^ State.GetHashCode();
                hashCode = (hashCode * 397) ^ Zip.GetHashCode();
                hashCode = (hashCode * 397) ^ Country.GetHashCode();
                return hashCode;
            }
        }
    }
}
