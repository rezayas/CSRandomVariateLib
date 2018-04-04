using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public class Constant : RVG
    {
        private double _value;

        // instantiation
        public Constant(string name, double value)
            : base(name)
        {
            _value = value;
        }

        public override double SampleContinuous(RNG rnd)
        {
            return _value;
        }
    }
}
