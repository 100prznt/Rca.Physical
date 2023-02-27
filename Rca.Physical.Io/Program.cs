﻿
using Rca.Physical.Io;

var controller = new Controller();
Console.WriteLine("ExportUnitsAsCsv");
controller.ExportUnitsAsCsv("..\\..\\..\\..\\SupportedUnits.csv");

Console.WriteLine("ExportDerivativeFunctions");
controller.ExportDerivativeFunctions("..\\..\\..\\..\\DerivativeFunctions.csv");

Console.WriteLine("GenerateHelperClasses");
controller.GenerateHelperClasses("..\\..\\..\\..\\Rca.Physical\\Helpers");

#if DEBUG
Console.WriteLine("ExportDerivativeFunctionArray");
controller.ExportDerivativeFunctionArray("..\\..\\..\\..\\Rca.Physical.Tests\\AutoGenerated.cs");
#endif

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
