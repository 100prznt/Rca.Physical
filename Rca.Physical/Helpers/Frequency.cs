// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Frequency
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Frequency of speciefied Hertzs.
		/// </summary>
		/// <param name="value">A number of Hertzs</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Frequency of speciefied Hertzs.</returns>
		public static PhysicalValue FromHertz(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Hertz, scaling);

	}
}
