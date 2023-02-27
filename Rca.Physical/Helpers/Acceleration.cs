// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class Acceleration
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Acceleration of speciefied MetrePerSecondSquareds.
		/// </summary>
		/// <param name="value">A number of MetrePerSecondSquareds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Acceleration of speciefied MetrePerSecondSquareds.</returns>
		public static PhysicalValue FromMetrePerSecondSquared(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.MetrePerSecondSquared, scaling);

	}
}
