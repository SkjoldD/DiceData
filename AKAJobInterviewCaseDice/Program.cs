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
ICalculator calcMan = dependencyInjectionManager.GetDependency<ICalculator>();

string rootPath = "C:\\Users\\skdyr\\Desktop\\AKA\\AKAJobInterviewCaseDice\\AKAJobInterviewCaseDice";

string filePath = rootPath+ "\\Input\\data.csv";
string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

// Use fullPath to access the file
Console.WriteLine(fullPath);

IEnumerable<DiceRoll> diceRollsIE = frm.ReadCSVFile(filePath);

double[] diceRolls= new double[diceRollsIE.Count()];

int index = 0;
foreach(DiceRoll diceRoll in diceRollsIE)
{
    diceRolls[index] = diceRoll.die1 + diceRoll.die2;
    index += 1;
}


string filePathPlot = rootPath+"\\Data visualization\\plot.png";
string filePathRunningTotal = rootPath+"\\Data visualization\\plotRT.png";

//Console.WriteLine(calcMan.CalculateMean(diceDataDouble));
//Console.WriteLine(calcMan.CalculateVariance(diceDataDouble));
//Console.WriteLine(calcMan.CalculateDeviation(diceDataDouble));



dvm.VisualizeDataSpreadingVarianceAverage(diceRolls, filePathPlot);
//dvm.VisualizeDataRunningTotal(dice1DataDouble, filePathRunningTotal);

