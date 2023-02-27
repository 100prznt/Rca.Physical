// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class ElectricCharge
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a ElectricCharge of speciefied Coulombs.
		/// </summary>
		/// <param name="value">A number of Coulombs</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a ElectricCharge of speciefied Coulombs.</returns>
		public static PhysicalValue FromCoulomb(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Coulomb, scaling);

	}
}
