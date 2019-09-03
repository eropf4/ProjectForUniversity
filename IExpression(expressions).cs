using CalculateExpressions.Domain;

namespace CalculateExpressions.BusinessLogic.Expressions
{
    public class CalculableExpression : IExpression
    {
        protected IOperation Operation { get; set; }

        public CalculableExpression(IOperation operation)
        {
            Operation = operation;
        }

        public double Result()
        {
            return Operation.Calculate().Result();
        }

    }

    public class SimpleExpression : IExpression
    {
        protected double Number { get; set; }

        public SimpleExpression(double number)
        {
            Number = number;//ssss
        }

        public double Result()
        {
            return Number;
        }
    }

}
