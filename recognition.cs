using System;
using System.Globalization;
using System.Text.RegularExpressions;
using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.BusinessLogic.Helpers;
using CalculateExpressions.BusinessLogic.Operations;
using CalculateExpressions.Domain;

namespace CalculateExpressions.BusinessLogic.Recognitions.OperationRecognitions
{
    public class PlusRecognition : IOperationRecognition
    {
        #region OperationRecognition Members

        public IOperation Recognize(String expression, IRecognizer recognizer)
        {

            foreach (var parameters in SplitHelper.ParametersVariants(expression, '+'))
            {
                var arg1 = recognizer.Recognize(parameters.ParameterBefore);
                if (arg1 == null)
                    continue;
                var arg2 = recognizer.Recognize(parameters.ParameterAfter);
                if (arg2 == null)
                    continue;

                return new Plus(new CalculableExpression(arg1), new CalculableExpression(arg2));
            }
            return null;
        }

        #endregion
    }

    public class MinusRecognition : IOperationRecognition
    {
        #region OperationRecognition Members

        public IOperation Recognize(String expression, IRecognizer recognizer)
        {
            foreach (var parameters in SplitHelper.ParametersVariants(expression, '-'))
            {
                var arg1 = recognizer.Recognize(parameters.ParameterBefore);
                if (arg1 == null)
                    continue;
                var arg2 = recognizer.Recognize(parameters.ParameterAfter);
                if (arg2 == null)
                    continue;
                return new Minus(new CalculableExpression(arg1), new CalculableExpression(arg2));
            }
            return null;
        }

        #endregion
    }

    public class BracketsRecognition : IOperationRecognition
    {
        public Regex Condition { get; protected set; }

        public BracketsRecognition()
        {
            Condition = new Regex(@"^\((?<param>.*)\)$");
        }

        #region OperationRecognition Members

        public IOperation Recognize(String expression, IRecognizer recognizer)
        {
            if (!Condition.IsMatch(expression))
                return null;
            var operation = recognizer.Recognize(Condition.Match(expression).Result("${param}"));
            if (operation == null)
                return null;
            return new Brackets(new CalculableExpression(operation));
        }

        #endregion
    }

    public class MultiplyRecognition : IOperationRecognition
    {
        public IOperation Recognize(string expression, IRecognizer recognizer)
        {
            foreach (var parameters in SplitHelper.ParametersVariants(expression, '*'))
            {
                var arg1 = recognizer.Recognize(parameters.ParameterBefore);
                if (arg1 == null)
                    continue;
                var arg2 = recognizer.Recognize(parameters.ParameterAfter);
                if (arg2 == null)
                    continue;

                return new Multiply(new CalculableExpression(arg1), new CalculableExpression(arg2));
            }
            return null;
        }
    }

    public class DivideRecognition : IOperationRecognition
    {
        public IOperation Recognize(string expression, IRecognizer recognizer)
        {
            foreach (var parameters in SplitHelper.ParametersVariants(expression, '/'))
            {
                var arg1 = recognizer.Recognize(parameters.ParameterBefore);
                if (arg1 == null)
                    continue;
                var arg2 = recognizer.Recognize(parameters.ParameterAfter);
                if (arg2 == null)
                    continue;
                return new Divide(new CalculableExpression(arg1), new CalculableExpression(arg2));
            }
            return null;
        }
    }

        public class EmptyRecognition : IOperationRecognition
    {
        #region OperationRecognition Members

        public IOperation Recognize(String expression, IRecognizer recognizer)
        {
            double res;
            if (Double.TryParse(expression, NumberStyles.Float, CultureInfo.InvariantCulture, out res))
                return new EmptyOperation(new SimpleExpression(res));
            return null;
        }

        #endregion
    }
}
