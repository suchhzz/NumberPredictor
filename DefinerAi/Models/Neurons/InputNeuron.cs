using DefinerAi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi.Models.Neurons
{
    public class InputNeuron : INeuron
    {
        public double[] Weights { get; set; }
        public double[] Inputs { get; set; }
        public double Output { get; set; }
        public double Delta { get; set; }
        public double Bias { get; set; }

        public InputNeuron()
        {
            Inputs = new double[1];
            Weights = new double[] { 1.0 };
        }

        public double FeedForward(double[] inputs)
        {
            var sum = inputs[inputs.Length - 1] * Weights[inputs.Length - 1];

            Output = sum;

            return Output;
        }

        public void Learn(double error, double learningRate)
        {
            return;
        }
    }
}
