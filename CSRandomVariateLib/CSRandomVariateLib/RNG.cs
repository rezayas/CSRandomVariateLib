using System;
using MathNet.Numerics.Random;

namespace RandomVariateLib
{
    public class RNG : MersenneTwister
    {
        int _seed = 0;
        //MersenneTwister _mt;

        public RNG(int seed):
            base(seed, true)   // thread safe
        {
            _seed = seed;
        }

        public int Seed
        { get { return _seed; } }

    }
}
