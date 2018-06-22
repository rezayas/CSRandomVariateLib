using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVariateLib
{
    public class Gamma : RVG
    {
        private double _shape, _rate;

        public Gamma(string name, double shape, double rate)
            :base(name)
        {
            if (!MathNet.Numerics.Distributions.Gamma.IsValidParameterSet(shape, rate))
            {
                Console.Write("Invalid parameters for Gamma.");
                return;
            }
            _shape = shape;
            _rate = rate;
        }

        public override double SampleContinuous(RNG rnd)
        {
            return MathNet.Numerics.Distributions.Gamma.Sample(rnd, _shape, _rate);
        }
    }

    public class Gamma_Interval : RVG
    {
        Gamma _gamma;

        public Gamma_Interval(string name, double mean, double halfWidth)
            : base(name)
        {
            double stDev = halfWidth / 3;
            double shape = Math.Pow(mean/stDev, 2);
            double rate = mean/ Math.Pow(stDev, 2);

            _gamma = new Gamma(name, shape, rate);
        }

        public override double SampleContinuous(RNG rnd)
        {
            return _gamma.SampleContinuous(rnd);
        }
    }
}
