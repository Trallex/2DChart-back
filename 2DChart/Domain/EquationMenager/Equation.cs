using System;
using System.Collections.Generic;

using org.mariuszgromada.math.mxparser;

namespace _2DChart.Domain.EquationMenager
{
    public class Equation
    {
        Data.Models.Function functionData;
        Expression expression;
        org.mariuszgromada.math.mxparser.Function function;

        public Equation( Data.Models.Function functionData )
        {
            this.functionData = functionData;
            function = new org.mariuszgromada.math.mxparser.Function(functionData.FunctionString);
        }

        public bool CheckSyntax()
        {
            return function.checkSyntax();
        }


        public List<double> GetPoints()
        {
            List<double> points = new List<double>();
            double step = (Math.Abs(functionData.Min) + Math.Abs(functionData.Max)) / 1000;
            for (double i = functionData.Min; i <= functionData.Max; i += step)
            {
                points.Add(GetFunctionValue(i));
            }
            return points;
        }

        private double GetFunctionValue(double x)
        {
            Argument a = new Argument(" x = " + x);
            expression = new Expression("f(" + x + ")", function);
            return Math.Round(expression.calculate(),functionData.Approximation);

        }


    }
}