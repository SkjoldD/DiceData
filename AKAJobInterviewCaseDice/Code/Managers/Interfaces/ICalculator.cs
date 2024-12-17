using AKAJobInterviewCaseDice.Code.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKAJobInterviewCaseDice.Code.Managers.Interfaces
{
    public interface ICalculator
    {
        double CalculateMean(double[] _data);
        double CalculateVariance(double[] _data);
        double CalculateDeviation(double[] _data);

        double CalculateStandardDeviation(double[] data, double mean);

    }
}
