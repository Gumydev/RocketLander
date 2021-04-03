using RocketLander.Models;

namespace RocketLander
{
    /// <summary>
    /// This class defines a landing area
    /// </summary>
    public class LandingArea : LandingBase
    {
        public LandingPlatform landingPlatform;

        public LandingArea()
        {
            SideXlength = 100;
            SideYlength = 100;
        }
    }
}
