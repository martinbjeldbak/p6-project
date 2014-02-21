using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
  public class InputNeuron : Neuron{
    //set the input value
    public void SetValue(double value) {
      this.Value = value;
    }
  }
}

