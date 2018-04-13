using System;
using MathNet.Numerics.Random;

namespace RandomVariateLib
{
    public class RNG : MersenneTwister
    {
        public int Seed { get; set; } = 0;

        public RNG(int seed):
            base(seed, true)   // thread safe
        {
            Seed = seed;
        }
    }
}
