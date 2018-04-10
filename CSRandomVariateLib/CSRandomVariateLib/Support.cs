﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RandomVariateLib
{
    public enum EnumRandomVariates : int
    {
        Bernoulli = 1,
        Beta = 2,
        Bionomial = 3,
        Constant = 4,
        Continuous = 5,
        Discrete = 6,
        DiscreteUniform = 7,
        Erlang = 8,
        Exponential = 9,
        Gamma = 10,
        JohnsonSB = 11,
        JohnsonSU = 12,
        Lognormal = 13,
        Multinomial = 14,
        NHPP = 15,
        Normal = 16,
        NormalST = 17,
        Poisson = 18,
        Triangular = 19,
        Uniform = 20,
        Weibull = 21,

        Correlated = 22,
        LinearCombination = 23,
        MultipleCombination = 24,
        Multiplicative = 25,
        TimeDependetLinear = 26,
        TimeDependetOscillating = 27,
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
                case "multiple combination":
                    thisEnum = EnumRandomVariates.MultipleCombination;
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
                //case EnumRandomVariates.Correlated:
                //    rvg = new Correlated(name, par2, par3);
                //    break;
            }
            return rvg;
        }
    }
}