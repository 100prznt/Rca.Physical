using Rca.Physical.Exceptions;
using Rca.Physical.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical
{
    [DebuggerDisplay("{DefaultFormattedValue, nq}")]
    public class PhysicalRange
    {
        double m_LowerBaseValue;
        double m_UpperBaseValue;
        PhysicalValue m_LowerValue;
        PhysicalValue m_UpperValue;


        #region Fields
        private string DefaultFormattedValue => $"{m_LowerValue.ValueAs(m_UpperValue.Unit):N2} .. {m_UpperValue:N2)}";

        #endregion Fields

        public PhysicalValue LowerValue
        {
            get => m_LowerValue;
            set
            {
                if (!(m_UpperValue is null) && m_UpperValue.Dimension != value.Dimension)
                    throw new PhysicalDimensionMismatchException(m_UpperValue.Dimension, value.Dimension);
                m_LowerValue = value;
                m_LowerBaseValue = value.GetBaseValue();
            }
        }

        public PhysicalValue UpperValue
        {
            get => m_UpperValue;
            set
            {
                if (!(m_LowerValue is null) && m_LowerValue.Dimension != value.Dimension)
                    throw new PhysicalDimensionMismatchException(m_LowerValue.Dimension, value.Dimension);
                m_UpperValue = value;
                m_UpperBaseValue = value.GetBaseValue();
            }
        }


        public PhysicalRange()
        {
            LowerValue = PhysicalValue.NaN;
            UpperValue = PhysicalValue.NaN;
        }

        public PhysicalRange(PhysicalValue lowerValue, PhysicalValue upperValue)
        {
            if (lowerValue.Dimension != upperValue.Dimension)
                throw new PhysicalDimensionMismatchException(lowerValue.Dimension, upperValue.Dimension);

            LowerValue = lowerValue;
            UpperValue = upperValue;
        }

        public PhysicalRange(double lowerValue, double upperValue, PhysicalUnits unit)
        {
            LowerValue = new(lowerValue, unit);
            UpperValue = new(upperValue, unit);
        }

        public bool InRange(PhysicalValue value)
        {
            if (LowerValue.Dimension != value.Dimension)
                throw new PhysicalDimensionMismatchException(LowerValue.Dimension, value.Dimension);

            var baseValue = value.GetBaseValue();

            return baseValue >= m_LowerBaseValue && baseValue <= m_UpperBaseValue;
        }
    }
}
