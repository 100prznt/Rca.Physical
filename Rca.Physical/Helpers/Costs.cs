// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Costs
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Costs of speciefied Euros.
		/// </summary>
		/// <param name="value">A number of Euros</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Costs of speciefied Euros.</returns>
		public static PhysicalValue FromEuros(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Euro, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Costs of speciefied UnitedStatesDollars.
		/// </summary>
		/// <param name="value">A number of UnitedStatesDollars</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Costs of speciefied UnitedStatesDollars.</returns>
		public static PhysicalValue FromUnitedStatesDollars(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.UnitedStatesDollar, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Costs of speciefied SwissFrancs.
		/// </summary>
		/// <param name="value">A number of SwissFrancs</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Costs of speciefied SwissFrancs.</returns>
		public static PhysicalValue FromSwissFrancs(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.SwissFrancs, scaling);

	}
}
