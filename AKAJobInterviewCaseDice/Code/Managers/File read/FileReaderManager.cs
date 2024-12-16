using AKAJobInterviewCaseDice.Code.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using AKAJobInterviewCaseDice.Code.Data;

namespace AKAJobInterviewCaseDice.Code.Managers.File_read
{
    internal class FileReaderManager : IFileReaderManager
    {
        public IEnumerable<DiceRoll> ReadCSVFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            IEnumerable<DiceRoll> data = lines.Skip(1) // Skip header row
                            .Select(line => line.Split(','))
                            .Select(columns => new DiceRoll
                            {
                                die1 = Convert.ToInt32(columns[0]),
                                die2 = Convert.ToInt32(columns[1]),
                            });

            return data;

        }
    }
}
