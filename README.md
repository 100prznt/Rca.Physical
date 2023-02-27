[![Bulid](https://img.shields.io/appveyor/ci/100prznt/rca-physical.svg?logo=appveyor&style=popout-square)](https://ci.appveyor.com/project/100prznt/rca-physical)   [![Current version](https://img.shields.io/nuget/v/Rca.Physical.svg?logo=nuget&logoColor=%23ef8b00&style=popout-square)](https://www.nuget.org/packages/Rca.Physical/)   [![Code size](https://img.shields.io/github/languages/code-size/100prznt/Rca.Physical.svg?logo=github&style=popout-square)](#) 

# Rca.Physical

Library to handle physical values, dimensions and units.


## Core Features

* Basic calculation with phsyical values 


## Usage

```csharp
//Use the helper classes, are provided for each physical dimension.
PhysicalValue myVoltageValue = Voltage.FromMillivolt(7410);

//Use the PhysicalValue constructor and select the unit from the common Units-Enum
PhysicalValue myCurrentValue = new(0.147, PhysicalUnits.Ampere);


//Use the overloaded ToString() method, to print out the value
Console.WriteLine(myVoltageValue);

//Fit the value to the best unit, and print in out with ToString(), also
Console.WriteLine(myCurrentValue.GetFittedPhysicalValue());


// The example displays the following output to the console:
//  7410 mV
//  147 mA
```
