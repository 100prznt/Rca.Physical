using Rca.Physical.Dimensions;
using Rca.Physical.Dimensions.Arithmetric;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    /// <summary>
    /// Physical dimensions
    /// the SI base unit is entered as an attribute
    /// </summary>
    public enum PhysicalDimensions
    {
        [BaseUnit(PhysicalUnits.NotDefined)]
        NotDefined = -1,
        [BaseUnit(PhysicalUnits.None)]
        [Symbol("")]
        None = 0,


        #region Seven SI base units

        /// <summary>
        /// Time
        /// </summary>
        [BaseUnit(PhysicalUnits.Second)]
        [Symbol("t")]
        Time,
        /// <summary>
        /// Length
        /// </summary>
        [BaseUnit(PhysicalUnits.Metre)]
        [Symbol("l")]
        Length,
        /// <summary>
        /// Mass
        /// also knowen as Weigth
        /// </summary>
        [BaseUnit(PhysicalUnits.Kilogram)]
        [Symbol("m")]
        Mass,
        /// <summary>
        /// Electrical Current
        /// </summary>
        [BaseUnit(PhysicalUnits.Ampere)]
        [Symbol("I")]
        ElectricCurrent,
        /// <summary>
        /// Thermodynamic Temperature
        /// </summary>
        [BaseUnit(PhysicalUnits.Kelvin)]
        [Symbol("T")] //for temperature in K
        ThermodynamicTemperature,
        /// <summary>
        /// Amount of substance
        /// </summary>
        [BaseUnit(PhysicalUnits.Mole)]
        [Symbol("n")]
        AmountOfSubstance,
        /// <summary>
        /// Luminous intensity
        /// </summary>
        [BaseUnit(PhysicalUnits.Candela)]
        [Symbol("I_V")]
        LuminousIntensity,

        #endregion

        #region Derived units

        /// <summary>
        /// Pressure
        /// </summary>
        [BaseUnit(PhysicalUnits.Pascal)]
        [Symbol("p")]
        Pressure,
        /// <summary>
        /// Electrical Voltage
        /// </summary>
        [BaseUnit(PhysicalUnits.Volt)]
        [Symbol("U")]
        Voltage,
        /// <summary>
        /// Power
        /// </summary>
        [BaseUnit(PhysicalUnits.Watt)]
        [Symbol("P")]
        [ProductOf(Voltage, ElectricCurrent)]
        [QuotientOf(Energy, Time)]
        Power,
        /// <summary>
        /// Area
        /// </summary>
        [BaseUnit(PhysicalUnits.SquareMetre)]
        [Symbol("A")]
        [ProductOf(Length, Length)]
        Area,
        /// <summary>
        /// Volume
        /// </summary>
        [BaseUnit(PhysicalUnits.CubicMetre)]
        [Symbol("V")]
        [ProductOf(Area, Length)]
        Volume,
        /// <summary>
        /// Speed
        /// </summary>
        [BaseUnit(PhysicalUnits.MetrePerSecond)]
        [Symbol("v")]
        [QuotientOf(Length, Time)]
        Speed,
        /// <summary>
        /// Energy
        /// Energy != Torque https://de.wikipedia.org/wiki/Drehmoment#:~:text=Die%20Einheit%20der%20mechanischen%20Arbeit,sich%20nicht%20ineinander%20umrechnen%20lassen
        /// </summary>
        [BaseUnit(PhysicalUnits.Joule)]
        [Symbol("E")]
        [Symbol("W")]
        [ProductOf(Force, Length)]
        [ProductOf(Power, Time)]
        Energy,
        /// <summary>
        /// Force
        /// </summary>
        [BaseUnit(PhysicalUnits.Newton)]
        [Symbol("F")]
        [ProductOf(Mass, Acceleration)]
        Force,
        [BaseUnit(PhysicalUnits.MetrePerSecondSquared)]
        [Symbol("a")]
        Acceleration,
        /// <summary>
        /// Volumetric flow rate (also known as volume flow rate, rate of fluid flow, or volume velocity)
        /// </summary>
        [BaseUnit(PhysicalUnits.CubicMetrePerSecond)]
        [Symbol("Q")]
        [ProductOf(Speed, Area)]
        VolumetricFlowRate,
        [BaseUnit(PhysicalUnits.JouleSecond)]
        [Symbol("S")]
        [ProductOf(Energy, Time)]
        MechanicalAction,
        [BaseUnit(PhysicalUnits.Hertz)]
        [Symbol("f")]
        Frequency,
        [BaseUnit(PhysicalUnits.JoulePerKelvin)]
        [Symbol("S")]
        [QuotientOf(Energy, ThermodynamicTemperature)]
        Entropy,
        [BaseUnit(PhysicalUnits.Coulomb)]
        [Symbol("q")]
        [ProductOf(ElectricCurrent, Time)]
        ElectricCharge,
        [BaseUnit(PhysicalUnits.KilogramPerCubicMetre)]
        [AlternativeSymbolNotations("[rho]")]
        [Symbol("D")]
        [QuotientOf(Mass, Volume)]
        Density,
        [BaseUnit(PhysicalUnits.WattPerSquareMetre)]
        [Symbol("q")]
        [QuotientOf(Energy, Area)]
        HeatFluxDestiny,
        [BaseUnit(PhysicalUnits.PascalSecond)]
        [Symbol("[eta]")]
        [ProductOf(KineticViscosity, Density)]
        DynamicViscosity,
        [BaseUnit(PhysicalUnits.SquareMetrePerSecond)]
        [Symbol("[ny]")]
        [QuotientOf(DynamicViscosity, Density)]
        KineticViscosity,
        [BaseUnit(PhysicalUnits.CubicMetrePerKilogram)]
        [Symbol("[nu]")]
        [QuotientOf(Volume, Mass)]
        SpecificVolume,
        [BaseUnit(PhysicalUnits.JoulePerKilogram)]
        [Symbol("e")]
        [QuotientOf(Energy, Mass)]
        SpecificEnergy,
        [BaseUnit(PhysicalUnits.KilogramPerSquareSecond)]
        [Symbol("[sigma]")]
        [QuotientOf(Force, Length)]
        [QuotientOf(Energy, Area)]
        SurfaceTension,

        #endregion

        #region Special "units" not SI confirm

        /// <summary>
        /// Costs in currency units
        /// Due to the fact that currency is linked to the current exchange rate, costs cannot be converted directly.
        /// </summary>
        Costs,
        /// <summary>
        /// Costs per time
        /// </summary>
        [ProductOf(Costs, Time)]
        CostsPerTime,
        /// <summary>
        /// Ratio, dimensionless quantities
        /// https://en.wikipedia.org/wiki/Ratio
        /// </summary>
        Ratio

        #endregion
    }
}
