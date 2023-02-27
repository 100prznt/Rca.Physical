// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class ThermodynamicTemperature
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a ThermodynamicTemperature of speciefied Celsiuss.
		/// </summary>
		/// <param name="value">A number of Celsiuss</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a ThermodynamicTemperature of speciefied Celsiuss.</returns>
		public static PhysicalValue FromCelsius(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Celsius, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a ThermodynamicTemperature of speciefied Kelvins.
		/// </summary>
		/// <param name="value">A number of Kelvins</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a ThermodynamicTemperature of speciefied Kelvins.</returns>
		public static PhysicalValue FromKelvin(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Kelvin, scaling);

	}
}
