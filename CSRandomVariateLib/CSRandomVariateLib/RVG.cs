using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.Random;

namespace RandomVariateLib
{
    // random variate generator
    public class RVG
    {
        private string _name;

        // instantiation 
        public RVG(string name)
        {
            _name = name;
        }
        public virtual double SampleContinuous(RNG rnd)
        {
            return 0;
        }
        public virtual int SampleDiscrete(RNG rnd)
        {
            return 0;
        }
        public virtual double[] ArrSampleContinuous(RNG rnd)
        {
            return null;
        }
        public virtual int[] ArrSampleDiscrete(RNG rnd)
        {
            return null;
        }
        public virtual double[] GetEquallyDistributedPoints(int nOfPoints)
        {
            return null;
        }
    }
}
