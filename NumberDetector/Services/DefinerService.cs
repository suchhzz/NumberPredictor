using DefinerAi.Interfaces;
using Learning.DatasetOperations;
using PictureOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberDetector.Services
{
    public class DefinerService
    {
        public DefinerService()
        {
            _converter = new PictureConverter();
            _fileOperation = new FileOperation();
        }

        private readonly PictureConverter _converter;
        private readonly FileOperation _fileOperation;
        public double[] ConvertPictureToArray(Bitmap image)
        {
            var resizedImage = ResizeToStandart(image);

            var convertedPicture = _converter.Convert(resizedImage);
            _converter.ReverseConvertedPicture(convertedPicture);

            return convertedPicture;
        }

        public int GetBiggestOutputFromNeurons(INeuron[] neurons)
        {
            var target = neurons.MaxBy(n => n.Output).Output;

            for (int i = 0; i < neurons.Length; i++)
            {
                if (neurons[i].Output == target)
                {
                    return i;
                }
            }

            return 0;
        }

        private Bitmap ResizeToStandart(Bitmap image)
        {
            var resizedimage = new Bitmap(image, 28, 28);

            return resizedimage;
        }

        public double[] LoadNeuronsWeights()
        {
            return _fileOperation.GetWeightsFromFile();
        }

        public double[] LoadNeuronsBiases()
        {
            return _fileOperation.GetBiasesFromFile();
        }
    }
}
