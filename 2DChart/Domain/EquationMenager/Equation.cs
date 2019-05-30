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
        FunctionString functionString;

        public Equation(double x, Data.Models.Function function, FunctionString functionString)
        {
            this.x = x;
            this.function = function;
            this.functionString = functionString;
            expression.setExpressionString(functionString.FString);            
        }

        public double GetFunctionValue(double x)
        {
            expression.setArgumentValue("x", x);
            return expression.calculate();

        }

    }
}