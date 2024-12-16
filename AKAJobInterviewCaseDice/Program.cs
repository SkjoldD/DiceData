// See https://aka.ms/new-console-template for more information
using AKAJobInterviewCaseDice.Code.Data;
using AKAJobInterviewCaseDice.Code.Managers;
using AKAJobInterviewCaseDice.Code.Managers.Interfaces;
using System.Diagnostics;

using ScottPlot;


Console.WriteLine("Program launch");

DependencyInjectionManager dependencyInjectionManager = new DependencyInjectionManager();
IFileReaderManager frm = dependencyInjectionManager.GetDependency<IFileReaderManager>();
IDataVisualizationManager dvm = dependencyInjectionManager.GetDependency<IDataVisualizationManager>();

string rootPath = "C:\\Users\\skdyr\\Desktop\\AKA\\AKAJobInterviewCaseDice\\AKAJobInterviewCaseDice";

string filePath = rootPath+ "\\Input\\data.csv";
string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

// Use fullPath to access the file
Console.WriteLine(fullPath);

IEnumerable<DiceRoll> diceRollsIE = frm.ReadCSVFile(filePath);



string filePathPlot = rootPath+"\\Data visualization\\plot.png";

dvm.VisualizeDataSpreading(diceRollsIE, filePathPlot);

