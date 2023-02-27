// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class Speed
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Speed of speciefied MetrePerSeconds.
		/// </summary>
		/// <param name="value">A number of MetrePerSeconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Speed of speciefied MetrePerSeconds.</returns>
		public static PhysicalValue FromMetrePerSecond(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.MetrePerSecond, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Speed of speciefied MetrePerHours.
		/// </summary>
		/// <param name="value">A number of MetrePerHours</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Speed of speciefied MetrePerHours.</returns>
		public static PhysicalValue FromMetrePerHour(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.MetrePerHour, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Speed of speciefied KilometrePerHours.
		/// </summary>
		/// <param name="value">A number of KilometrePerHours</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Speed of speciefied KilometrePerHours.</returns>
		public static PhysicalValue FromKilometrePerHour(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.KilometrePerHour, scaling);

	}
}
