// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Area
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Area of speciefied SquareMetres.
		/// </summary>
		/// <param name="value">A number of SquareMetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Area of speciefied SquareMetres.</returns>
		public static PhysicalValue FromSquareMetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.SquareMetre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Area of speciefied SquareCentimetres.
		/// </summary>
		/// <param name="value">A number of SquareCentimetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Area of speciefied SquareCentimetres.</returns>
		public static PhysicalValue FromSquareCentimetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.SquareCentimetre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Area of speciefied SquareMillimetres.
		/// </summary>
		/// <param name="value">A number of SquareMillimetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Area of speciefied SquareMillimetres.</returns>
		public static PhysicalValue FromSquareMillimetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.SquareMillimetre, scaling);

	}
}
