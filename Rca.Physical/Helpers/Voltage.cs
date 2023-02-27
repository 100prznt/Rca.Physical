// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Voltage
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Voltage of speciefied Volts.
		/// </summary>
		/// <param name="value">A number of Volts</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Voltage of speciefied Volts.</returns>
		public static PhysicalValue FromVolt(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Volt, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Voltage of speciefied Millivolts.
		/// </summary>
		/// <param name="value">A number of Millivolts</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Voltage of speciefied Millivolts.</returns>
		public static PhysicalValue FromMillivolt(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Millivolt, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Voltage of speciefied Kilovolts.
		/// </summary>
		/// <param name="value">A number of Kilovolts</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Voltage of speciefied Kilovolts.</returns>
		public static PhysicalValue FromKilovolt(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Kilovolt, scaling);

	}
}
