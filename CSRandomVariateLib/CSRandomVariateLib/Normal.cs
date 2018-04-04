using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Random;
using MathNet.Numerics.Distributions;

namespace RandomVariateLib
{
    public class Normal : RVG
    {
        private double _mean, _stDev;

        public Normal(string name, double mean, double stDev)
            : base(name)
        {
            if (stDev <= 0)
            {
                Console.Write("Standard deviation must be greater than 0 for normal distribution.", "Error in Random Number Generator");
                return;
            }

            _mean = mean;
            _stDev = stDev;
        }

        public override double SampleContinuous(RNG rnd)
        {
            return MathNet.Numerics.Distributions.Normal.Sample(rnd, _mean, _stDev);
        }

    }
}
