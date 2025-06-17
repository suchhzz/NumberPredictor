using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi.Models.Formules
{
    static class NeuralMath
    {
        static public double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }

        static public double SigmoidDx(double x)
        {
            return Sigmoid(x) / (1.0 - Sigmoid(x));
        }
    }
}
