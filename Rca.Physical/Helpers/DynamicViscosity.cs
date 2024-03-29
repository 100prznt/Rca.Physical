// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class DynamicViscosity
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a DynamicViscosity of speciefied PascalSeconds.
		/// </summary>
		/// <param name="value">A number of PascalSeconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a DynamicViscosity of speciefied PascalSeconds.</returns>
		public static PhysicalValue FromPascalSeconds(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.PascalSecond, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a DynamicViscosity of speciefied KilogramPerMetreSeconds.
		/// </summary>
		/// <param name="value">A number of KilogramPerMetreSeconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a DynamicViscosity of speciefied KilogramPerMetreSeconds.</returns>
		public static PhysicalValue FromKilogramPerMetreSeconds(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.KilogramPerMetreSecond, scaling);

	}
}
