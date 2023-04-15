using AluraChallenge.Adopet.Core.Exceptions;
using System;
using Xunit;

namespace AluraChallenge.Adopet.Domain.Tests.Entities
{
    public class TutorTests
    {
        [Fact]
        public void TutorCreateSuccess()
        {
            var userId = Guid.NewGuid();
            var tutor = Tutor.Create("Tutor 1", "teste@teste.com", userId, "(55)9999999");
            Assert.NotNull(tutor);
            Assert.Equal("Tutor 1", tutor.Name);
            Assert.Equal("teste@teste.com", tutor.Email.Address);
            Assert.Equal(userId, tutor.UserId);
            Assert.Equal("(55)9999999", tutor.Phone);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TutorCreateFailNameEmptyException(string? name)
        {
            Assert.Throws<EmptyNameException>(() => Tutor.Create(name, "teste@teste.com", Guid.NewGuid(), "(55)9999999"));
        }
        

        [Fact]
        public void TutorChangeNameSuccess()
        {
            var tutor = Tutor.Create("Tutor 1", "teste@teste.com", Guid.NewGuid(), "(55)9999999");
            tutor.ChangeName("novo nome");
            Assert.Equal("novo nome", tutor.Name);
        }

        [Fact]
        public void TutorChangeNameFailException()
        {
            var tutor = Tutor.Create("Tutor 1", "teste@teste.com", Guid.NewGuid(), "(55)9999999");
            Assert.Throws<EmptyNameException>(() => tutor.ChangeName(""));
        }

        [Fact]
        public void TutorChangePhoneSuccess()
        {

        }

        [Fact]
        public void TutorChangePhoneFailException()
        {

        }
    }
}
