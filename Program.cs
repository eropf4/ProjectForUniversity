using System;
using CalculateExpressions.NewExpression;
using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.BusinessLogic.Recognitions;
using System.Windows.Forms.DataVisualization.Charting;
using GraphInterface;
using System.Drawing;
using System.Windows.Forms;

namespace CalculateExpressions.Console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var series = new Series();
            System.Console.WriteLine("start:");var start = Convert.ToInt16( System.Console.ReadLine());
            System.Console.WriteLine("finish:");var finish = Convert.ToInt16(System.Console.ReadLine());
            var stringrecognizer = VariedExpression.Change (System.Console.ReadLine(), start, finish);
            foreach (var recognation in stringrecognizer)
            {
                var recognizer = new Recognizer();
                var exp = new CalculableExpression(recognizer.Recognize(recognation));
                start += 1;
                series.Points.Add(new DataPoint(exp.Result(), start));
                System.Console.WriteLine(series.Points.ToString());
            }

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            series.ChartType = SeriesChartType.FastLine;
            series.Color = Color.Red;
            series.MarkerBorderWidth = 3;

            chart.Series.Add(series);
            chart.Dock = DockStyle.Fill;
            var form = new Form1();
            form.Controls.Add(chart);
            Application.Run(form);
        }
    }
}