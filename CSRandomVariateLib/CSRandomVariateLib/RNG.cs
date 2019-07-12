using System;
using MathNet.Numerics.Random;

namespace RandomVariateLib
{
    public class RNG : MersenneTwister
    {
        public int Seed { get; } = 0;

        public RNG(int seed):
            base(seed, true)   // thread safe
        {
            Seed = seed;
        }

        public void Advance(int n)
        {
            for (int i=0; i < n; i++)
                base.Next();
        }
    }
}
