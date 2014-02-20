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
    //private double neuronValue = null;

		//list of connections from this neuron
		private List<Connection> outputs = new List<Connection>();
		//list of connections to this neuron
		private List<Connection> inputs = new List<Connection>();

		//return input connections
		public List<Connection> getInputs { 
			get { return this.inputs; }
		}
		//return output connections
		public List<Connection> getOutputs { 
			get { return this.outputs; }
		}

		//add an incoming connection without specifying weight
		public void addInputConnection(Neuron from){
      double weight = Utility.randomDouble() - 0.5;
			addInputConnection(from, weight);
		}
    //overloaded
		//add an incoming connection with weight
		public void addInputConnection(Neuron from, double weight) {
			Connection connection = new Connection(from, this, weight);
			inputs.Add(connection);
		}

		//add an incoming connection from a given neuron with a given weight
		//sigmoid function as the activation function for neurons
		private double activationFunction(double sumInputs) {
			return 1.0 / (1.0 + Math.Exp(-(sumInputs)));
		}
		//calculate the value associated with a given neuron
		private double calculate() {
      //if (neuronValue != null)
      //  return neuronValue;

			double result = 0.0;
			foreach(Connection c in inputs) {
				result += c.from.calculate() * c.weight;
			}
      return activationFunction(result);
      //return neuronValue = activationFunction(result);
		}
	}
}

