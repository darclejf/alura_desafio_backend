using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Enums;
using Xunit;

namespace AluraChallenge.Adopet.Domain.Tests.Entities
{
    public class TutorTests
    {
        [Fact]
        public void TutorCreateSuccess()
        {
            var tutor = Tutor.Create("Tutor 1", "teste@teste.com", "@123456", "@123456", "(55)9999999");
            Assert.NotNull(tutor);
            Assert.Equal("Tutor 1", tutor.Name);
            Assert.Equal("teste@teste.com", tutor.Email.Address);
            Assert.Equal("teste@teste.com", tutor.User.UserName);
            Assert.Equal("(55)9999999", tutor.Phone);
            Assert.Equal(ProfileRole.Tutor, tutor.User.Role);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TutorCreateFailNameEmptyException(string? name)
        {
            Assert.Throws<EmptyNameException>(() => Tutor.Create(name, "teste@teste.com", "@123456", "@123456", "(55)9999999"));
        }
        

        [Fact]
        public void TutorChangeNameSuccess()
        {

        }

        [Fact]
        public void TutorChangeNameFailException()
        {

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
