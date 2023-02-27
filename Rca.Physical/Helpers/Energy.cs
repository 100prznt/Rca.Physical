// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Energy
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Energy of speciefied Joules.
		/// </summary>
		/// <param name="value">A number of Joules</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Energy of speciefied Joules.</returns>
		public static PhysicalValue FromJoule(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Joule, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Energy of speciefied NewtonMetres.
		/// </summary>
		/// <param name="value">A number of NewtonMetres</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Energy of speciefied NewtonMetres.</returns>
		public static PhysicalValue FromNewtonMetre(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.NewtonMetre, scaling);

	}
}
