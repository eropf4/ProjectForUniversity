using System;
using System.Collections.Generic;

namespace CalculateExpressions.Domain
{
    public interface IExpression
    {
        double Result();
    }

    public interface IOperation
    {
        IExpression Calculate();
    }

    public interface IRecognizer
    {
        IOperation Recognize(String expression);
        IEnumerable<IOperationRecognition> Recognitions { get; }
    }

    public interface IOperationRecognition
    {
        IOperation Recognize(string expression, IRecognizer recognizer);
    }

    public abstract class UnaryOperation : IOperation
    {
        public IExpression Parameter { get; protected set; }

        protected UnaryOperation(IExpression param)
        {
            Parameter = param;
        }

        #region IOperation Members

        public abstract IExpression Calculate();

        #endregion
    }

    public abstract class BinaryOperation : IOperation
    {
        public IExpression Parameter1 { get; protected set; }

        public IExpression Parameter2 { get; protected set; }

        protected BinaryOperation(IExpression param1, IExpression param2)
        {
            Parameter1 = param1;
            Parameter2 = param2;
        }

        #region IOperation Members

        public abstract IExpression Calculate();

        #endregion
    }
}


