using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinerAi.Interfaces
{
    public interface INeuron
    {
        public double Output { get; set; }
        public double[] Weights { get; set; }
        public double Delta { get; set; }
        public double Bias { get; set; }
        double FeedForward(double[] inputs);
        void Learn(double error, double learningRate);
    }
}
