// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Length
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Length of speciefied Metres.
		/// </summary>
		/// <param name="value">A number of Metres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Length of speciefied Metres.</returns>
		public static PhysicalValue FromMetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Metre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Length of speciefied Millimetres.
		/// </summary>
		/// <param name="value">A number of Millimetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Length of speciefied Millimetres.</returns>
		public static PhysicalValue FromMillimetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Millimetre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Length of speciefied Kilometres.
		/// </summary>
		/// <param name="value">A number of Kilometres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Length of speciefied Kilometres.</returns>
		public static PhysicalValue FromKilometre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Kilometre, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Length of speciefied Centimetres.
		/// </summary>
		/// <param name="value">A number of Centimetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Length of speciefied Centimetres.</returns>
		public static PhysicalValue FromCentimetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Centimetre, scaling);

	}
}
