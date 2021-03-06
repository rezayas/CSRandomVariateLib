﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RandomVariateLib
{
    public class Multinomial : RVG
    {
        private double[] _arrProbabilities;
        private int _numOfTrials;

        public Multinomial(string name, int numOfTrials, double[] arrProbabilities)
            :base(name)
        {
            if (numOfTrials < 0)
            {
                Console.Write("Number of trials cannot be less than 0 for multinomial distribution.", "Error in Random Number Generator");
                return;
            }
            double sum = arrProbabilities.Sum();
            if (sum < 0.9999 || sum > 1.0001)
            {
                Console.Write("Sum of probabilities should add to 1 for multinomial distribution.", "Error in Random Number Generator");
                return;
            }

            _numOfTrials = numOfTrials;
            _arrProbabilities = arrProbabilities;
        }

        public override int[] ArrSampleDiscrete(RNG rng)
        {
            int nOutcomes = _arrProbabilities.Length;
            int[] arrSample = new int[nOutcomes]; // store the random samples here
            int remainingNumberOfTrials = _numOfTrials;
            Bionomial binomial;

            double cum = 0;
            int i = 0;
            int nRndUsed = 0;
            while (remainingNumberOfTrials > 0 && i < nOutcomes - 1)
            //for (int i = 0; i < dimensionSize - 1; ++i)
            {
                if (cum < 1)
                {
                    binomial = new Bionomial("temp", remainingNumberOfTrials, Math.Min(_arrProbabilities[i] / (1 - cum), 1));
                    arrSample[i] = binomial.SampleDiscrete(rng);
                    ++nRndUsed;

                    cum += _arrProbabilities[i];
                    remainingNumberOfTrials -= arrSample[i];
                }
                else
                {
                    arrSample[i] = 0;
                }

                if (remainingNumberOfTrials < 0) remainingNumberOfTrials = 0;

                ++i;
            }
            arrSample[nOutcomes - 1] = remainingNumberOfTrials;

            // make sure to use as many random numbers as the number of outcomes
            if (nRndUsed < nOutcomes)
                rng.Advance(nOutcomes - nRndUsed);

            return arrSample;
        }
    }
}
