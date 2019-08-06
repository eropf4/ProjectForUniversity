using System;
using CalculateExpressions.NewExpression;
using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.BusinessLogic.Recognitions;
using System.Windows.Forms.DataVisualization.Charting;
using ConsoleApp4;

namespace CalculateExpressions.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form1();
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
            System.Console.ReadKey();
        }
    }
}