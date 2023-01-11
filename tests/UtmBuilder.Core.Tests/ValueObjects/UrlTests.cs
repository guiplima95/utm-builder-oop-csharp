using FluentAssertions;
using UtmBuilder.Core.Exceptions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class UrlTests
{
    [Fact]
    public void Url_ShouldBeAbleExceptionWhenUrlIsInvalid_ReturnException()
    {
        //Arrange
        string invalidAddress = "";

        //Act
        Action act = () =>
        {
            var url = new Url(invalidAddress);
        };

        //Assert
        act.Should().Throw<InvalidUrlException>();
    }

    [Fact]
    public void UrlShouldNotBeAbleExceptionWhenUrlIsValid_ReturnUrl()
    {
        //Arrange
        string validAddress = "https://google.com";
        Url urlExpected = new(validAddress);

        //Act
        var url = new Url(validAddress);

        //Assert
        url.Should().BeEquivalentTo(urlExpected);
        url.Should().BeAssignableTo<Url>();
        url.Address.Should().Be(urlExpected.Address);
    }
}
