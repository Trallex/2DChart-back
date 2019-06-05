using System;
using System.Collections.Generic;

using org.mariuszgromada.math.mxparser;

namespace _2DChart.Domain.EquationMenager
{
    public class Equation
    {
        Expression expression;
        Function functionMX;
        Data.Models.Function function;
        string functionString;

        public string FunctionString
        {
            get { return functionString; }
        }

        public Equation(Data.Models.Function function)
        {
            this.function = function;
            SetFunctionString(function.Parameters);
            functionMX = new Function(functionString);

        }

        public double GetFunctionValue(double x)
        {
            Argument a = new Argument(" x = " + x);
            expression = new Expression("f(" + x + ")", functionMX);
            return expression.calculate();

        }
        

        public void SetFunctionString(ICollection<Data.Models.Parameter> parameters)
        {
            functionString = "f(x) = ";
            foreach (Data.Models.Parameter parameter in parameters)
            {
                if (parameter.Value < 0 || functionString == "f(x) = ")
                    functionString += parameter.ToString();
                else
                    functionString += "+ " + parameter.ToString();
            }         
        }

    }
}