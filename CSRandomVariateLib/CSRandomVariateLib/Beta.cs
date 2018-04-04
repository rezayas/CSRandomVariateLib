using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public class Beta : RVG
    {
        private double _alpha, _beta, _min, _max;

        public Beta(string name, double alpha, double beta, double min, double max)
            : base(name)
        {
            if (alpha <= 0)
            {
                Console.Write("Alpha must be greater than 0 for a Beta distribution.");
                return;
            }
            if (beta <= 0)
            {
                Console.Write("Beta must be greater than 0 for a Beta distribution.");
                return;
            }

            _alpha = alpha;
            _beta = beta;
            _min = min;
            _max = max;
        }

        public override double SampleContinuous(RNG rnd)
        {
            double sample = MathNet.Numerics.Distributions.Beta.Sample(_alpha, _beta);
            return _min + (_max - _min)*sample;
        }

    }
}
