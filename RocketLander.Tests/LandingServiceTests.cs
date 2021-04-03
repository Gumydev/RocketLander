using Xunit;
using FluentAssertions;
using Moq;
using RocketLander.Servcices;
using RocketLander.Models;

namespace RocketLander.Tests
{
    public class LandingServiceTests
    {
        private LandingService _sut;
        private readonly Mock<ILandingService> _mockLandingService;
        private readonly Mock<ILandingPlatformService> _mockLandingPlatformService;
        private const int PLATFORM_LANDING_SIDE_X_Length = 10;
        private const int PLATFORM_LANDING_SIDE_Y_Length = 10;

        public LandingServiceTests()
        {
            _mockLandingService = new Mock<ILandingService>();
            _mockLandingPlatformService = new Mock<ILandingPlatformService>();
        }

        [Theory]
        [InlineData(108, 4)]
        [InlineData(45, 122)]
        [InlineData(0, 80)]
        [InlineData(33, 0)]
        public void RequestLanding_OutOfAreaLimitscoordinates_ReturnsOutOfPlatformMessage(int landingCoordinateX, int landingCoordinateY)
        {
            // Arrange
            _sut = new LandingService(PLATFORM_LANDING_SIDE_X_Length, PLATFORM_LANDING_SIDE_Y_Length);

            // Action
            var result = _sut.RequestLanding(landingCoordinateX, landingCoordinateY);

            // Assertion
            result.Should().BeEquivalentTo(LandingStatus.OutOfPlatform);
        }

        [Fact]
        public void RequestLanding_OutOfPlatformLimitscoordinates_ReturnsOutOfPlatformMessage()
        {
            // Arrange
            _sut = new LandingService(110, 80);
            var landingcoordinateX = 16;
            var landingcoordinateY = 15;

            // Action
            var result = _sut.RequestLanding(landingcoordinateX, landingcoordinateY);

            // Assertion
            result.Should().BeEquivalentTo(LandingStatus.OutOfPlatform);
        }

        [Fact]
        public void RequestLanding_InsidePlatformLimitscoordinates_ReturnsOkForLandingMessage()
        {
            // Arrange
            _sut = new LandingService(PLATFORM_LANDING_SIDE_X_Length, PLATFORM_LANDING_SIDE_Y_Length);
            var landingCoordinateX = 12;
            var landingCoordinateY = 7;
            var platformConfiguration = new PlatformConfiguration();
            var landingPLatform = new LandingPlatform(platformConfiguration);

            _mockLandingService.Setup(s => s.RequestLanding(landingCoordinateX, landingCoordinateY))
                .Returns(LandingStatus.OkForLanding);

            _mockLandingPlatformService.Setup(s => s.ValidateLandingInPlatform(landingPLatform, landingCoordinateX, landingCoordinateY))
                .Returns(LandingStatus.OkForLanding);

            // Action
            var result = _sut.RequestLanding(landingCoordinateX, landingCoordinateY);

            // Assertion
            result.Should().BeEquivalentTo(LandingStatus.OkForLanding);
        }
    }
}
