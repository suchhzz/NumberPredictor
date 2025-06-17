using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DatasetOperations
{
    public class FileOperation
    {
        private int weightsCount = 63520;
        private int biasesCount = 90;
        private string weightsPath = "C:\\Users\\jenje\\source\\repos\\NumberDetector\\weights.json";
        private string biasesPath = "C:\\Users\\jenje\\source\\repos\\NumberDetector\\biases.json";
        private string imagesPath = "C:\\Users\\jenje\\source\\repos\\NumberDefiner\\NumbersDataset\\Hnd\\Sample";
        public double[] GetWeightsFromFile()
        {
            var jsonContent = File.ReadAllText(weightsPath);

            var weights = JsonConvert.DeserializeObject<double[]>(jsonContent);

            return weights;
        }

        public double[] GetBiasesFromFile()
        {
            var jsonContent = File.ReadAllText(biasesPath);

            var biases = JsonConvert.DeserializeObject<double[]>(jsonContent);

            return biases;
        }

        public void SaveWeights(double[] weights)
        {
            string json = JsonConvert.SerializeObject(weights, Formatting.Indented);

            File.WriteAllText(weightsPath, json);
        }

        public void SaveBiases(double[] biases)
        {
            string json = JsonConvert.SerializeObject(biases, Formatting.Indented);

            File.WriteAllText(biasesPath, json);
        }

        public (string, int) GetRandomImageFromFile()
        {
            var rnd = new Random();

            int expected = rnd.Next(0, 10);

            var imageDirectory = Directory.GetFiles(imagesPath + expected);

            return (imageDirectory[rnd.Next(0, imageDirectory.Length - 1)], expected);
        }
    }
}
