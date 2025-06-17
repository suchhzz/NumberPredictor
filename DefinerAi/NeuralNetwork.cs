using DefinerAi.Interfaces;
using DefinerAi.Models.Layers;
using DefinerAi.Models.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi
{
    public class NeuralNetwork
    {
        private Layer[] Layers { get; set; }
        private readonly Topology _topology;
        public NeuralNetwork(Topology topology)
        {
            _topology = topology;

            InitialLayers();
        }
        public NeuralNetwork(Topology topology, double[] weights, double[] biases)
        {
            _topology = topology;

            InitialLayers();
            SetWeightsToNeurons(weights);
            SetBiasesToNeurons(biases);
        }

        private void InitialLayers()
        {
            Layers = new Layer[3];

            CreateInputLayer();
            CreateHiddenLayer();
            CreateOutputLayer();
        }

        public INeuron[] DefineNumber(double[] inputs)
        {
            SendValuesToInputLayer(inputs);
            FeedForwardAllLayersAfterInput();

            return Layers[Layers.Length - 1].Neurons;
        }

        public double Learn(double[,] inputs, int[] expected, int epoch)
        {
            var error = 0.0;
            var lastError = 0.0;

            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                var expectedOutputs = CreateExpectedOutput(expected[i]);

                var input = GetRow(inputs, i);

                for (int j = 0; j < epoch; j++)
                {
                    lastError = BackPropagation(input, expectedOutputs);

                    error += lastError;
                }

                Console.WriteLine($"learning: {expected[i]} iteration: {i} | ERROR: {Math.Round(error, 4)}\t| LAST ERROR: {Math.Round(lastError, 4)}");
            }

            return error / epoch;
        }

        private double[] CreateExpectedOutput(int digit)
        {
            var output = new double[10];

            output[digit] = 1.0;

            return output;
        }

        public double BackPropagation(double[] inputs, double[] expected)
        {
            var difference = LearnOutputLayer(inputs, expected);
            LearnLayersAfterOutput();

            return Math.Pow(difference, 2);
        }

        private double LearnOutputLayer(double[] inputs, double[] expected)
        {
            var actualOutputs = DefineNumber(inputs).ToList().Select(n => n.Output).ToArray();

            var totalDifference = 0.0;

            for (int i = 0; i < actualOutputs.Length; i++)
            {
                var difference = actualOutputs[i] - expected[i];
                totalDifference += Math.Pow(difference, 2);

                var outputNeuron = Layers[Layers.Length - 1].Neurons[i];

                outputNeuron.Learn(difference, _topology.LearningRate);
            }

            return totalDifference / actualOutputs.Length;
        }

        private void LearnLayersAfterOutput()
        {
            for (int i = Layers.Length - 2; i >= 0; i--)
            {
                var currentLayer = Layers[i];
                var previousLayer = Layers[i + 1];

                for (int j = 0; j < currentLayer.Neurons.Length; j++)
                {
                    var currentNeuron = currentLayer.Neurons[j];

                    var error = 0.0;

                    for (int k = 0; k < previousLayer.Neurons.Length; k++)
                    {
                        var previousNeuron = previousLayer.Neurons[k];

                        error += previousNeuron.Weights[j] * previousNeuron.Delta;
                    }

                    currentNeuron.Learn(error, _topology.LearningRate);
                }
            }
        }

        private void FeedForwardAllLayersAfterInput()
        {
            for (int i = 0; i < Layers.Length - 1; i++)
            {
                var prevNeuronOutputs = Layers[i].GetNeuronsOutputs();

                foreach (var neuron in Layers[i + 1].Neurons)
                {
                    neuron.FeedForward(prevNeuronOutputs);
                }
            }
        }

        private void SendValuesToInputLayer(double[] inputs)
        {
            for (int i = 0; i < Layers[0].Neurons.Length; i++)
            {
                Layers[0].Neurons[i].FeedForward(new double[] { inputs[i] });
            }
        }

        private void CreateInputLayer()
        {
            var inputNeurons = new INeuron[_topology.InputNeurons];

            for (int i = 0; i < inputNeurons.Length; i++)
            {
                inputNeurons[i] = new InputNeuron();
            }

            Layers[0] = new Layer(inputNeurons, Enums.LayerType.Input);
        }

        private void CreateHiddenLayer()
        {
            for (int layerCounter = 0; layerCounter < Layers.Length - 2; layerCounter++)
            {
                var hiddenNeurons = new INeuron[_topology.HiddenNeurons];
                var previousLayer = Layers[layerCounter];

                for (int i = 0; i < hiddenNeurons.Length; i++)
                {
                    hiddenNeurons[i] = new NormalNeuron(previousLayer.Neurons.Length);
                }

                Layers[layerCounter + 1] = new Layer(hiddenNeurons, Enums.LayerType.Normal);
            }
        }

        private void CreateOutputLayer()
        {
            var outputNeurons = new INeuron[_topology.OutputNeurons];
            var previousLayer = Layers[Layers.Length - 2];

            for (int i = 0; i < outputNeurons.Length; i++)
            {
                outputNeurons[i] = new OutputNeuron(previousLayer.Neurons.Length);
            }

            Layers[Layers.Length - 1] = new Layer(outputNeurons, Enums.LayerType.Output);
        }

        static public double[] GetRow(double[,] array, int index)
        {
            var result = new double[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                result[i] = array[index, i];
            }

            return result;
        }

        public double[] GetBiasesFromNeurons()
        {
            var biases = new double[90];

            int index = 0;

            for (int i = 1; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Neurons.Length; j++)
                {
                    biases[index++] = Layers[i].Neurons[j].Bias;
                }
            }
            Console.WriteLine("biases count: " + index);

            return biases;
        }

        public double[] GetWeightsFromNeurons()
        {
            var weights = new double[63520];

            int index = 0;

            for (int i = 1; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Neurons.Length; j++)
                {
                    for (int k = 0; k < Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        weights[index++] = Layers[i].Neurons[j].Weights[k];
                    }
                }
            }
            Console.WriteLine("weights count: " + index);

            return weights;
        }

        public void SetWeightsToNeurons(double[] weights)
        {
            int weightIndex = 0;

            for (int i = 1; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Neurons.Length; j++)
                {
                    for (int k = 0; k < Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        Layers[i].Neurons[j].Weights[k] = weights[weightIndex++];
                    }
                }
            }
        }

        public void SetBiasesToNeurons(double[] biases)
        {
            int biasIndex = 0;

            for (int i = 1; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Neurons.Length; j++)
                {
                    Layers[i].Neurons[j].Bias = biases[biasIndex++];
                }
            }
        }
    }
}
