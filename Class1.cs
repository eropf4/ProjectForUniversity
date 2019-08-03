using CalculateExpressions.Domain;

namespace CalculateExpressions.BusinessLogic.Expressions
{
    public class CalculableExpression : IExpression
    {
        public CalculableExpression(IOperation operation)
        {
            Operation = operation;
        }

        public double Result()
        {
            return Operation.Calculate().Result();
        }

        protected IOperation Operation { get; set; }
    }

    public class SimpleExpression : IExpression
    {
        protected double Number { get; set; }

        public SimpleExpression(double number)
        {
            Number = number;
        }

        public double Result()
        {
            return Number;
        }
    }

}
