using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
	public class Connection {
		//the sending neuron of the connection
		public Neuron from;
		//the recieving neuron of the connection
		public Neuron to;
		//the weight of the connection
		public double weight;
		//constructor for class
		public Connection(Neuron from, Neuron to, double weight) {
			this.from = from;
			this.to = to;
			this.weight = weight;
		}
	}
}