// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class SpecificEnergy
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a SpecificEnergy of speciefied JoulePerKilograms.
		/// </summary>
		/// <param name="value">A number of JoulePerKilograms</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a SpecificEnergy of speciefied JoulePerKilograms.</returns>
		public static PhysicalValue FromJoulePerKilograms(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.JoulePerKilogram, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a SpecificEnergy of speciefied KilojoulePerKilograms.
		/// </summary>
		/// <param name="value">A number of KilojoulePerKilograms</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a SpecificEnergy of speciefied KilojoulePerKilograms.</returns>
		public static PhysicalValue FromKilojoulePerKilograms(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.KilojoulePerKilogram, scaling);

	}
}
