// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class None
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a None of speciefied Nones.
		/// </summary>
		/// <param name="value">A number of Nones</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a None of speciefied Nones.</returns>
		public static PhysicalValue FromNone(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.None, scaling);

	}
}
