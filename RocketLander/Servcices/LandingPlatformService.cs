using RocketLander.Models;

namespace RocketLander.Servcices
{
    public class LandingPlatformService : ILandingPlatformService
    {
        public virtual string ValidateLandingInPlatform(LandingPlatform landingPlatform, int landingCoordinateX, int landingCoordinateY)
        {

            if (!AreCoordinatesInsideLandingPlatform(landingPlatform, landingCoordinateX, landingCoordinateY))
            {
                return LandingStatus.OutOfPlatform;
            }

            return landingPlatform.RequestLandingPLatformSpot(landingCoordinateX, landingCoordinateY);
        }


        private bool AreCoordinatesInsideLandingPlatform(LandingPlatform landingPlatform, int landingCoordinateX, int landingCoordinateY)
        {
            return landingCoordinateX <= landingPlatform.coordinateStartsX + landingPlatform.SideXlength ||
                   landingCoordinateY <= landingPlatform.coordinateStartsY + landingPlatform.SideYlength;
        }
    }
}
