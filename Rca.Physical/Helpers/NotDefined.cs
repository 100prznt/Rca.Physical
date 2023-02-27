// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class NotDefined
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a NotDefined of speciefied NotDefineds.
		/// </summary>
		/// <param name="value">A number of NotDefineds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a NotDefined of speciefied NotDefineds.</returns>
		public static PhysicalValue FromNotDefined(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.NotDefined, scaling);

	}
}
