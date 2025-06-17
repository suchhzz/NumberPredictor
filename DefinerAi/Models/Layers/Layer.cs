using DefinerAi.Enums;
using DefinerAi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi.Models.Layers
{
    public class Layer
    {
        public INeuron[] Neurons { get; set; }
        public LayerType Type { get; set; }

        public Layer(INeuron[] neurons, LayerType type)
        {
            Neurons = neurons;
            Type = type;
        }

        public double[] GetNeuronsOutputs()
        {
            return Neurons.Select(n => n.Output).ToArray();
        }
    }
}
