using CalculateExpressions.BusinessLogic.Expressions;
using CalculateExpressions.Domain;

namespace CalculateExpressions.BusinessLogic.Operations
{
    public class Plus : BinaryOperation
    {
        public Plus(IExpression param1, IExpression param2) :
          base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Parameter1.Result() + Parameter2.Result());
        }
    }

    public class Minus : BinaryOperation
    {
        public Minus(IExpression param1, IExpression param2) :
          base(param1, param2)
        {

        }

        #region IOperation Members

        public override IExpression Calculate()
        {
            return new SimpleExpression(Parameter1.Result() - Parameter2.Result());
        }

        #endregion
    }

    public class EmptyOperation : UnaryOperation
    {
        public EmptyOperation(IExpression param)
          : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return Parameter;
        }
    }

    public class Brackets : UnaryOperation
    {
        public Brackets(IExpression param)
          : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Parameter.Result());
        }
    }

    public class Multiply : BinaryOperation
    {
        public Multiply(IExpression param1, IExpression param2)
          : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Parameter1.Result() * Parameter2.Result());
        }
    }

    public class Divide : BinaryOperation
    {
        public Divide(IExpression param1, IExpression param2)
          : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Parameter1.Result() / Parameter2.Result());
        }
    }
}
