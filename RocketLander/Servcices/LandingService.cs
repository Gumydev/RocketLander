using RocketLander.Models;
using RocketLander.Servcices;

namespace RocketLander
{
    public class LandingService : ILandingService
    {
        private readonly ILandingPlatformService _landingPlatformService;
        private readonly PlatformConfiguration _platformConfiguration;

        public LandingService(int platformLandingSideXlength, int platformLandingSideYlength)
        {
            _landingPlatformService = new LandingPlatformService();
            _platformConfiguration = new PlatformConfiguration
            {
                coordinateStartsX = 5,
                coordinateStartsY = 5,
                SideXlength = platformLandingSideXlength,
                SideYlenght = platformLandingSideYlength
            };
        }

        public virtual string RequestLanding(int coordinateX, int coordinateY)
        {
            if (!AreCoordinatesInsideLandingArea(coordinateX, coordinateY))
            {
                return LandingStatus.OutOfPlatform;
            }

            var landingArea = new LandingArea();

            if (!IsLandingPlatformInsideLandingAreaLimits(_platformConfiguration))
            {
                return LandingStatus.OutOfPlatform;
            }

            landingArea.landingPlatform = new LandingPlatform(_platformConfiguration);


            return _landingPlatformService.ValidateLandingInPlatform(landingArea.landingPlatform, coordinateX, coordinateY);
        }

        private bool AreCoordinatesInsideLandingArea(int coordinateX, int coordinateY)
        {
            if (coordinateX > 100 || coordinateX < 1 || coordinateY > 100 || coordinateY < 1)
            {
                return false;
            }

            return true;
        }

        private bool IsLandingPlatformInsideLandingAreaLimits(PlatformConfiguration platformConfiguration)
        {
            return platformConfiguration.coordinateStartsX + platformConfiguration.SideXlength <= 100 &&
                   platformConfiguration.coordinateStartsY + platformConfiguration.SideYlenght <= 100;
        }
    }
}
