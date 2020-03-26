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
                throw new System.ArgumentException("Alpha must be greater than 0 for a Beta distribution.");
            }
            if (beta <= 0)
            {
                throw new System.ArgumentException("Beta must be greater than 0 for a Beta distribution.");
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
            double critical = MathNet.Numerics.Distributions.Normal.InvCDF(0, 1, 1 - 0.05 / 2);
            double stDev = halfWidth / (critical * (max - min));
            double stMean = (mean - min) / (max - min);
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

