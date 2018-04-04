using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public class DiscreteUniform : RVG
    {
        private int _min, _max;

        // instantiation
        public DiscreteUniform(string name, int inclusiveMin, int inclusiveMax)
            : base(name)
        {
            if (inclusiveMin > inclusiveMax)
            {
                Console.Write("Minimum cannot be greater than maximum for a uniform distribution.");
                return;
            }
            _min = inclusiveMin;
            _max = inclusiveMax;
        }

        public override int SampleDiscrete(RNG rnd)
        {
            return MathNet.Numerics.Distributions.DiscreteUniform.Sample(rnd, _min, _max);
        }
    }
}
