using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureOperations
{
    public class PictureConverter
    {
        public void ReverseConvertedPicture(double[] convertedImage)
        {
            for (int i = 0; i < convertedImage.Length; i++)
            {
                if (convertedImage[i] == 0)
                {
                    convertedImage[i] = 1;
                }
                else
                {
                    convertedImage[i] = 0;
                }
            }
        }

        public double[] Convert(string path)
        {
            var image = new Bitmap(path);

            var convertedImage = new double[28 * 28];

            int counter = 0;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var selectedPixel = image.GetPixel(x, y);
                    convertedImage[counter++] = ConvertToSemitone(selectedPixel);
                }
            }

            return convertedImage;
        }

        public double[] Convert(Bitmap image)
        {
            var convertedImage = new double[28 * 28];

            int counter = 0;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var selectedPixel = image.GetPixel(x, y);
                    convertedImage[counter++] = ConvertToSemitone(selectedPixel);
                }
            }

            return convertedImage;
        }

        private int ConvertToSemitone(Color color)
        {
            var result = color.R * 0.299 + color.G * 0.587 + color.B * 0.114;

            return result <= 128 ? 0 : 1;
        }
    }
}
