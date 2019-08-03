using System;
using System.Collections.Generic;
using System.Text;
using CalculateExpressions.NewExpression;
using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.BusinessLogic.Recognitions;

namespace CalculateExpressions.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringrecognizer = VariedExpression.Change (System.Console.ReadLine());
            foreach (var recognation in stringrecognizer)
            {
                var recognizer = new Recognizer();
                var exp = new CalculableExpression(recognizer.Recognize(recognation));
                System.Console.WriteLine(exp.Result());
            }
            System.Console.ReadKey();
        }
    }

}