namespace RocketLander.Servcices
{
    public interface ILandingService
    {
        /// <summary>
        /// Requests if the rocket is able to landing on the landing area
        /// </summary>
        /// <param name="coordinateX">The coordinate X</param>
        /// <param name="coordinateY">The coordinate Y</param>
        /// <returns>A landing status message</returns>
        string RequestLanding(int coordinateX, int coordeniteY);
    }
}
