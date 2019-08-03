using System.Collections.Generic;
using CalculateExpressions.BusinessLogic.Recognitions.OperationRecognitions;
using CalculateExpressions.Domain;

namespace CalculateExpressions.BusinessLogic.Recognitions
{
    public class Recognizer : IRecognizer
    {
        public Recognizer()
        {
            Recognitions = new List<IOperationRecognition>
                {
                      new PlusRecognition(),
                      new MinusRecognition(),
                      new MultiplyRecognition(),
                      new DivideRecognition(),
                      new BracketsRecognition(),
                      new EmptyRecognition()
                };
        }

        #region IRecognizer Members

        public IOperation Recognize(string expression)
        {
            foreach (var recognition in Recognitions)
            {
                var res = recognition.Recognize(expression, this);
                if (res != null)
                    return res;
            }
            return null;
        }

        public IEnumerable<IOperationRecognition> Recognitions { get; protected set; }

        #endregion
    }

}