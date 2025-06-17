using PictureOperations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DatasetOperations
{
    public class DatasetService
    {
        private string datasetPath = "C:\\Users\\jenje\\source\\repos\\NumberDetector\\dataset.txt";
        public void WriteToDataset(double[,] dataset)
        {
            using (var writer = new StreamWriter(datasetPath))
            {
                for (int i = 0; i < dataset.GetLength(0); i++)
                {
                    var input = ConvertRowToString(i, dataset);

                    writer.WriteLine(input);
                }
            }
        }

        public double[,] ReadFromDataset()
        {
            var dataset = new double[1000, 28 * 28];

            int index = 0;

            using (var reader = new StreamReader(datasetPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var converted = ConvertStringToDouble(line);

                    AddToDataset(index, dataset, converted);

                    index++;
                }
            }

            return dataset;
        }

        private double[] ConvertStringToDouble(string selectedRow)
        {
            double[] doubleArray = selectedRow
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(i =>
            {
                // Попытка преобразовать строку в double
                if (double.TryParse(i, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    return number;
                }
                else
                {
                    // Обработка некорректных данных
                    Console.WriteLine($"Ошибка преобразования: '{i}' не является допустимым числом.");
                    return 0.0; // Возвращаем значение по умолчанию или выбрасываем исключение
                }
            })
            .ToArray();

            return doubleArray;
        }

        private string ConvertRowToString(int index, double[,] dataset)
        {
            string converted = "";

            for (int i = 0; i < dataset.GetLength(1); i++)
            {
                converted += dataset[index, i] + ";";
            }

            return converted;
        }

        public double[,] GetDatasetFromPictures(string[] images, int count)
        {
            var converter = new PictureConverter();

            var dataset = new double[count, 28 * 28];

            for (int i = 0; i < count; i++)
            {
                var output = converter.Convert(images[i]);

                AddToDataset(i, dataset, output);
            }

            return dataset;
        }

        private void AddToDataset(int index, double[,] dataset, double[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                dataset[index, i] = items[i];
            }
        }

        public void VisualiseImageFromDataset(double[,] images)
        {
            var image = new Bitmap(28, 28);

            var path = "C:\\Users\\jenje\\source\\repos\\NumberDetector\\ImagesTest\\image";

            int counter = 0;

            for (int i = 0; i < images.GetLength(0); i++)
            {
                var pixels = GetRow(images, i);

                for (int y = 0; y < 28; y++)
                {
                    for (int x = 0; x < 28; x++)
                    {
                        var color = pixels[counter] == 1 ? Color.White : Color.Black;

                        counter++;

                        image.SetPixel(x, y, color);

                        image.Save(path + i + ".png");
                    }
                }

                counter = 0;
            }

            

        }

        private double[] GetRow(double[,] doubleDimensional, int index)
        {
            var oneDimensional = new double[doubleDimensional.GetLength(1)];

            for (int i = 0; i < oneDimensional.Length; i++)
            {
                oneDimensional[i] = doubleDimensional[index, i];
            }
            
            return oneDimensional;
        }
    }
}
