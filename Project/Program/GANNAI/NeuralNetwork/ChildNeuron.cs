using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace ArtificialNeuralNetwork {
  /// <summary>
  /// Child neuron used for hidden and output neurons.
  /// </summary>
  public class ChildNeuron : Neuron{

    /// <summary>
    /// The activation function (sigmoid).
    /// </summary>
    /// <returns> The output after applying the sigmoid function
    /// to the sum of the inputs given.</returns>
    /// <param name="sumInputs">The sum of inputs into a specific neuron.</param>
    private double ActivationFunction(double sumInputs) {
      return 1.0 / (1.0 + Math.Exp(-(sumInputs)));
    }

    /// <summary>
    /// List of input connections.
    /// </summary>
    protected List<Connection> inputs = new List<Connection>();

    /// <summary>
    /// Gets the list of input connections.
    /// </summary>
    /// <value>The list of input connections the neuron.</value>
    public List<Connection> GetInputs {
      get { return inputs; }
    }

    //add an incoming connection without specifying weight
    /// <summary>
    /// Adds an incoming connection. Weight is [-0.5, 0.5].
    /// </summary>
    /// <param name="from">The neuron which the connections is coming from.</param>
    public void AddInputConnection(Neuron from) {
      double weight = Utility.RandomDouble() - 0.5;
      AddInputConnection(from, weight);
    }

    //add an incoming connection without specifying weight
    /// <summary>
    /// Adds an incoming connection.
    /// </summary>
    /// <param name="from">The neuron which the connections is coming from.</param>
    /// <param name="weight">The weight for the connection.</param>
    public void AddInputConnection(Neuron from, double weight) {
      Connection connection = new Connection(from, this, weight);
      inputs.Add(connection);
    }

    /// <summary>
    /// Calculate the result of this neuron based on the previous layer of neurons.
    /// </summary>
    public void Calculate() {
      double result = 0.0;
      foreach (Connection c in inputs) {
        result += c.from.Value * c.weight;
      }
      Value = ActivationFunction(result);
    }
  }
}
