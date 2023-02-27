using Rca.Physical.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Calculators
{
    /// <summary>
    /// SEUIF97 library wrappe
    /// </summary>
    internal class SeuIf97Wrapper
    {
        /// <summary>
        /// (p,t)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seupt(double pressure, double temperature, PropertyIds pid);

        /// <summary>
        /// (p,h)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seuph(double pressure, double specEnthalpy, PropertyIds pid);

        /// <summary>
        /// (p,s)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seups(double pressure, double specEntropy, PropertyIds pid);

        /// <summary>
        /// (p,v)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seupv(double pressure, double specVolume, PropertyIds pid);

        /// <summary>
        /// (t,h)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seuth(double temperature, double specEnthalpy, PropertyIds pid);

        /// <summary>
        /// (t,s)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seuts(double temperature, double specEntropy, PropertyIds pid);

        /// <summary>
        /// (t,v)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seutv(double temperature, double specVolume, PropertyIds pid);

        /// <summary>
        /// (h,s)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seuhs(double enthalpy, double specEntropy, PropertyIds pid);

        /// <summary>
        /// (p,x)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seupx(double pressure, double steamQuality, PropertyIds pid);

        /// <summary>
        /// (t,x)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seutx(double temperature, double steamQuality, PropertyIds pid);

        /// <summary>
        /// Isentropic Enthalpy Drop
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seuishd(double pressureInlet, double temperatureInlet, double pressureOutlet);

        /// <summary>
        /// Isentropic Efficiency (0..100)
        /// </summary>
        [DllImport(@"Dependencies\SEUIF97\x64\libseuif97.dll", CallingConvention = CallingConvention.StdCall)]
        internal static extern double seuief(double pressureInlet, double temperatureInlet, double pressureOutlet, double temperatureOutlet);

    }

    /// <summary>
    /// Property IDs for the SEUIF97 library
    /// </summary>
    internal enum PropertyIds
    {
        /// <summary>
        /// Pressure p in [MPa]
        /// </summary>
        Pressure = 0,
        /// <summary>
        /// Temperature t in [°C]
        /// </summary>
        Temperature	= 1,
        /// <summary>
        /// Destiny d in [kg/m^3]
        /// </summary>
        Density =	2,
        /// <summary>
        /// Specific volume v in [m^3/kg]
        /// </summary>
        Volume   =	3,
        /// <summary>
        /// Specific enthalpy h in [kJ/kg]
        /// </summary>
        Enthalpy = 4,
        /// <summary>
        /// Specific entropy s in [kJ/(kg·K)]
        /// </summary>
        Entropy    =	5,
        /// <summary>
        /// Specific exergy e in [kJ/kg]	
        /// </summary>
        Exergy =	6,
        /// <summary>
        /// Specific internal energy u in [kJ/kg] 
        /// </summary>
        InternalEnergy =   7,
        /// <summary>
        /// Specific isobaric heat capacity cp in [kJ/(kg·K)]
        /// </summary>
        IsobaricHeatCapacity =	8,
        /// <summary>
        /// Specific isochoric heat capacity cv in [kJ/(kg·K)]
        /// </summary>
        IsochoricHeatCapacity	=	9,
        /// <summary>
        /// Speed of sound w in [m/s] 
        /// </summary>
        SpeedOfSound = 10,
        /// <summary>
        /// Isentropic exponent ks
        /// </summary>
        IsentropicExponent =	11,
        /// <summary>
        /// Specific Helmholtz free energy f in [kJ/kg] 
        /// </summary>
        HelmholtzFreeEnergy  =  12,
        /// <summary>
        /// Specific Gibbs free energy g in [kJ/kg]  
        /// </summary>
        GibbsFreeEnergy = 13,
        /// <summary>
        /// CompressibilityFactor z
        /// </summary>
        CompressibilityFactor  =	14,
        /// <summary>
        /// SteamQuality x
        /// </summary>
        SteamQuality = 15,
        /// <summary>
        /// Region r 
        /// </summary>
        Region = 16,
        /// <summary>
        /// Isobaric volume expansion coefficient  ec in [1/K] 
        /// </summary>
        IsobaricVolumeExpansionCoefficient  =  17,
        /// <summary>
        /// Isothermal compressibility kt in [1/MPa] 
        /// </summary>
        IsothermalCompressibility  =  18,
        /// <summary>
        /// Partial derivative(dV/dT)p dvdt in [m3/(kg·K)]	
        /// </summary>
        PartialDerivative_dV_dT_p =	19,
        /// <summary>
        /// Partial derivative(dV/dP)T dvdp in [m3/(kg·MPa)]
        /// </summary>
        PartialDerivative_dV_dP_T = 20,
        /// <summary>
        /// Partial derivative(dP/dT)v dpdt in [MPa/K]  
        /// </summary>
        PartialDerivative_dP_dT_v =  21,
        /// <summary>
        /// Isothermal Joule-Thomson coefficient  iJTC in [kJ/(kg·MPa)]
        /// </summary>
        IsothermalJouleThomsonCoefficient =	22,
        /// <summary>
        /// Joule-Thomson coefficient JTC in [K/MPa]
        /// </summary>
        JouleThomsonCoefficient = 23,
        /// <summary>
        /// Dynamic viscosity dv in [kg/(m·s)]
        /// </summary>
        DynamicViscosity  =	24,
        /// <summary>
        /// Kinematic viscosity kv in [m^2/s]
        /// </summary>
        KinematicViscosity = 25,
        /// <summary>
        /// Thermal conductivity tc in [W/(m·K)]
        /// </summary>
        ThermalConductivity = 26,
        /// <summary>
        /// Thermal diffusivity td in [um^2/s] 
        /// </summary>
        ThermalDiffusivity = 27,
        /// <summary>
        /// Prandtl number pr
        /// </summary>
        PrandtlNumber = 28,
        /// <summary>
        /// Surface tension st in [mN/m]
        /// </summary>
        SurfaceTension = 29,
    }
}