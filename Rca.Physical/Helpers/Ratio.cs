// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class Ratio
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Ratio of speciefied Percents.
		/// </summary>
		/// <param name="value">A number of Percents</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Ratio of speciefied Percents.</returns>
		public static PhysicalValue FromPercent(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Percent, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Ratio of speciefied PartsPerMillions.
		/// </summary>
		/// <param name="value">A number of PartsPerMillions</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Ratio of speciefied PartsPerMillions.</returns>
		public static PhysicalValue FromPartsPerMillion(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.PartsPerMillion, scaling);

	}
}
