using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi
{
    public class Topology
    {
        public int InputNeurons { get; set; }
        public int HiddenNeurons { get; set; }
        public int OutputNeurons { get; set; }
        public double LearningRate { get; set; }

        public Topology(int inputNeurons, int hiddenNeurons, int outputNeurons, double learningRate)
        {
            InputNeurons = inputNeurons;
            HiddenNeurons = hiddenNeurons;
            OutputNeurons = outputNeurons;
            LearningRate = learningRate;
        }
    }
}
