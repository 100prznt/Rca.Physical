// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Mass
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Mass of speciefied Kilograms.
		/// </summary>
		/// <param name="value">A number of Kilograms</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Mass of speciefied Kilograms.</returns>
		public static PhysicalValue FromKilograms(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Kilogram, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Mass of speciefied Tonnes.
		/// </summary>
		/// <param name="value">A number of Tonnes</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Mass of speciefied Tonnes.</returns>
		public static PhysicalValue FromTonnes(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Tonne, scaling);

	}
}
