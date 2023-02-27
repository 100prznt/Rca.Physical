// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Volume
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Volume of speciefied CubicMetres.
		/// </summary>
		/// <param name="value">A number of CubicMetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Volume of speciefied CubicMetres.</returns>
		public static PhysicalValue FromCubicMetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.CubicMetre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Volume of speciefied CubicCentimetres.
		/// </summary>
		/// <param name="value">A number of CubicCentimetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Volume of speciefied CubicCentimetres.</returns>
		public static PhysicalValue FromCubicCentimetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.CubicCentimetre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Volume of speciefied Litres.
		/// </summary>
		/// <param name="value">A number of Litres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Volume of speciefied Litres.</returns>
		public static PhysicalValue FromLitre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Litre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Volume of speciefied Millilitres.
		/// </summary>
		/// <param name="value">A number of Millilitres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Volume of speciefied Millilitres.</returns>
		public static PhysicalValue FromMillilitre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Millilitre, scaling);

	}
}
