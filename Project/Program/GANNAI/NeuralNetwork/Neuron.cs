using System;
using System.Text;
using System.Collections.Generic;
using GANNAI;

namespace ArtificialNeuralNetwork {
  public class Neuron {
    //to uniquely identify neurons
    private static int count = 0;
    private int id = count++;

    //neuron value
    public double NeuronValue { get; private set; }

    //list of connections from this neuron
    private List<Connection> outputs = new List<Connection>();
    //list of connections to this neuron
    private List<Connection> inputs = new List<Connection>();

    //return input connections
    public List<Connection> GetInputs {
      get { return this.inputs; }
    }
    //return output connections
    public List<Connection> GetOutputs {
      get { return this.outputs; }
    }

    //add an incoming connection without specifying weight
    public void AddInputConnection(Neuron from) {
      double weight = Utility.randomDouble() - 0.5;
      AddInputConnection(from, weight);
    }
    //overloaded
    //add an incoming connection with weight
    public void AddInputConnection(Neuron from, double weight) {
      Connection connection = new Connection(from, this, weight);
      inputs.Add(connection);
    }

    //add an incoming connection from a given neuron with a given weight
    //sigmoid function as the activation function for neurons
    private double ActivationFunction(double sumInputs) {
      return 1.0 / (1.0 + Math.Exp(-(sumInputs)));
    }
    //calculate the value associated with a given neuron
    public void Calculate() {
      double result = 0.0;
      foreach (Connection c in inputs) {
        result += c.from.NeuronValue * c.weight;
      }
      NeuronValue = ActivationFunction(result);
    }
  }
}

