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

        // Function to generate data for the normal distribution curve
        public List<(double x, double y)> GenerateNormalDistributionData(double mean, double stdDev, double startX, double endX, double step)
        {
            var dataPoints = new List<(double x, double y)>();

            // Check the parameters for debugging purposes
            Console.WriteLine($"Generating data for x range: {startX} to {endX}, with step size: {step}");

            for (double x = startX; x <= endX; x += step)
            {
                // Normal distribution formula
                double exponent = -Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2));
                double y = (1 / (stdDev * Math.Sqrt(2 * Math.PI))) * Math.Exp(exponent);

                // Debugging: Print values to see what happens
                Console.WriteLine($"x: {x}, y: {y}");

                dataPoints.Add((x, y * 100));
            }

            return dataPoints;
        }
    }
}
