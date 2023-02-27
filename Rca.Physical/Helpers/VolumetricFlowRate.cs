// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract class VolumetricFlowRate
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a VolumetricFlowRate of speciefied CubicMetrePerSeconds.
		/// </summary>
		/// <param name="value">A number of CubicMetrePerSeconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a VolumetricFlowRate of speciefied CubicMetrePerSeconds.</returns>
		public static PhysicalValue FromCubicMetrePerSecond(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.CubicMetrePerSecond, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a VolumetricFlowRate of speciefied LitrePerSeconds.
		/// </summary>
		/// <param name="value">A number of LitrePerSeconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a VolumetricFlowRate of speciefied LitrePerSeconds.</returns>
		public static PhysicalValue FromLitrePerSecond(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.LitrePerSecond, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a VolumetricFlowRate of speciefied LitrePerMinutes.
		/// </summary>
		/// <param name="value">A number of LitrePerMinutes</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a VolumetricFlowRate of speciefied LitrePerMinutes.</returns>
		public static PhysicalValue FromLitrePerMinute(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.LitrePerMinute, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a VolumetricFlowRate of speciefied CubicMetrePerHours.
		/// </summary>
		/// <param name="value">A number of CubicMetrePerHours</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a VolumetricFlowRate of speciefied CubicMetrePerHours.</returns>
		public static PhysicalValue FromCubicMetrePerHour(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.CubicMetrePerHour, scaling);

	}
}
