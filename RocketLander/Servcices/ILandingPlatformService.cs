namespace RocketLander.Servcices
{
    public interface ILandingPlatformService
    {
        /// <summary>
        /// Validates if the rocket can land on the landing platform
        /// </summary>
        /// <param name="landingPlatform">The  landing platform</param>
        /// <param name="landingCoordinateX">The landing coordinate X</param>
        /// <param name="landingCoordinateY">The landing coordinate Y</param>
        /// <returns>A landing status message</returns>
        string ValidateLandingInPlatform(LandingPlatform landingPlatform, int landingCoordinateX, int landingCoordinateY);
    }
}
