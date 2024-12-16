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
        void VisualizeDataSpreading(IEnumerable<DiceRoll> dataSet, string fileName);
        void VisualizeDataVariance(IEnumerable<DiceRoll> dataSet, string fileName);
        void VisualizeDataMedium(IEnumerable<DiceRoll> dataSet, string fileName);
    }
}
