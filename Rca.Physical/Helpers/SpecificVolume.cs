// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class SpecificVolume
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a SpecificVolume of speciefied CubicMetrePerKilograms.
		/// </summary>
		/// <param name="value">A number of CubicMetrePerKilograms</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a SpecificVolume of speciefied CubicmetrePerKilograms.</returns>
		public static PhysicalValue FromCubicMetrePerKilogram(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.CubicMetrePerKilogram, scaling);

	}
}
