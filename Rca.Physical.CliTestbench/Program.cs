// See https://aka.ms/new-console-template for more information
using Rca.Physical;
using Rca.Physical.Helpers;
using System.Runtime.CompilerServices;

Console.WriteLine("Rca.Physical.CliTestbench");

Console.WriteLine("Example 1");

//Use the helper classes, are provided for each physical dimension.
PhysicalValue myVoltageValue = Voltage.FromMillivolts(7410);
//Use the PhysicalValue constructor and select the unit from the common Units-Enum
PhysicalValue myCurrentValue = new(0.147, PhysicalUnits.Ampere);

//Use the overloaded ToString() method, to print out the value
Console.WriteLine(myVoltageValue);
//Fit the value to the best unit, and print in out with ToString(), also
//Console.WriteLine(myCurrentValue.GetFittedPhysicalValue());

// The example displays the following output to the console:
//  7410 mV
//  147 mA


Console.WriteLine("Example 2");

//Set sample values for voltage and current
PhysicalValue supplyVoltage = Voltage.FromVolts(3.3);
PhysicalValue supplyCurrent = ElectricCurrent.FromMilliamperes(125);

//Use the operater extension to calculate the electrical power
PhysicalValue supplyPower = supplyVoltage * supplyCurrent;

//Use the overloaded ToString() method, to print out the value
Console.WriteLine(supplyPower);
//Or use the best fit methode
Console.WriteLine(supplyPower.GetFittedPhysicalValue());

// The example displays the following output to the console:
//  0.4125 W