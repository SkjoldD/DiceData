using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKAJobInterviewCaseDice.Code.Managers.File_read;
using AKAJobInterviewCaseDice.Code.Managers.Interfaces;

namespace AKAJobInterviewCaseDice.Code.Managers
{
    public class DependencyInjectionManager
    {

        private IFileReaderManager frm;
        public DependencyInjectionManager() 
        {
            frm = new FileReaderManager();
        }
        public T GetDependency<T>()
        {
            if (typeof(T) == typeof(IFileReaderManager))
            {
                return (T) frm;
            }


            throw new Exception("The type: " + typeof(T).ToString() + ", was not found in the DependencyInjectionManager");
        }
    }
}
