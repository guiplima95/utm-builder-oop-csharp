using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using UtmBuilder.Core.Exceptions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects;

public class CampaignTests
{
    [Fact]
    public void Campaign_ShouldBeAbleExceptionWhenCampaignIsInvalid_ReturnException()
    {
        //Arrange
        string source = "";
        string medium = "";
        string name = "";

        //Act
        Action act = () =>
        {
            var campaign = new Campaign(name, source, medium);
        };

        //Assert
        act.Should().Throw<InvalidCampaignException>();
    }

    [Fact]
    public void Campaign_ShouldNotBeAbleExceptionWhenCampaignIsValid_ReturnUrl()
    {
        //Arrange
        string source = "Source";
        string medium = "Medium";
        string name = "Name";

        Campaign campaignExpected = new(name, source, medium);

        //Act
        var campaign = new Campaign(name, source, medium);

        //Assert
        campaign.Should().BeEquivalentTo(campaignExpected);
        campaign.Should().BeAssignableTo<Campaign>();
        campaign.Name.Should().Be(campaignExpected.Name);
        campaign.Source.Should().Be(campaignExpected.Source);
        campaign.Medium.Should().Be(campaignExpected.Medium);
    }
}
