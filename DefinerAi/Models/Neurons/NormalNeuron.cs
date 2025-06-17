using DefinerAi.Interfaces;
using DefinerAi.Models.Formules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi.Models.Neurons
{
    public class NormalNeuron : INeuron
    {
        public double[] Weights { get; set; }
        public double[] Inputs { get; set; }
        public double Output { get; set; }
        public double Delta { get; set; }
        public double Bias { get; set; } = 0;

        public NormalNeuron(int inputsCount)
        {
            Inputs = new double[inputsCount];
            InitialNeuron(inputsCount);
        }

        public double FeedForward(double[] inputs)
        {
            var sum = 0.0;

            for (int i = 0; i < inputs.Length; i++)
            {
                Inputs[i] = inputs[i];
            }

            for (int i = 0; i < Inputs.Length; i++)
            {
                sum += Inputs[i] * Weights[i];
            }

            sum += Bias;

            Output = NeuralMath.Sigmoid(sum);

            return Output;
        }

        private void InitialNeuron(int inputsCount)
        {
            var rnd = new Random();

            Weights = new double[inputsCount];

            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = rnd.NextDouble();
            }

            Bias = rnd.NextDouble();
        }

        public void Learn(double error, double learningRate)
        {
            Delta = error * NeuralMath.SigmoidDx(Output);

            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] = Weights[i] - Inputs[i] * Delta * learningRate;
            }

            Bias = Bias - Delta * learningRate;
        }
    }
}
