using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateExpressions.BusinessLogic.Helpers
{
    public class SplitOpeartionParameters
    {
        public String ParameterAfter { get; protected set; }
        public String ParameterBefore { get; protected set; }

        public SplitOpeartionParameters(String parameterBefore, String parameterAfter)
        {
            ParameterAfter = parameterAfter;
            ParameterBefore = parameterBefore;
        }
    }

    public class SplitHelper
    {
        public static IEnumerable<SplitOpeartionParameters> ParametersVariants(string expression, char splitter)
        {
            var list = new List<SplitOpeartionParameters>();
            var str = expression.Split(splitter);
            if (!expression.Contains(splitter))
                return list;
            for (var i = 0; i < str.Length - 1; i++)
            {
                var param1 = String.Empty;
                var param2 = String.Empty;

                for (var j = 0; j <= i; j++)
                    param1 += str[j] + splitter;
                param1 = param1.Substring(0, param1.Length - 1);
                for (var j = i + 1; j < str.Length; j++)
                    param2 += str[j] + splitter;
                param2 = param2.Substring(0, param2.Length - 1);

                list.Add(new SplitOpeartionParameters(param1, param2));
            }
            return list;
        }
    }
}