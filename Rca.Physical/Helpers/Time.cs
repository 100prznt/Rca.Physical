// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Time
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Time of speciefied Seconds.
		/// </summary>
		/// <param name="value">A number of Seconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied Seconds.</returns>
		public static PhysicalValue FromSeconds(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Second, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Time of speciefied Milliseconds.
		/// </summary>
		/// <param name="value">A number of Milliseconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied Milliseconds.</returns>
		public static PhysicalValue FromMilliseconds(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Millisecond, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Time of speciefied Minutes.
		/// </summary>
		/// <param name="value">A number of Minutes</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied Minutes.</returns>
		public static PhysicalValue FromMinutes(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Minute, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Time of speciefied Hours.
		/// </summary>
		/// <param name="value">A number of Hours</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied Hours.</returns>
		public static PhysicalValue FromHours(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Hour, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Time of speciefied Days.
		/// </summary>
		/// <param name="value">A number of Days</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied Days.</returns>
		public static PhysicalValue FromDays(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Day, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Time of speciefied Years.
		/// </summary>
		/// <param name="value">A number of Years</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied Years.</returns>
		public static PhysicalValue FromYears(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Year, scaling);

	}
}
