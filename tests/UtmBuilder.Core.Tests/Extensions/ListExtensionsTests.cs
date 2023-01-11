using FluentAssertions;
using System.Xml.Linq;
using UtmBuilder.Core.Exceptions;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.Extensions;
public class ListExtensionsTests
{
    [Fact]
    public void AddIfNotNull_ShouldBeAbleAddList_Successufly()
    {
        //Assert
        string key = "Key";
        string value = "Value";
        List<string> expectedList = new()
        {
            $"{key}={value}"
        };

        List<string> list = new();

        //Act
        list.AddIfNotNull(key, value);

        //Arrange
        list.Should().BeEquivalentTo(expectedList);
    }

    [Fact]
    public void AddIfNotNull_ShouldNotAbleAddList_ReturnEmptyList()
    {
        //Assert
        List<string> expectedList = new();

        List<string> list = new();

        //Act
        list.AddIfNotNull(string.Empty, null);

        //Arrange
        list.Should().BeEquivalentTo(expectedList);
    }
}
