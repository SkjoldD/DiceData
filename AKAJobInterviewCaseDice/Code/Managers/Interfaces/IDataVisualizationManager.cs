using AKAJobInterviewCaseDice.Code.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKAJobInterviewCaseDice.Code.Managers.Interfaces
{
    public interface IDataVisualizationManager
    {
        void VisualizeDataSpreadingVarianceAverage(double[] data, string fileName);
        void VisualizeDataRunningTotal(double[] data, string fileName);
    }
}
