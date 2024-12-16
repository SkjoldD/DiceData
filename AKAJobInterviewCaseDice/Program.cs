// See https://aka.ms/new-console-template for more information
using AKAJobInterviewCaseDice.Code.Data;
using AKAJobInterviewCaseDice.Code.Managers;
using AKAJobInterviewCaseDice.Code.Managers.Interfaces;
using System.Diagnostics;


Console.WriteLine("Program launch");
DependencyInjectionManager dependencyInjectionManager = new DependencyInjectionManager();

IFileReaderManager frm = dependencyInjectionManager.GetDependency<IFileReaderManager>();

string filePath = "C:\\Users\\skdyr\\source\\repos\\AKAJobInterviewCaseDice\\AKAJobInterviewCaseDice\\Input\\data.csv";
string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

// Use fullPath to access the file
Console.WriteLine(fullPath);

IEnumerable<DiceRoll> diceRollsIE = frm.ReadCSVFile(filePath);

foreach(DiceRoll diceRoll in diceRollsIE)
{
    Console.WriteLine(diceRoll.die1 + "," + diceRoll.die2);
}

