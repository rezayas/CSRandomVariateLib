using System;
using System.Collections.Generic;
using System.Text;
using RandomVariateLib;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace TestRVGs
{
    class Tests
    {
        // Test normal distribution 
        public static void TestRND(int N, RNG rnd)
        {
            double[] samples = new double[N];
            for (int i = 0; i < N; i++)
                samples[i] = rnd.NextDouble();

            Console.WriteLine("\nTesting RND:");
            Console.WriteLine("  E[X] = " + 0.5 + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + 1/Math.Sqrt(12) + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }

        // Test normal distribution 
        public static void TestNormal(int N, RNG rnd, double mean, double stDev)
        {
            Normal normal = new Normal("Normal", mean, stDev);

            double[] samples = SampleContinuous(normal, rnd, N);
            Console.WriteLine("\nTesting Normal:");
            Console.WriteLine("  E[X] = " + mean + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + stDev + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }

        // Test Binomial distribution 
        public static void TestBinomial(int N, RNG rnd, int n, double p)
        {
            Bionomial bionomial = new Bionomial("Binomial", n, p);

            int[] samples = SampleDiscrete(bionomial, rnd, N);
            Console.WriteLine("\nTesting Binomial:");
            Console.WriteLine("  E[X] = " + n*p + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + Math.Sqrt(n * p*(1-p)) + " | sample st. dev. = " + Statistics.StandardDeviation(Array.ConvertAll<int, double>(samples, Convert.ToDouble)));
        }

        // Test Beta distribution 
        public static void TestBeta(int N, RNG rnd, double alpha, double beta)
        {
            Beta betaDis = new Beta("Beta", alpha, beta, 0, 1);

            double[] samples = SampleContinuous(betaDis, rnd, N);
            Console.WriteLine("\nTesting Beta:");
            Console.WriteLine("  E[X] = " + alpha/(alpha+beta) + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + Math.Sqrt(alpha*beta/(alpha+beta+1)/Math.Pow(alpha+beta,2)) + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }

        // Test Beta_Interval distribution 
        public static void TestBetaInterval(int N, RNG rnd, double mean, double hw, double min, double max)
        {
            Beta_Interval betaIntDis = new Beta_Interval("Beta Interval", mean, hw, min, max);

            double[] samples = SampleContinuous(betaIntDis, rnd, N);
            Console.WriteLine("\nTesting Beta Interval:");
            Console.WriteLine("  E[X] = " + mean + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + hw/3 + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }

        // Test Gamma distribution 
        public static void TestGamma(int N, RNG rnd, double shape, double rate)
        {
            Gamma gamma = new Gamma("Gamma", shape, rate);

            double[] samples = SampleContinuous(gamma, rnd, N);
            Console.WriteLine("\nTesting Gamma:");
            Console.WriteLine("  E[X] = " + shape/rate + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + Math.Sqrt(shape/Math.Pow(rate, 2)) + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }

        // Test Gamma_Interval distribution 
        public static void TestGammaInterval(int N, RNG rnd, double mean, double hw)
        {
            Gamma_Interval gammaIntDist = new Gamma_Interval("Gamma Interval", mean, hw);

            double[] samples = SampleContinuous(gammaIntDist, rnd, N);
            Console.WriteLine("\nTesting Gamma Interval:");
            Console.WriteLine("  E[X] = " + mean + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + hw / 3 + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }

        // Test Poisson distribution 
        public static void TestPoisson(int N, RNG rnd, double rate)
        {
            Poisson poissonDis = new Poisson("Poisson", rate);

            int[] samples = SampleDiscrete(poissonDis, rnd, N);
            Console.WriteLine("\nTesting Poisson:");
            Console.WriteLine("  E[X] = " + rate + " | sample mean = " + samples.Average());
            //Console.WriteLine("  SD[X] = " + Math.Sqrt(rate) + " | sample st. dev. = " + Statistics.StandardDeviation(samples);
        }

        // Test uniform distribution 
        public static void TestUniform(int N, RNG rnd, double l, double u)
        {
            Uniform uniform = new Uniform("Uniform", l, u);
            double mean = (u + l) / 2;
            double stdev = (u - l) / Math.Sqrt(12);

            double[] samples = SampleContinuous(uniform, rnd, N);
            Console.WriteLine("\nTesting Uniform:");
            Console.WriteLine("  E[X] = " + mean + " | sample mean = " + samples.Average());
            Console.WriteLine("  SD[X] = " + stdev + " | sample st. dev. = " + Statistics.StandardDeviation(samples));
        }        

        // Test multinomial distribution 
        public static void TestMultinomial(int N, RNG rnd, double[] probs, int nOfTrials)
        {
            Multinomial multinomial = new Multinomial("Multinomial", nOfTrials, probs);

            int[][] samples = ArrSampleDiscrete(multinomial, rnd, N);
            Console.WriteLine("\nTesting Multinomial:");

            // int[] test = new int[] { 1, 2 };
            // Console.WriteLine(string.Join(",", test));
            // Console.WriteLine("  E[X] = " + mean + " | sample mean = " + samples.Average());
            // Console.WriteLine("  SD[X] = " + stDev + " | sample st. dev. = " + StatSupport.StDev(samples));
        }


        /// <summary>
        /// sample from a continuous random variate generator 
        /// </summary>
        /// <param name="RVG"> random variate generator to generate realizations from </param>
        /// <param name="rnd"> random number generator </param>
        /// <param name="N"> number of realizations </param>
        /// <returns> an array of realizations </returns>
        static double[] SampleContinuous(RVG rvg, RNG rnd, int N)
        {
            double[] results = new double[N];
            for (int i = 0; i < N; i++)
                results[i] = rvg.SampleContinuous(rnd);

            return results;
        }

        static int[] SampleDiscrete(RVG rvg, RNG rnd, int N)
        {
            int[] results = new int[N];
            for (int i = 0; i < N; i++)
                results[i] = rvg.SampleDiscrete(rnd);

            return results;
        }

        /// <summary>
        /// sample from a discrete multivariate random variate generator 
        /// </summary>
        /// <param name="RVG"> random variate generator to generate realizations from </param>
        /// <param name="rnd"> random number generator </param>
        /// <param name="N"> number of realizations </param>
        /// <returns> an array of realizations </returns>
        static int[][] ArrSampleDiscrete(RVG rvg, RNG rnd, int N)
        {
            int[][] results = new int[N][];
            for (int i = 0; i < N; i++)
                results[i] = rvg.ArrSampleDiscrete(rnd);

            return results;
        }
    }
}

