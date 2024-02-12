// See https://aka.ms/new-console-template for more information
using Rca.Physical;
using Rca.Physical.Helpers;
using System.Runtime.CompilerServices;
using Action = System.Action;

const int CONSOLE_WIDTH = 50;

Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName);

Block("Example 1", () => {
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
});

Block("Example 2", () => {
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
    //  412.5 mW
});



void Block(string name, Action testCode)
{
    var space = CONSOLE_WIDTH - name.Trim().Length - 2;
    var halfSpace = space / 2;
    Console.Write(new string('#', halfSpace) + " " + name + " ");
    if (halfSpace * 2 == space - 1)
        halfSpace++;
    Console.WriteLine(new string('#', halfSpace));

    testCode();

    Console.WriteLine(new string('#', CONSOLE_WIDTH));
    Console.WriteLine();
}