// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class HeatFluxDestiny
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a HeatFluxDestiny of speciefied WattPerSquareMetres.
		/// </summary>
		/// <param name="value">A number of WattPerSquareMetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a HeatFluxDestiny of speciefied WattPerSquareMetres.</returns>
		public static PhysicalValue FromWattPerSquareMetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.WattPerSquareMetre, scaling);

	}
}
