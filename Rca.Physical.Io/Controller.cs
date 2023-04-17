using Rca.Physical.Dimensions;
using Rca.Physical.Dimensions.Arithmetric;
using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Io
{
    public class Controller
    {
        Calculator m_Calculator;

        public List<PhysicalDimensions> Dimensions { get; set; }

        public List<PhysicalUnits> Units { get; set; }

        internal List<FunctionDescription> Functions { get; set; }

        public Controller()
        {
            Dimensions = new List<PhysicalDimensions>((PhysicalDimensions[])Enum.GetValues(typeof(PhysicalDimensions)));
            Units = new List<PhysicalUnits>((PhysicalUnits[])Enum.GetValues(typeof(PhysicalUnits)));

            Functions = new List<FunctionDescription>();
            //Use all functions from calculator buffer
            m_Calculator = new Calculator(); //Init buffer

            foreach (var func in Calculator.DimensionsFunctionsBuffer)
                Functions.AddRange(func.Value);

            Functions = Functions.OrderBy(x => x.DimensionResult.ToString()).ToList();

        }

        public string GetRcaPhysicalInfo()
        {
            var assemblyName = typeof(PhysicalValue).Assembly.GetName();

            return assemblyName.FullName;
        }

        public int ExportUnitsAsCsv(string path)
        {
            int cnt = 0;
            using var sw = new StreamWriter(path);
            sw.WriteLine(UnitInfo.CsvHeader);
            foreach (var unit in Units)
            {
                sw.WriteLine(new UnitInfo(unit).ToCsvLine());
                cnt++;
            }

            return cnt;
        }

        public int ExportDerivativeFunctions(string path)
        {
            int cnt = 0;
            using var sw = new StreamWriter(path);
            sw.WriteLine(DerivativeFunctionInfo.CsvHeader);
            foreach (var function in Functions)
            {
                sw.WriteLine(new DerivativeFunctionInfo(function).ToCsvLine());
                cnt++;
            }

            return cnt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        public int GenerateHelperClasses(string directory)
        {
            var cnt = 0;

            if (Directory.Exists(directory))
            {
                foreach (var dim in Dimensions)
                {
                    if (dim == PhysicalDimensions.None || dim == PhysicalDimensions.NotDefined)
                        continue;
                    
                    using var sw = new StreamWriter($"{directory}\\{dim}.cs");
                    sw.WriteLine("// THIS FILE IS AUTO GENERATED!");
                    sw.WriteLine("// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT");
                    sw.WriteLine();
                    sw.WriteLine("namespace Rca.Physical.Helpers");
                    sw.WriteLine("{");
                    sw.WriteLine("\t/// <summary>");
                    sw.WriteLine("\t/// Helper to generate <seealso cref=\"PhysicalValue\"/> from numeric values of associated units.");
                    sw.WriteLine("\t/// </summary>");
                    sw.WriteLine($"\tpublic abstract partial class {dim}");
                    sw.WriteLine("\t{");
                    foreach (var unit in dim.GetUnits())
                    {
                        var units = unit.ToString();
                        if (!unit.ToString().EndsWith('s'))
                            units = $"{unit}s";

                        sw.WriteLine($"\t\t/// <summary>");
                        sw.WriteLine($"\t\t/// Returns a <seealso cref=\"PhysicalValue\"/> that represents a {dim} of speciefied {units}.");
                        sw.WriteLine($"\t\t/// </summary>");
                        sw.WriteLine($"\t\t/// <param name=\"value\">A number of {units}</param>");
                        sw.WriteLine($"\t\t/// <param name=\"scaling\">Scaling for the returned <seealso cref=\"PhysicalValue\"/></param>");
                        sw.WriteLine($"\t\t/// <returns>A <seealso cref=\"PhysicalValue\"/> which represents a {dim} of speciefied {units}.</returns>");
                        sw.WriteLine($"\t\tpublic static PhysicalValue From{units}(double value, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined) => new(value, PhysicalUnits.{unit}, scaling);");
                        sw.WriteLine();
                    }
                    sw.WriteLine("\t}");
                    sw.WriteLine("}");
                    cnt++;
                }
            }

            return cnt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        public int GeneratePhysicalUnitExtensions(string directory)
        {
            var cnt = 0;

            if (Directory.Exists(directory))
            {
                using var sw = new StreamWriter($"{directory}\\PysicalUnitExtensions.cs");
                sw.WriteLine("// THIS FILE IS AUTO GENERATED!");
                sw.WriteLine("// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT");
                sw.WriteLine();
                sw.WriteLine("namespace Rca.Physical");
                sw.WriteLine("{");
                sw.WriteLine("\t/// <summary>");
                sw.WriteLine("\t/// Extensions for <seealso cref=\"PhysicalValue\"/> to check specific dimension.");
                sw.WriteLine("\t/// </summary>");
                sw.WriteLine($"\tpublic static class PysicalUnitExtensions");
                sw.WriteLine("\t{");
                foreach (var dim in Dimensions)
                {
                    if (dim == PhysicalDimensions.None || dim == PhysicalDimensions.NotDefined)
                        continue;

                    sw.WriteLine($"\t\t/// <summary>");
                    sw.WriteLine($"\t\t/// The dimension of the PhysicalValue is <seealso cref=\"PhysicalDimensions.{dim}\"/>");
                    sw.WriteLine($"\t\t/// </summary>");
                    sw.WriteLine($"\t\tpublic static bool Is{dim}(this PhysicalValue value) => value.Dimension == PhysicalDimensions.{dim};");
                    sw.WriteLine();
                    cnt++;
                }
                sw.WriteLine("\t}");
                sw.WriteLine("}");
            }

            return cnt;
        }

#if DEBUG
        public int ExportDerivativeFunctionArray(string path)
        {
            var cnt = 0;

            if (Directory.Exists(path[..path.LastIndexOf('\\')]))
            {
                using var sw = new StreamWriter(path);
                sw.WriteLine("using Rca.Physical.Dimensions.Arithmetric;");
                sw.WriteLine();
                sw.WriteLine("namespace Rca.Physical.Tests");
                sw.WriteLine("{");
                sw.WriteLine("\t/// <summary>");
                sw.WriteLine("\t/// THIS CLASS IS AUTO GENERATED!");
                sw.WriteLine("\t/// ALL CHANGES ARE OVERWRITTEN BY EXECUTION OF THE Rca.Physics.Io PROJECT");
                sw.WriteLine("\t/// </summary>");
                sw.WriteLine("\tpublic class AutoGenerated");
                sw.WriteLine("\t{");
                sw.WriteLine("\t\tinternal static FunctionDescription[] DerivativeFunctions = new FunctionDescription[]");
                sw.WriteLine("\t\t{");
                foreach (var function in Functions)
                {
                    sw.WriteLine("\t\t\t" + function.ToCSharp() + ",");
                    cnt++;
                }
                sw.WriteLine("\t\t};");
                sw.WriteLine("\t}");
                sw.WriteLine("}");
            }

            return cnt;
        }
#endif
    }
}
