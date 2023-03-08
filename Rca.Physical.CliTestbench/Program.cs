// See https://aka.ms/new-console-template for more information
using Rca.Physical;
using Rca.Physical.Helpers;
using System.Runtime.CompilerServices;

Console.WriteLine("Rca.Physical.CliTestbench");


//Use the helper classes, are provided for each physical dimension.
PhysicalValue myVoltageValue = Voltage.FromMillivolts(7410);
//Use the PhysicalValue constructor and select the unit from the common Units-Enum
PhysicalValue myCurrentValue = new(0.147, PhysicalUnits.Ampere);

//Use the overloaded ToString() method, to print out the value
Console.WriteLine(myVoltageValue);
//Fit the value to the best unit, and print in out with ToString(), also
Console.WriteLine(myCurrentValue.GetFittedPhysicalValue());

// The example displays the following output to the console:
//  7410 mV
//  147 mA