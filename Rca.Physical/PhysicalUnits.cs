using Rca.Physical.Units;

namespace Rca.Physical
{
    public enum PhysicalUnits
    {
        [Dimension(PhysicalDimensions.NotDefined)]
        [DisableAutoFit]
        NotDefined = -1,
        /// <summary>
        /// Indicates a unitless value.
        /// </summary>
        [Dimension(PhysicalDimensions.None)]
        [DisableAutoFit]
        [Symbol("")]
        None = 0,
        [Dimension(PhysicalDimensions.Pressure)]
        [Scaling(100000)] //Wie viel Einheiten der Basiseinheit entsprechen einer Einheit dieser Einheit.
        [Symbol("bar")]
        [ScaleSpecificSymbol(ScaleOfMeasurements.Absolute, "bar(a)")]
        [ScaleSpecificSymbol(ScaleOfMeasurements.Relative, "bar(g)")]
        Bar,
        [Dimension(PhysicalDimensions.Pressure)]
        [Scaling(100)]
        [Symbol("mbar")]
        Millibar,
        [Dimension(PhysicalDimensions.Pressure)]
        [Symbol("Pa")]
        Pascal,
        [Dimension(PhysicalDimensions.Pressure)]
        [Scaling(1000)]
        [Symbol("kPa")]
        Kilopascal,
        [Dimension(PhysicalDimensions.Pressure)]
        [Scaling(1000000)]
        [Symbol("MPa")]
        Megapascal,
        [Dimension(PhysicalDimensions.Pressure)]
        [LongName("Pound per square inch")]
        [Scaling(6894.757293168)]
        [Symbol("psi")]
        Psi,
        [Dimension(PhysicalDimensions.ThermodynamicTemperature)]
        [Scaling(1, 273.15)]
        [Symbol("°C")]
        Celsius,
        [Dimension(PhysicalDimensions.ThermodynamicTemperature)]
        [Symbol("K")]
        Kelvin,
        [Dimension(PhysicalDimensions.Voltage)]
        [Symbol("V")]
        Volt,
        [Dimension(PhysicalDimensions.Voltage)]
        [Scaling(0.001)]
        [Symbol("mV")]
        Millivolt,
        [Dimension(PhysicalDimensions.Voltage)]
        [Scaling(1000)]
        [Symbol("kV")]
        Kilovolt,
        [Dimension(PhysicalDimensions.Time)]
        [Symbol("s")]
        [AlternativeSymbolNotations("sec")]
        Second,
        [Dimension(PhysicalDimensions.Time)]
        [Scaling(0.001)]
        [Symbol("ms")]
        [AlternativeSymbolNotations("msec")]
        Millisecond,
        [Dimension(PhysicalDimensions.Time)]
        [Scaling(60)]
        [Symbol("min")]
        Minute,
        [Dimension(PhysicalDimensions.Time)]
        [Scaling(3600)]
        [Symbol("h")]
        Hour,
        [Dimension(PhysicalDimensions.Time)]
        [Scaling(86400)]
        [Symbol("d")]
        Day,
        [Dimension(PhysicalDimensions.Time)]
        [Scaling(31536000)]
        [Symbol("a")]
        Year,
        [Dimension(PhysicalDimensions.ElectricCurrent)]
        [Symbol("A")]
        Ampere,
        [Dimension(PhysicalDimensions.ElectricCurrent)]
        [Scaling(0.001)]
        [Symbol("mA")]
        Milliampere,
        [Dimension(PhysicalDimensions.Power)]
        [Symbol("W")]
        Watt,
        [Dimension(PhysicalDimensions.Power)]
        [Scaling(1000)]
        [Symbol("kW")]
        Kilowatt,
        [Dimension(PhysicalDimensions.Power)]
        [Scaling(745.69987158227022)]
        [Symbol("hp")]
        [DisableAutoFit]
        Horsepower,
        [Dimension(PhysicalDimensions.Power)]
        [Scaling(735.49875)]
        [Symbol("PS")]
        [DisableAutoFit]
        Pferdestaerken,
        [Dimension(PhysicalDimensions.Length)]
        [Symbol("m")]
        Metre, //Spelling reference: https://www.bipm.org/en/measurement-units/si-base-units
        [Dimension(PhysicalDimensions.Length)]
        [Scaling(0.001)]
        [Symbol("mm")]
        Millimetre,
        [Dimension(PhysicalDimensions.Length)]
        [Scaling(1000)]
        [Symbol("km")]
        Kilometre,
        [Dimension(PhysicalDimensions.Length)]
        [Scaling(0.01)]
        [Symbol("cm")]
        [DisableAutoFit]
        Centimetre,
        [Dimension(PhysicalDimensions.Pressure)]
        [Scaling(9806.65)]
        [AlternativeSymbolNotations("m WS", "mH2O")]
        [Symbol("mWS")]
        [DisableAutoFit]
        MetresOfWaterGauge,
        [Dimension(PhysicalDimensions.Area)]
        [AlternativeSymbolNotations("m²")]
        [Symbol("m^2")]
        SquareMetre,
        [Dimension(PhysicalDimensions.Volume)]
        [Symbol("m^3")]
        [AlternativeSymbolNotations("cbm", "m³")]
        CubicMetre,
        [Dimension(PhysicalDimensions.Volume)]
        [Scaling(0.000001)]
        [Symbol("cm^3")]
        [AlternativeSymbolNotations("ccm", "cm³")]
        CubicCentimetre,
        [Dimension(PhysicalDimensions.Volume)]
        [Scaling(0.001)]
        [Symbol("l")]
        Litre,
        [Dimension(PhysicalDimensions.Volume)]
        [Scaling(0.000001)]
        [Symbol("ml")]
        Millilitre,
        [Dimension(PhysicalDimensions.Speed)]
        [Symbol("m/s")]
        MetrePerSecond,
        [Dimension(PhysicalDimensions.Speed)]
        [Scaling(0.447040357632)]
        [Symbol("m/h")]
        MetrePerHour,
        [Dimension(PhysicalDimensions.Speed)]
        [Scaling(0.277777777778)]
        [Symbol("km/h")]
        KilometrePerHour,
        [Dimension(PhysicalDimensions.Mass)]
        [Symbol("kg")]
        Kilogram,
        [Dimension(PhysicalDimensions.Mass)]
        [Scaling(1000)]
        [Symbol("t")]
        Tonne,
        [Dimension(PhysicalDimensions.Energy)]
        [Symbol("J")]
        Joule,
        [Dimension(PhysicalDimensions.Energy)]
        [Symbol("Nm")]
        NewtonMetre,
        [Dimension(PhysicalDimensions.Force)]
        [Symbol("N")]
        Newton,
        [Dimension(PhysicalDimensions.Acceleration)]
        [AlternativeSymbolNotations("m/s²")]
        [Symbol("m/s^2")]
        MetrePerSecondSquared,
        [Dimension(PhysicalDimensions.VolumetricFlowRate)]
        [AlternativeSymbolNotations("m³/s")]
        [Symbol("m^3/s")]
        CubicMetrePerSecond,
        [Dimension(PhysicalDimensions.VolumetricFlowRate)]
        [Scaling(0.001)]
        [Symbol("l/s")]
        LitrePerSecond,
        [Dimension(PhysicalDimensions.VolumetricFlowRate)]
        [Scaling(0.06)]
        [Symbol("l/min")]
        LitrePerMinute,
        [Dimension(PhysicalDimensions.VolumetricFlowRate)]
        [Scaling(0.000277777777778)]
        [AlternativeSymbolNotations("m³/h")]
        [Symbol("m^3/h")]
        CubicMetrePerHour,
        [Dimension(PhysicalDimensions.Costs)]
        [Symbol("EUR")]
        [AlternativeSymbolNotations("Euro")]
        Euro,
        [Dimension(PhysicalDimensions.Costs)]
        [Symbol("USD")]
        UnitedStatesDollar,
        [Dimension(PhysicalDimensions.Costs)]
        [Symbol("CHF")]
        SwissFrancs,
        [Dimension(PhysicalDimensions.Ratio)]
        [Scaling(100)]
        [Symbol("%")]
        Percent,
        [Dimension(PhysicalDimensions.Ratio)]
        [Scaling(1000000)]
        [Symbol("PPM")]
        PartsPerMillion,
        [Dimension(PhysicalDimensions.AmountOfSubstance)]
        [Symbol("mol")]
        Mole,
        [Dimension(PhysicalDimensions.LuminousIntensity)]
        [Symbol("cd")]
        Candela,
        [Dimension(PhysicalDimensions.Action)]
        [AlternativeSymbolNotations("J⋅s")]
        [Symbol("J s")]
        JouleSecond,
        [Dimension(PhysicalDimensions.Frequency)]
        [AlternativeSymbolNotations("s^-1")]
        [Symbol("Hz")]
        Hertz,
        [Dimension(PhysicalDimensions.Entropy)]
        [Symbol("J/K")]
        JoulePerKelvin,
        [Dimension(PhysicalDimensions.ElectricCharge)]
        [Symbol("C")]
        Coulomb,
        [Dimension(PhysicalDimensions.Destiny)]
        [AlternativeSymbolNotations("kg/m³")]
        [Symbol("kg/m^3")]
        KilogramPerCubicMetre,
        [Dimension(PhysicalDimensions.HeatFluxDestiny)]
        [AlternativeSymbolNotations("W/m²")]
        [Symbol("W/m^2")]
        WattPerSquareMetre,

        [Dimension(PhysicalDimensions.KineticViscosity)]
        [AlternativeSymbolNotations("m²/s")]
        [Symbol("m^2/s")]
        SquareMetrePerSecond,

        [Dimension(PhysicalDimensions.DynamicViscosity)]
        [AlternativeSymbolNotations("Pa⋅s")]
        [Symbol("Pa s")]
        PascalSecond,
        [Dimension(PhysicalDimensions.DynamicViscosity)]
        [Scaling(1)]
        [AlternativeSymbolNotations("kg/m⋅s")]
        [Symbol("kg/m s")]
        [DisableAutoFit]
        KilogramPerMeterSecond


        #region SI derived units with special names and symbols

        #endregion

        #region Coherent derived units in terms of base units

        #endregion

        #region derived units that include units with special names

        #endregion

        #region Non-SI units accepted for use with SI
        //https://en.wikipedia.org/wiki/Non-SI_units_mentioned_in_the_SI

        #endregion
    }
}
