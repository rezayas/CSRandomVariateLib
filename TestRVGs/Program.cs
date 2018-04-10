using System;
using RandomVariateLib;
using System.Linq;

namespace TestRVGs
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 1000;
            RNG rnd = new RNG(1);

            Tests.TestRND(N, rnd);
            Tests.TestBinomial(N, rnd, 1000, 1-.0002);
            Tests.TestBeta(N, rnd, 2, 5);
            Tests.TestNormal(N, rnd, 10, 2);
            Tests.TestPoisson(N, rnd, 10);
            Tests.TestUniform(N, rnd, -5, 5);
        }
    }
}
