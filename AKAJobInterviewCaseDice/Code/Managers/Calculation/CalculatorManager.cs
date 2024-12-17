using AKAJobInterviewCaseDice.Code.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AKAJobInterviewCaseDice.Code.Managers.Calculation
{
    internal class CalculatorManager : ICalculator
    {
        public double CalculateDeviation(double[] _data)
        {
            double variance = this.CalculateVariance(_data);
            return Math.Sqrt(variance);
        }

        public double CalculateMean(double[] _data)
        {
            return _data.Average();
        }

        public double CalculateStandardDeviation(double[] data, double mean)
        {

            double sumOfSquares = 0;
            foreach (var value in data)
            {
                sumOfSquares += Math.Pow(value - mean, 2);
            }
            return Math.Sqrt(sumOfSquares / data.Length);

        }


        public double CalculateVariance(double[] _data)
        {
            double mean = CalculateMean(_data); // Find gennemsnit
            double sumOfSquares = _data.Select(x => Math.Pow(x - mean, 2)).Sum(); // Summen af kvadrater
            return sumOfSquares / _data.Length;
        }
    }
}
