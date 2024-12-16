using AKAJobInterviewCaseDice.Code.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using AKAJobInterviewCaseDice.Code.Data;
using ScottPlot;
using ScottPlot.Colormaps;
using System.Reflection.Emit;

public class DataVisualizationManager : IDataVisualizationManager
{
    public void VisualizeDataMedium(IEnumerable<DiceRoll> dataSet, string fileName)
    {
        throw new NotImplementedException();
    }

    public void VisualizeDataSpreading(IEnumerable<DiceRoll> dataSet, string fileName)
    {
        // Create a new plot
        var plt = new Plot();

        plt.XLabel("Terning");
        plt.YLabel("Værdi");

        // Add some data
        int[] xs = { 1, 2, 3, 4, 5, 6 }; // index
        int[] ys = { 0, 0, 0, 0, 0, 0 };//new double[dataSet.Count()] };

        foreach (DiceRoll diceRoll in dataSet)
        {
            ys[diceRoll.die1 - 1] = ys[diceRoll.die1 - 1] + 1;
            ys[diceRoll.die2 - 1] = ys[diceRoll.die2 - 1] + 1;
            Console.WriteLine(diceRoll.die1 + "," + diceRoll.die2);
        }

        int index = 1;
        foreach (int i in ys)
        {
            var bar = new Bar();

            // Customize the bar color (optional)
            bar.Value = i;
            bar.Position = index;

            bar.Label = i.ToString();

            bar.FillColor = ScottPlot.Color.RandomHue();
            // Set the bar width (optional)
            bar.LineWidth = 0.6f;
            // Add the bar chart to the plot
            plt.Add.Bar(bar);

            index++;

        }
        //plt.Add.Scatter(xs, ys);
        // Set the X-axis labels to the exact values from 'values'
        plt.Axes.set().ti(values: new double[] { 0, 1, 2, 3, 4 }, labels: values.Select(v => v.ToString()).ToArray());
        // Save the plot as an image with specified dimensions
        plt.SavePng(fileName, 600, 400);

    }


public void VisualizeDataVariance(IEnumerable<DiceRoll> dataSet, string fileName)
{
    throw new NotImplementedException();
}
}

