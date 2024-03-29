// THIS FILE IS AUTO GENERATED!
// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT

namespace Rca.Physical.Helpers
{
	/// <summary>
	/// Helper to generate <seealso cref="PhysicalValue"/> from numeric values of associated units.
	/// </summary>
	public abstract partial class Power
	{
		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Power of speciefied Watts.
		/// </summary>
		/// <param name="value">A number of Watts</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Power of speciefied Watts.</returns>
		public static PhysicalValue FromWatts(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Watt, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Power of speciefied Milliwatts.
		/// </summary>
		/// <param name="value">A number of Milliwatts</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Power of speciefied Milliwatts.</returns>
		public static PhysicalValue FromMilliwatts(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Milliwatt, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Power of speciefied Kilowatts.
		/// </summary>
		/// <param name="value">A number of Kilowatts</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Power of speciefied Kilowatts.</returns>
		public static PhysicalValue FromKilowatts(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Kilowatt, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Power of speciefied Horsepowers.
		/// </summary>
		/// <param name="value">A number of Horsepowers</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Power of speciefied Horsepowers.</returns>
		public static PhysicalValue FromHorsepowers(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Horsepower, scaling);

		/// <summary>
		/// Returns a <seealso cref="PhysicalValue"/> that represents a Power of speciefied Pferdestaerkens.
		/// </summary>
		/// <param name="value">A number of Pferdestaerkens</param>
		/// <param name="scaling">Scaling for the returned <seealso cref="PhysicalValue"/></param>
		/// <returns>A <seealso cref="PhysicalValue"/> which represents a Power of speciefied Pferdestaerkens.</returns>
		public static PhysicalValue FromPferdestaerkens(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.Pferdestaerken, scaling);

	}
}
