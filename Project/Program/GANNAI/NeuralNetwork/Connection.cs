using System;
using System.Text;
using System.Collections.Generic;

namespace NeuralNetwork
{
	public class Connection
	{
		//the sending neuron of the incoming connection
		private Neuron from;
		//the recieving neuron of the incoming connection
		private Neuron to;
		//the weight of the connection
		private double weight;

		//constructor for class
		public Connection (Neuron from, Neuron to, double weight)
		{
			this.from = from;
			this.to = to;
			this.weight = weight;
		}
	}
}