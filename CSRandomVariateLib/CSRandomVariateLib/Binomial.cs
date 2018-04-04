using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RandomVariateLib
{
    public class Bionomial : RVG
    {
        private double _probOfSuccess;
        private int _numOfTrials;

        public Bionomial(string name, int numOfTrials, double probOfSuccess)
            : base(name)
        {
            if (numOfTrials < 0)
            {
                Console.Write("Number of trials cannot be less than 0 for multinomial distribution.");
                return;
            }
            if (probOfSuccess < 0 || probOfSuccess > 1)
            {
                Console.Write("Probability of success should be between 0 and 1 for Bionomial distribution.");
                return;
            }

            _numOfTrials = numOfTrials;
            _probOfSuccess = probOfSuccess;
        }
        public override int SampleDiscrete(RNG rnd)
        {

            if (_probOfSuccess == 0 || _numOfTrials == 0)
                return 0;

            double mean = _numOfTrials * _probOfSuccess;
            double st_dev = Math.Sqrt(mean * (1 - _probOfSuccess));

            // if normal approximation can be used
            if (mean - 3*st_dev > 0 && mean + 3 * st_dev < _numOfTrials)
            {
                Normal normal = new Normal("Approximating normal", mean, st_dev);
                double sample = normal.SampleContinuous(rnd);

                if (sample < 0) sample = 0;
                if (sample > _numOfTrials) sample = _numOfTrials;

                return (int) Math.Round(sample, 0);
            }
            else
                return MathNet.Numerics.Distributions.Binomial.Sample(rnd, _probOfSuccess, _numOfTrials);
        }
    }
}
