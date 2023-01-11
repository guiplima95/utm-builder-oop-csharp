using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

public class UtmTests
{
    [Fact]
    public void Utm_ShouldBeAbleReturnUrlFromUtm_Successfuly()
    {
        //Arrange
        var url = new Url("https://google.com/");
        var campaign = new Campaign(
          "nme",
          "src",
          "med");

        var expectedResult = "https://google.com/" +
                             "?utm_source=src" +
                             "&utm_medium=med" +
                             "&utm_campaign=nme";

        //Act
        var utm = new Utm(url, campaign);

        //Assert
        var utmString = utm.ToString();
        utmString.Should().Be(expectedResult);
        utm.Campaign.Should().Be(campaign);
        utm.Url.Should().Be(url);
    }

    [Fact]
    public void Utm_ShouldBeAbleReturnUtmFromUrl_Successfuly()
    {
        //Arrange
        var expectedUrl = new Url("https://google.com/");
        var expectedCampaign = new Campaign("src", "med", "nme", "id", "ter", "ctn");

        var result = "https://google.com/" +
                                  "?utm_source=src" +
                                  "&utm_medium=med" +
                                  "&utm_campaign=nme" +
                                  "&utm_id=id" +
                                  "&utm_term=ter" +
                                  "&utm_content=ctn";

        //Act
        Utm utm = result;

        //Assert
        utm.Url.Address.Should().Be(expectedUrl.Address);
        utm.Campaign.Source.Should().Be(expectedCampaign.Source);
        utm.Campaign.Name.Should().Be(expectedCampaign.Name);
        utm.Campaign.Medium.Should().Be(expectedCampaign.Medium);
    }
}
