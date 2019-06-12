using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using _2DChart.Data.Models;
using _2DChart.Domain.EquationMenager;
namespace _2DChart
{
    public class CalcTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("elo.");

            Parameter parameter1 = new Parameter();
            parameter1.Value = -3;
            parameter1.Variable = "x^2";
            Parameter parameter2 = new Parameter();
            parameter2.Value = 5;
            parameter2.Variable = "x";
            Parameter parameter3 = new Parameter();
            parameter3.Value = -3;
            parameter3.Variable = "1";

            ICollection<Parameter> parameters = new List<Parameter>();
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            parameters.Add(parameter3);

            Function function = new Function();
            function.Parameters = parameters;

            Equation equation = new Equation(function);


            Console.ReadKey();



        }
    }
}
