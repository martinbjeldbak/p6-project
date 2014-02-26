using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
  /// <summary>
  /// Input neuron.
  /// </summary>
  public class InputNeuron : Neuron{
    /// <summary>
    /// Sets the input value.
    /// </summary>
    /// <param name="value">The input value.</param>
    public void SetValue(double value) {
      this.Value = value;
    }
  }
}

