namespace Rca.Physical
{
    public static class Constants
    {
        #region SI defining constants
        //https://en.wikipedia.org/wiki/International_System_of_Units

        /// <summary>
        /// Speed of light
        /// </summary>
        public static readonly PhysicalValue c = new(299792458, PhysicalUnits.MetrePerSecond, ScaleOfMeasurements.Absolute);

        /// <summary>
        /// Planck constant
        /// </summary>
        public static readonly PhysicalValue h = new(6.62607015E-34, PhysicalUnits.JouleSecond, ScaleOfMeasurements.Absolute);

        /// <summary>
        /// Boltzmann constant
        /// </summary>
        public static readonly PhysicalValue k = new(1.380649E-23, PhysicalUnits.JoulePerKelvin, ScaleOfMeasurements.Absolute);

        /// <summary>
        /// Elementary charge
        /// </summary>
        public static readonly PhysicalValue e = new(1.602176634E-19, PhysicalUnits.Coulomb, ScaleOfMeasurements.Absolute);

        #endregion

        #region Other constants

        /// <summary>
        /// Gravity of Earth
        /// </summary>
        public static readonly PhysicalValue g = new(9.80665, PhysicalUnits.MetrePerSecondSquared, ScaleOfMeasurements.Absolute);

        #endregion
    }
}
