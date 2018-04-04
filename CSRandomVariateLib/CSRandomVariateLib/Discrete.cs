using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public class Discrete : RVG
    {
        private double[] _probabilityMass;

        // instantiation
        public Discrete(string name, double[] probabilityMass)
            : base(name)
        {
            _probabilityMass = (double[])probabilityMass.Clone();
        }

        public override int SampleDiscrete(RNG rnd)
        {
            return MathNet.Numerics.Distributions.Categorical.Sample(rnd,_probabilityMass);
        }
    }
}
