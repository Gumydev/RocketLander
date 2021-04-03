using Xunit;
using FluentAssertions;
using RocketLander.Servcices;
using RocketLander.Models;

namespace RocketLander.Tests
{
    public class LandingPlatformServiceTests
    {
        private readonly ILandingPlatformService _sut;

        public LandingPlatformServiceTests()
        {
            _sut = new LandingPlatformService();
        }

        [Theory]
        [InlineData(6, 20)]
        [InlineData(20, 6)]
        public void ValidateLandingInPlatform_coordinatesOutOfLandingPlatform_ReturnsOutOfPlatformMessage(int landingCoordinateX, int landingCoordinateY)
        {
            // Arrange
            var platformConfiguration = new PlatformConfiguration();
            var landingPLatform = new LandingPlatform(platformConfiguration);

            // Act
            var result = _sut.ValidateLandingInPlatform(landingPLatform, landingCoordinateX, landingCoordinateY);

            // Assert
            result.Should().BeEquivalentTo(LandingStatus.OutOfPlatform);
        }

        [Fact]
        public void ValidateLandingInPlatform_coordinatesInsideLandingPlatform_ReturnsOkForLanding()
        {
            // Arrange
            var landingCoordinateX = 12;
            var landingCoordinateY = 7;
            var platformConfiguration = new PlatformConfiguration
            {
                coordinateStartsX = 5,
                coordinateStartsY = 5,
                SideXlength = 10,
                SideYlenght = 10
            };
            var landingPLatform = new LandingPlatform(platformConfiguration);

            // Act
            var result = _sut.ValidateLandingInPlatform(landingPLatform, landingCoordinateX, landingCoordinateY);

            // Assert
            result.Should().BeEquivalentTo(LandingStatus.OkForLanding);
        }
    }
}
