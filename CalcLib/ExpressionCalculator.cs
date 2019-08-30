using System;
using NCalc2;

namespace CalcLib
{
    public class ExpressionCalculator
    {
        public string Calculate(string calculation)
        {
            if (string.IsNullOrWhiteSpace(calculation))
                return string.Empty;
            var result = new Expression(calculation);
            try
            {
                var evaluation = result.Evaluate();
                return evaluation.ToString();
            }
            catch (Exception e)
            {
                return $"{e.Message} (Your old calculation was {calculation}.";
            }
        }
    }
}