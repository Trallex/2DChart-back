using System;
using System.Collections.Generic;

using org.mariuszgromada.math.mxparser;


namespace _2DChart.Domain.EquationMenager
{
    public class Equation
    {
        Expression expression;
        double x;
        Data.Models.Function function;
        string functionString;

        public Equation(double x, Data.Models.Function function)
        {
            this.x = x;
            this.function = function;
            SetFunctionString(function.Parameters);
            expression.setExpressionString(functionString);            
        }

        public double GetFunctionValue(double x)
        {
            expression.setArgumentValue("x", x);
            return expression.calculate();

        }

        public void SetFunctionString(ICollection<Data.Models.Parameter> parameters)
        {
            functionString = "y = ";
            foreach (Data.Models.Parameter parameter in parameters)
            {
                if (parameter.Value < 0 || functionString == "y = ")
                    functionString += parameter.Value + " * " + parameter.Variable;
                else
                    functionString += " + " + parameter.Value + " * " + parameter.Variable;
            }         
        }

    }
}