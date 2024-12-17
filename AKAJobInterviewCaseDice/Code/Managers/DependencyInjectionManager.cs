using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKAJobInterviewCaseDice.Code.Managers.Calculation;
using AKAJobInterviewCaseDice.Code.Managers.File_read;
using AKAJobInterviewCaseDice.Code.Managers.Interfaces;

namespace AKAJobInterviewCaseDice.Code.Managers
{
    public class DependencyInjectionManager
    {

        private IFileReaderManager frm;
        private IDataVisualizationManager dvm;
        private ICalculator calc;

        public DependencyInjectionManager() 
        {
            frm = new FileReaderManager();
            calc = new CalculatorManager();
            dvm = new DataVisualizationManager(calc);

        }
        public T GetDependency<T>()
        {
            if (typeof(T) == typeof(IFileReaderManager))
            {
                return (T)frm;
            }
            else if (typeof(T) == typeof(IDataVisualizationManager))
            {
                return (T)dvm;
            }
            else if (typeof(T) == typeof(ICalculator))
            {
                return (T)calc;
            }



            throw new Exception("The type: " + typeof(T).ToString() + ", was not found in the DependencyInjectionManager");
        }
    }
}
