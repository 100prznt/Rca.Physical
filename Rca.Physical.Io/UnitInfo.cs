using Rca.Physical.Dimensions;
using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Io
{
    public class UnitInfo
    {
        public static string CsvHeader => "\"Dimension\",\"Unit\",\"Symbol\",\"Alternative Notations\",\"IsSiUnit\",\"BaseFactor\",\"BaseOffset\"";
        
        public PhysicalUnits Unit { get; }

        public PhysicalDimensions Dimension { get; }

        public string Symbol { get; }
        public string[] AlternativeNotations { get; }

        public bool IsSiUnit { get; }

        public double BaseFactor { get; }

        public double BaseOffset { get; }

        public UnitInfo(PhysicalUnits unit)
        {
            Unit = unit;
            Dimension = unit.GetDimension();
            Symbol = unit.GetSymbol();
            IsSiUnit = unit == Dimension.GetBaseUnit();
            BaseFactor = unit.GetBaseFactor();
            BaseOffset = unit.GetBaseOffset();

            AlternativeNotations = unit.GetAlternativeSymbolNotations();
        }

        public string ToCsvLine()
        {
            var sb = new StringBuilder($"\"{Dimension}\",\"{Unit}\",\"{Symbol}\",\"");

            if (AlternativeNotations?.Length > 1)
            {
                foreach (var notationString in AlternativeNotations)
                    sb.Append($"{notationString}; ");
            }

            sb.Append($"\",\"{IsSiUnit}\",\"{BaseFactor}\",\"{BaseOffset}\"");

            return sb.ToString();
        }

        
    }
}
