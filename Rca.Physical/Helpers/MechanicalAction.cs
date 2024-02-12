// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class MechanicalAction
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a MechanicalAction of speciefied JouleSeconds.
		/// </summary>
		/// <param name="value">A number of JouleSeconds</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a MechanicalAction of speciefied JouleSeconds.</returns>
		public static PhysicalValue FromJouleSeconds(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.JouleSecond, scaling);

	}
}
