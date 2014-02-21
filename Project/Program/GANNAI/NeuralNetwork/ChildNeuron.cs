using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GANNAI;

namespace ArtificialNeuralNetwork {
  public class ChildNeuron : Neuron{

    //add an incoming connection from a given neuron with a given weight
    //sigmoid function as the activation function for neurons
    private double ActivationFunction(double sumInputs) {
      return 1.0 / (1.0 + Math.Exp(-(sumInputs)));
    }

    //list of connections to this neuron
    protected List<Connection> inputs = new List<Connection>();

    //return input connections
    public List<Connection> GetInputs {
      get { return inputs; }
    }


    //add an incoming connection without specifying weight
    public void AddInputConnection(Neuron from) {
      double weight = Utility.RandomDouble() - 0.5;
      AddInputConnection(from, weight);
    }

    //add an incoming connection with weight
    public void AddInputConnection(Neuron from, double weight) {
      Connection connection = new Connection(from, this, weight);
      inputs.Add(connection);
    }

    //calculate the value associated with a given neuron
    public virtual void Calculate() {
      double result = 0.0;
      foreach (Connection c in inputs) {
        result += c.from.Value * c.weight;
      }
      Value = ActivationFunction(result);
    }
  }
}
