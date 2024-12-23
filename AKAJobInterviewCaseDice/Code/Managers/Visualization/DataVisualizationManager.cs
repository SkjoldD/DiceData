﻿using AKAJobInterviewCaseDice.Code.Managers.Interfaces;
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
using System.Data;
using ScottPlot.Plottables;

public class DataVisualizationManager : IDataVisualizationManager
{
    private ICalculator calculatorMan;
    public DataVisualizationManager(ICalculator _calculator)
    {
        this.calculatorMan = _calculator;
    }

    public void VisualizeDataRunningTotal(double[] data, string fileName)
    {
        // Create a new plot
        var plt = new Plot();

        plt.Title("Terning kast - RT");
        plt.XLabel("Kast nr.");
        plt.YLabel("Løbende sum");

        double[] diceThrowNumberX = new double[data.Length];
        int index = 0;
        foreach (double value in data)
        {
            diceThrowNumberX[index] = index + 1;
            index++;
        }

        // RUNNING TOTAL
        double[] runningTotalArr = new double[data.Length];
        double[] afvigelse = new double[data.Length];

        double runningTotal = 0;
        index = 0;
        foreach (double value in data)
        {
            runningTotal += value;
            runningTotalArr[index] = runningTotal;

            afvigelse[index] = calculatorMan.CalculateDeviation(runningTotalArr);
            index++;
        }

        // Afvigelse



        Scatter sp = plt.Add.Scatter(diceThrowNumberX, runningTotalArr);
        // sp.y

        plt.SavePng(fileName, 600, 400);
    }

    public void VisualizeDataSpreadingVarianceAverage(double[] data, string fileName)
    {
        // Create a new plot
        var plt = new Plot();

        plt.XLabel("Værdi");
        plt.YLabel("Antal");


        // Add some data
        int[] xs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; // index
        int[] ys = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//new double[dataSet.Count()] };

        foreach (double value in data)
        {
            ys[(int)value - 1] = ys[(int)value - 1] + 1;
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

        int maxyVal = ys.Max();
        int maxXVal = xs.Min();

        double variance = Math.Ceiling(calculatorMan.CalculateVariance(data) * 100) / 100;
        double mean = Math.Ceiling(calculatorMan.CalculateMean(data) * 100) / 100;
        // ADD LEGEND
        plt.Add.Text("Varians: "+ variance.ToString(), maxXVal, maxyVal);
        plt.Add.Text("Gennemsnit: "+mean.ToString(), maxXVal, maxyVal-1);


        double stdDev = calculatorMan.CalculateStandardDeviation(data, mean);

        List<(double x, double y)> plotData = calculatorMan.GenerateNormalDistributionData(mean, stdDev, 2, 12, 1);

        double[] xsNormD = plotData.Select(p => p.x).ToArray();
        double[] ysNormD = plotData.Select(p => p.y).ToArray();
        plt.Add.Scatter(xsNormD, ysNormD);

        //plt.Add.Scatter(xs, ys);
        // Set the X-axis labels to the exact values from 'values'
        // Save the plot as an image with specified dimensions
        plt.SavePng(fileName, 600, 400);

    }

}

