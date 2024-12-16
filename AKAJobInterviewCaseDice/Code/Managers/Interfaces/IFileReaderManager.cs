using AKAJobInterviewCaseDice.Code.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKAJobInterviewCaseDice.Code.Managers.Interfaces
{
    public interface IFileReaderManager
    {
        IEnumerable<DiceRoll> ReadCSVFile(string fileName);
    }
}
