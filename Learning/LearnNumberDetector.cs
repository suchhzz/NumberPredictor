using DefinerAi;
using DefinerAi.Interfaces;
using Learning.DatasetOperations;
using PictureOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    public class LearnNumberDetector
    {
        public void Learn()
        {
            var fileOperation = new FileOperation();
            var converter = new PictureConverter();
            var topology = new Topology(28 * 28, 80, 10, 0.001);

            var initialWeights = fileOperation.GetWeightsFromFile();
            var initialBiases = fileOperation.GetBiasesFromFile();

            var neuralNetwork = new NeuralNetwork(topology, initialWeights, initialBiases);

            //LearnNeurons(neuralNetwork, fileOperation, 10000);

            CheckResults(neuralNetwork, fileOperation, converter);
        }

        private void LearnNeurons(NeuralNetwork neuralNetwork, FileOperation fileOperation, int imagesCount)
        {
            var output = CreateDataset(imagesCount);

            var dataset = output.Item1;
            var expected = output.Item2;

            var error = neuralNetwork.Learn(dataset, expected, 50);

            Console.WriteLine("Learn finished with error: " + error);

            fileOperation.SaveWeights(neuralNetwork.GetWeightsFromNeurons());
            fileOperation.SaveBiases(neuralNetwork.GetBiasesFromNeurons());
        }

        private void CheckResults(NeuralNetwork neuralNetwork, FileOperation fileOperation, PictureConverter converter)
        {
            double correct = 0.0;
            double wrong = 0.0;

            for (int i = 0; i < 1000; i++)
            {
                var cortage = fileOperation.GetRandomImageFromFile();

                var output = neuralNetwork.DefineNumber(converter.Convert(cortage.Item1));

                var biggestNeuronIndex = GetBiggestNeuronIndex(output);
                var neuronValue = output.Max(n => n.Output);

                Console.WriteLine($"AI Defined {cortage.Item2} as {biggestNeuronIndex} with value: {Math.Round(neuronValue, 2)} \t | iteration: {i}");

                if (biggestNeuronIndex == cortage.Item2)
                {
                    correct++;
                }
                else
                {
                    wrong++;
                }
            }

            Console.WriteLine($"correct: {correct} | wrong: {wrong} | avg correct: {(correct / (correct + wrong)) * 100}");
        }

        private int GetBiggestNeuronIndex(INeuron[] neurons)
        {
            var maxValue = neurons.Max(n => n.Output);

            for (int i = 0; i < neurons.Length; i++)
            {
                if (neurons[i].Output == maxValue)
                {
                    return i;
                }
            }

            return -1;
        }

        private (double[,], int[]) CreateDataset(int imagesCount)
        {
            var fileOperation = new FileOperation();
            var converter = new PictureConverter();

            var dataset = new double[imagesCount, 28 * 28];
            var expected = new int[imagesCount];

            for (int i = 0; i < imagesCount; i++)
            {
                var output = fileOperation.GetRandomImageFromFile();

                expected[i] = output.Item2;
                var convertedPicture = converter.Convert(output.Item1);

                WriteRowToTwoDimensional(dataset, convertedPicture, i);

                Console.Clear();
                Console.WriteLine($"Loading images.. [{i}/{imagesCount}]");
            }

            return (dataset, expected);
        }

        private void LearnOnDataset(NeuralNetwork neuralNetwork)
        {
            var images0 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample0";
            var images1 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample1";
            var images2 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample2";
            var images3 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample3";
            var images4 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample4";
            var images5 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample5";
            var images6 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample6";
            var images7 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample7";
            var images8 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample8";
            var images9 = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample9";

            var datasetService = new DatasetService();

            var dataset1 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images1), 1000);
            var dataset2 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images2), 1000);
            var dataset3 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images3), 1000);
            var dataset4 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images4), 1000);
            var dataset5 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images5), 1000);
            var dataset6 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images6), 1000);
            var dataset7 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images7), 1000);
            var dataset8 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images8), 1000);
            var dataset9 = datasetService.GetDatasetFromPictures(Directory.GetFiles(images9), 1000);
        }

        private void WriteRowToTwoDimensional(double[,] twoDimensional, double[] oneDimensional, int index)
        {
            for (int i = 0; i < oneDimensional.Length; i++)
            {
                twoDimensional[index, i] = oneDimensional[i];
            }
        }
    }
}
