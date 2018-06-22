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
            double sample = MathNet.Numerics.Distributions.Beta.Sample(rnd, _alpha, _beta);
            return _min + (_max - _min) * sample;
        }
    }

    public class Beta_Interval : RVG
    {
        Beta _beta;

        public Beta_Interval(string name, double mean, double halfWidth, double min=0, double max=1) 
            :base(name)
        {
            double stDev = halfWidth / (3 * (max - min));
            double stMean = mean / (max - min);
            double alphaPlusBeta = stMean * (1 - stMean) / Math.Pow(stDev, 2) - 1;
            double alpha = stMean * alphaPlusBeta;
            double beta = alphaPlusBeta - alpha;

            _beta = new Beta(name, alpha, beta, min, max);
        }

        public override double SampleContinuous(RNG rnd)
        {
            return _beta.SampleContinuous(rnd);
        }
    }
}

