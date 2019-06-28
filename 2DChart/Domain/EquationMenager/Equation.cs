using System;
using System.Collections.Generic;

using org.mariuszgromada.math.mxparser;
using _2DChart.Domain.Function;

namespace _2DChart.Domain.EquationMenager
{
    public class Equation
    {
        Data.Models.Function functionData;
        Expression expression;
        org.mariuszgromada.math.mxparser.Function function;

        public Equation(Data.Models.Function functionData)
        {
            this.functionData = functionData;
            function = new org.mariuszgromada.math.mxparser.Function(functionData.FunctionString);
        }

        public bool CheckSyntax()
        {
            return function.checkSyntax();
        }


        public EvaluationDto GetPoints()
        {
            List<Double> pointsX = new List<Double>();
            List<Double?> pointsY = new List<Double?>();
            double step = (Math.Abs(functionData.Min) + Math.Abs(functionData.Max)) / 1000;
            for (double i = functionData.Min; i <= functionData.Max; i += step)
            {
                pointsX.Add(i);
                if (double.IsNaN(GetFunctionValue(i)))
                {
                    pointsY.Add(null);
                }
                else
                {
                    pointsY.Add(GetFunctionValue(i));
                }
                
            }

            return new EvaluationDto { x = pointsX, y = pointsY };
        }

        private double GetFunctionValue(double x)
        {
            Argument a = new Argument(" x = " + x);
            expression = new Expression("f(" + x + ")", function);
            return Math.Round(expression.calculate(), functionData.Approximation);

        }


    }
}