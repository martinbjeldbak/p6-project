using System;
using System.Text;
using System.Collections.Generic;

namespace NeuralNetwork
{
	public class Neuron
	{
		//to uniquely identify neurons
		private static int count = 0;
		private int id = count++;

		//list of connections from this neuron
		private List<Connection> outputs = new List<Connection>();
		//list of connections to this neuron
		private List<Connection> inputs = new List<Connection>();

		//sigmoid function as the activation function for neurons
		private double activationFunction(double sumInputs){
			return 1.0 / (1.0 + Math.Exp(-(sumInputs)));
		}

		public Neuron ()
		{
		}
	}
}

