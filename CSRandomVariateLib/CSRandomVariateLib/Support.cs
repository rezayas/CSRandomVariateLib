using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public enum EnumRandomVariates : int
    {
        Bernoulli = 1,
        Beta = 2,
        BetaInterval = 3,
        Bionomial = 4,
        Constant = 5,
        Continuous = 6,
        Discrete = 7,
        DiscreteUniform = 8,
        Erlang = 9,
        Exponential = 10,
        Gamma = 11,
        GammaInterval = 12,
        JohnsonSB = 13,
        JohnsonSU = 14,
        Lognormal = 15,
        Multinomial = 16,
        NHPP = 17,
        Normal = 18,
        NormalST = 19,
        Poisson = 20,
        Triangular = 21,
        Uniform = 22,
        Weibull = 23,

        Correlated = 24,
        LinearCombination = 25,
        Product = 26,
        Multiplicative = 27,
        TimeDependetLinear = 28,
        TimeDependetOscillating = 29,
        ComorbidityDisutility = 30,

    }

    public static class SupportProcedures
    {

        /// <summary>
        /// Convert the name of a distribution to enum
        /// </summary>
        /// <param name="RVGName">Uniform; Normal.</param>
        public static EnumRandomVariates ConvertToEnumRVG(string RVGName)
        {
            EnumRandomVariates thisEnum = EnumRandomVariates.Constant;

            switch (RVGName.ToLower())
            {
                case "bernoulli":
                    thisEnum = EnumRandomVariates.Bernoulli;
                    break;
                case "beta":
                    thisEnum = EnumRandomVariates.Beta;
                    break;
                case "beta interval":
                    thisEnum = EnumRandomVariates.BetaInterval;
                    break;
                case "bionomial":
                    thisEnum = EnumRandomVariates.Bionomial;
                    break;
                case "constant":
                    thisEnum = EnumRandomVariates.Constant;
                    break;
                case "continuous":
                    thisEnum = EnumRandomVariates.Continuous;
                    break;
                case "discrete":
                    thisEnum = EnumRandomVariates.Discrete;
                    break;
                case "discrete uniform":
                    thisEnum = EnumRandomVariates.DiscreteUniform;
                    break;
                case "erlang":
                    thisEnum = EnumRandomVariates.Erlang;
                    break;
                case "exponential":
                    thisEnum = EnumRandomVariates.Exponential;
                    break;
                case "gamma":
                    thisEnum = EnumRandomVariates.Gamma;
                    break;
                case "gamma interval":
                    thisEnum = EnumRandomVariates.GammaInterval;
                    break;
                case "johnsonsb":
                    thisEnum = EnumRandomVariates.JohnsonSB;
                    break;
                case "Johnsonsu":
                    thisEnum = EnumRandomVariates.JohnsonSU;
                    break;
                case "lognormal":
                    thisEnum = EnumRandomVariates.Lognormal;
                    break;
                case "multinomial":
                    thisEnum = EnumRandomVariates.Multinomial;
                    break;
                case "nhpp":
                    thisEnum = EnumRandomVariates.NHPP;
                    break;
                case "normal":
                    thisEnum = EnumRandomVariates.Normal;
                    break;
                case "standard normal":
                    thisEnum = EnumRandomVariates.NormalST;
                    break;
                case "poisson":
                    thisEnum = EnumRandomVariates.Poisson;
                    break;
                case "triangular":
                    thisEnum = EnumRandomVariates.Triangular;
                    break;
                case "uniform":
                    thisEnum = EnumRandomVariates.Uniform;
                    break;
                case "weibull":
                    thisEnum = EnumRandomVariates.Weibull;
                    break;
                case "correlated":
                    thisEnum = EnumRandomVariates.Correlated;
                    break;
                case "linear combination":
                    thisEnum = EnumRandomVariates.LinearCombination;
                    break;
                case "product":
                    thisEnum = EnumRandomVariates.Product;
                    break;
                case "multiplicative":
                    thisEnum = EnumRandomVariates.Multiplicative;
                    break;
                case "time-dependent linear":
                    thisEnum = EnumRandomVariates.TimeDependetLinear;
                    break;
                case "time-dependent oscillating":
                    thisEnum = EnumRandomVariates.TimeDependetOscillating;
                    break;
                case "comorbidity disutility":
                    thisEnum = EnumRandomVariates.ComorbidityDisutility;
                    break;
                default:
                    throw new System.ArgumentException("Invalid value for parameter type.");
                    
            }
            return thisEnum;
        }


        /// <summary>
        /// Return a random variate generators
        /// </summary>
        public static RVG ReturnARandomVariateGenerator(EnumRandomVariates enumRVG, string name, double par1, double par2, double par3, double par4)
        {
            RVG rvg = null;

            switch (enumRVG)
            {
                case EnumRandomVariates.Constant:
                    rvg = new Constant(name, par1);
                    break;
                case EnumRandomVariates.Uniform:
                    rvg = new Uniform(name, par1, par2);
                    break;
                case EnumRandomVariates.Normal:
                    rvg = new Normal(name, par1, par2);
                    break;
                case EnumRandomVariates.Beta:
                    rvg = new Beta(name, par1, par2, par3, par4);
                    break;
                case EnumRandomVariates.BetaInterval:
                    rvg = new Beta_Interval(name, par1, par2, par3, par4);
                    break;
                case EnumRandomVariates.GammaInterval:
                    rvg = new Gamma_Interval(name, par1, par2);
                    break;
            }
            return rvg;
        }
    }
}
