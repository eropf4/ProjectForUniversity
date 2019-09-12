using CalculateExpressions.Console;
using System.Collections.Generic;
using System;
using System.Text;

namespace CalculateExpressions.NewExpression
{
    public class VariedExpression
    {
        public static List<String> Change (String expression, double start, int finish, double step)
        { 
            var listofexpression = new List<String>();

            var flag = false;
            if (expression.Contains(@"/x")) flag = true;

            for (var i = start; i <= (double)finish; i += step)
            {
                if (flag && i == 0) continue;

                var strbldrexpression = new StringBuilder(expression);

                var cosx = Math.Cos(i).ToString();
                var sinx = Math.Sin(i).ToString();
                var tgx = Math.Tan(i).ToString();

                strbldrexpression.Replace("cosx", cosx);
                strbldrexpression.Replace("sinx", sinx);
                strbldrexpression.Replace("tgx", tgx);

                var number = i.ToString();
                strbldrexpression.Replace("x", number);
                strbldrexpression.Replace(",", ".");

                listofexpression.Add(strbldrexpression.ToString());

            }
            return listofexpression;
        }
        
    }
}
