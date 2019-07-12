using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RandomVariateLib
{
    public class Bionomial : RVG
    {
        private double _probOfSuccess;
        private double _1MinusProbOfSucess;
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
            _1MinusProbOfSucess = 1 - probOfSuccess;
        }
        public override int SampleDiscrete(RNG rng)
        {

            if (_probOfSuccess == 0 || _numOfTrials == 0)
                return 0;

            if (_probOfSuccess == 1)
                return _numOfTrials;

            double mean = _numOfTrials * _probOfSuccess;
            double st_dev = Math.Sqrt(mean * (1 - _probOfSuccess));

            // if normal approximation can be used
            if (mean - 3*st_dev > 0 && mean + 3 * st_dev < _numOfTrials)
            {
                Normal normal = new Normal("Approximating normal", mean, st_dev);
                double sample = normal.SampleContinuous(rng);

                if (sample < 0) sample = 0;
                if (sample > _numOfTrials) sample = _numOfTrials;

                return (int) Math.Round(sample, 0);
            }
            else
                return Sample(rng.NextDouble());
        }

        private int Sample(double rnd)
        {
            double p;
            int x;
            double probX;
            double cum;
            int rev; // 0 or 1 to specify the direction to search
            int sample;

            // based on the fact that if x is Bin(t,p) then t-X is Bin(t,1-p)
            rev = 0;
            p = _probOfSuccess;
            if (_probOfSuccess > 0.5)
            {
                rev = 1;            // change the direction 
                rnd = 1 - rnd;
                p = _1MinusProbOfSucess;
            }

            // uses recursive definition of cum dist
            x = 0;
            probX = Math.Pow(1 - p, _numOfTrials);
            cum = probX;
            while (rnd > cum && x < _numOfTrials)
            {
                x = x + 1;
                probX = probX * (_numOfTrials + 1 - x) * p / (x * (1 - p));
                cum = cum + probX;
            }
            sample = (1 - rev) * x + rev * (_numOfTrials - x);

            return sample;
        }
    }
}
