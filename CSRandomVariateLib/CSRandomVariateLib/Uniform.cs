using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public class Uniform: RVG
    {
        private double _min, _max;

        // instantiation
        public Uniform(string name, double min, double max) 
            : base(name)
        {
            if (min > max)
            {
                Console.Write("Minimum cannot be greater than maximum for a uniform distribution.", "Error in Random Number Generator");
                return;
            }
            _min = min;
            _max = max;
        }

        public override double SampleContinuous(RNG rnd)
        {
            return MathNet.Numerics.Distributions.ContinuousUniform.Sample(rnd, _min, _max);
        }
    }
}
