using CalculateExpressions.Console;
using System.Collections.Generic;
using System;
using System.Text;

namespace CalculateExpressions.NewExpression
{
    public class VariedExpression
    {
        public static List<String> Change (String expression)
        { 
            var listofexpression = new List<String>();

            for (var i = 0; i <= 20; i++)
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
