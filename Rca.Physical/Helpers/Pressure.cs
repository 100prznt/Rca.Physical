// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Pressure
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied Bars.
		/// </summary>
		/// <param name="value">A number of Bars</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied Bars.</returns>
		public static PhysicalValue FromBar(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Bar, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied Millibars.
		/// </summary>
		/// <param name="value">A number of Millibars</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied Millibars.</returns>
		public static PhysicalValue FromMillibar(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Millibar, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied Pascals.
		/// </summary>
		/// <param name="value">A number of Pascals</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied Pascals.</returns>
		public static PhysicalValue FromPascal(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Pascal, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied Kilopascals.
		/// </summary>
		/// <param name="value">A number of Kilopascals</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied Kilopascals.</returns>
		public static PhysicalValue FromKilopascal(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Kilopascal, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied Megapascals.
		/// </summary>
		/// <param name="value">A number of Megapascals</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied Megapascals.</returns>
		public static PhysicalValue FromMegapascal(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Megapascal, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied Psis.
		/// </summary>
		/// <param name="value">A number of Psis</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied Psis.</returns>
		public static PhysicalValue FromPsi(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Psi, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Pressure of speciefied MetresOfWaterGauges.
		/// </summary>
		/// <param name="value">A number of MetresOfWaterGauges</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Pressure of speciefied MetresOfWaterGauges.</returns>
		public static PhysicalValue FromMetresOfWaterGauge(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.MetresOfWaterGauge, scaling);

	}
}
