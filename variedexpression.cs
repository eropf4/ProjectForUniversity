using CalculateExpressions.Console;
using System.Collections.Generic;
using System;
using System.Text;

namespace CalculateExpressions.NewExpression
{
    public class VariedExpression
    {
        public static List<String> Change (String expression, int start, int finish)
        { 
            var listofexpression = new List<String>();

            for (var i = start; i <= finish; i++)
            {
                var strbldrexpression = new StringBuilder(expression);
                var number = i.ToString();

                strbldrexpression.Replace("x", number);
                listofexpression.Add(strbldrexpression.ToString());

            }
            return listofexpression;
        }
        
    }
}
