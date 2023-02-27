// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class ElectricCurrent
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a ElectricCurrent of speciefied Amperes.
		/// </summary>
		/// <param name="value">A number of Amperes</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a ElectricCurrent of speciefied Amperes.</returns>
		public static PhysicalValue FromAmpere(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Ampere, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a ElectricCurrent of speciefied Milliamperes.
		/// </summary>
		/// <param name="value">A number of Milliamperes</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a ElectricCurrent of speciefied Milliamperes.</returns>
		public static PhysicalValue FromMilliampere(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Milliampere, scaling);

	}
}
