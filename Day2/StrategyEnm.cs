using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal enum StrategyEnm
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    internal enum FirstGroup
    {
        A = StrategyEnm.Rock,
        B = StrategyEnm.Paper,
        C = StrategyEnm.Scissors
    }

    internal enum SecondGroup
    {
        X = StrategyEnm.Rock,
        Y = StrategyEnm.Paper,
        Z = StrategyEnm.Scissors
    }

    public static class Results
    {
        public static readonly int Win = 6;
        public static readonly int Draw = 3;
    }

}
