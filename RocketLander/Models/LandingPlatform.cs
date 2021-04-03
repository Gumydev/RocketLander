using RocketLander.Models;

namespace RocketLander
{
    /// <summary>
    /// This class defines a landing platform
    /// </summary>
    public class LandingPlatform : LandingBase
    {
        public int coordinateStartsX;
        public int coordinateStartsY;
        public int[,] PlatformLandingArea;

        public LandingPlatform(PlatformConfiguration platformConfiguration)
        {
            SideXlength = platformConfiguration.SideXlength;
            SideYlength = platformConfiguration.SideYlenght;
            coordinateStartsX = platformConfiguration.coordinateStartsX;
            coordinateStartsY = platformConfiguration.coordinateStartsY;
            PlatformLandingArea = new int[SideXlength, SideYlength];
        }

        /// <summary>
        /// This method is used to request landing to a platform on a specific coordinates
        /// </summary>
        /// <param name="landingCoordinateX">The landing coordinate X</param>
        /// <param name="landingCoordinateY">The landing coordinate Y</param>
        /// <returns>A landing status message</returns>
        public string RequestLandingPLatformSpot(int landingCoordinateX, int landingCoordinateY)
        {
            var xbis = landingCoordinateX - coordinateStartsX;
            var ybis = landingCoordinateY - coordinateStartsY;

            if (IsLandingSpotTaken(xbis, ybis))
            {
                return LandingStatus.Clash;
            }

            return AssignLandingPLatformSpotsArea(xbis, ybis);
        }

        private string AssignLandingPLatformSpotsArea(int xbis, int ybis)
        {

            PlatformLandingArea[xbis, ybis] = 1;
            PlatformLandingArea[xbis - 1, ybis] = 1;
            PlatformLandingArea[xbis + 1, ybis] = 1;

            PlatformLandingArea[xbis - 1, ybis - 1] = 1;
            PlatformLandingArea[xbis, ybis - 1] = 1;
            PlatformLandingArea[xbis + 1, ybis - 1] = 1;

            PlatformLandingArea[xbis - 1, ybis + 1] = 1;
            PlatformLandingArea[xbis, ybis + 1] = 1;
            PlatformLandingArea[xbis + 1, ybis + 1] = 1;

            return LandingStatus.OkForLanding;
        }

        private bool IsLandingSpotTaken(int landingCoordinateX, int landingCoordinateY)
        {
            return PlatformLandingArea[landingCoordinateX, landingCoordinateY] == 1;
        }
    }
}
