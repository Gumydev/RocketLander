using FluentAssertions;
using RocketLander.Models;
using Xunit;

namespace RocketLander.Tests
{
    public class LandingPlatformTests
    {
        private readonly PlatformConfiguration _platformConfiguration;
        private readonly LandingPlatform _sut;

        public LandingPlatformTests()
        {
            _platformConfiguration = new PlatformConfiguration
            {
                coordinateStartsX = 5,
                coordinateStartsY = 5,
                SideXlength = 10,
                SideYlenght = 10
            };

            _sut = new LandingPlatform(_platformConfiguration);
        }

        [Fact]
        public void RequestLandingPLatformSpot_LandingSpotAlreadyTaken_ReturnsClashMessage()
        {
            // Arrange
            var coordinateX = 6;
            var coordinateY = 6;
            _sut.PlatformLandingArea[coordinateX - _sut.coordinateStartsX, coordinateY - _sut.coordinateStartsY] = 1;

            // Act
            var result = _sut.RequestLandingPLatformSpot(coordinateX, coordinateY);

            //Assert
            result.Should().BeEquivalentTo(LandingStatus.Clash);

        }

        [Fact]
        public void RequestLandingPLatformSpot_LandingSpotNotAlreadyTaken_ReturnsOkForLandingMessage()
        {
            // Arrange
            var coordinateX = 8;
            var coordinateY = 6;

            // Act
            var result = _sut.RequestLandingPLatformSpot(coordinateX, coordinateY);

            //Assert
            result.Should().BeEquivalentTo(LandingStatus.OkForLanding);
        }
    }
}
