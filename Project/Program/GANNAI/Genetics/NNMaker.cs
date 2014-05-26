using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialNeuralNetwork;

namespace Genetics {
  public interface NNMaker {
    int ChromosomeLength();
    NeuralNetwork MakeNeuralNetwork(Chromosome chromosome);
  }
}
