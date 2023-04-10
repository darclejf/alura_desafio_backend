using AluraChallenge.Adopet.Core.Exceptions;
using System;
using Xunit;

namespace AluraChallenge.Adopet.Domain.Tests.Entities
{
    public class CityTests
    {
        [Fact]
        public void CityCreateSuccess()
        {
            var city = City.Create("Caxias Do Sul", "RS");
            Assert.NotNull(city);
            Assert.Equal("Caxias Do Sul", city.Name);
            Assert.Equal("RS", city.UF);
        }

        [Fact]
        public void CityCreateWithIdSuccess()
        {
            var id = Guid.NewGuid();
            var city = City.Create("Caxias Do Sul", "RS");
            Assert.NotNull(city);
            Assert.Equal(id, city.Id);
            Assert.Equal("Caxias Do Sul", city.Name);
            Assert.Equal("RS", city.UF);
        }

        [Fact]
        public void CityTryCreateWithEmptyNameFail()
        {
            Assert.Throws<EmptyNameException>(() => City.Create("", "RS"));
        }

        [Fact]
        public void CityTryCreateWithEmptyUFFail()
        {
            Assert.Throws<EmptyUFException>(() => City.Create("asdadadsa", ""));
        }
    }
}
