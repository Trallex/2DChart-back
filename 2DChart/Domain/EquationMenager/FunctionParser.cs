using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2DChart.Data.Models;

namespace _2DChart.Domain.EquationMenager
{
    public class FunctionParser
    {
        private static org.mariuszgromada.math.mxparser.Function _function;
        public static void GetFunctionParameters(string functionBody)
        {
            _function = new org.mariuszgromada.math.mxparser.Function(functionBody);
            if (!_function.checkSyntax()) return;


        }
    }
}
