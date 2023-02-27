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
		/// <param name="value">A timespan</param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Time of speciefied timespan.</returns>
		public static PhysicalValue FromTimeSpan(TimeSpan value) => new(value.TotalMilliseconds, PhysicalUnits.Millisecond);

	}
}
