using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public class Poisson : RVG
    {
        private double _rate;

        // instantiation
        public Poisson(string name, double rate)
            : base(name)
        {
            _rate = rate;
        }

        public override int SampleDiscrete(RNG rnd)
        {
            int v = 0;
            if (_rate>0)
                v = MathNet.Numerics.Distributions.Poisson.Sample(rnd, _rate);
            return v;
        }
    }
}
