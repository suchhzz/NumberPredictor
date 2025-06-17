using DefinerAi;
using NumberDetector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDetector.Controllers
{
    public class DefinerController
    {
        public DefinerController()
        {
            _definerService = new DefinerService();

            _topology = new Topology(28 * 28, 80, 10, 0);

            var weights = _definerService.LoadNeuronsWeights();
            var biases = _definerService.LoadNeuronsBiases();

            _neuralNetwork = new NeuralNetwork(_topology, weights, biases);
        }
        private readonly DefinerService _definerService;
        private readonly NeuralNetwork _neuralNetwork;
        private readonly Topology _topology;

        public string DefineNumber(Bitmap inputImage)
        {
            var inputs = _definerService.ConvertPictureToArray(inputImage);

            var neuronsOutputs = _neuralNetwork.DefineNumber(inputs);

            var output = _definerService.GetBiggestOutputFromNeurons(neuronsOutputs).ToString();

            return output;
        }
    }
}
