using System;
using System.Collections.Generic;

namespace _2DChart.Domain.EquationMenager
{
    public class FunctionString
    {

        public string FString { get; set; }

        public FunctionString(List<Data.Models.Parameter> parameters)
        {
            FString = "y = ";
            foreach(Data.Models.Parameter parameter in parameters)
            {
                if (parameter.Value < 0 || FString == "y = ")
                    FString += parameter.Value + " * " + parameter.Variable;                  
                else
                    FString += " + " + parameter.Value + " * " + parameter.Variable;
            }
        }
    }
}