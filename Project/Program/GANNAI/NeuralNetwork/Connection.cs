using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
  /// <summary>
  /// Connections between neurons.
  /// </summary>
	public class Connection {
    /// <summary>
    /// The sending neuron
    /// </summary>
		public Neuron from;
    /// <summary>
    /// The recieving neuron.
    /// </summary>
		public Neuron to;
    /// <summary>
    /// The weight of the connection.
    /// </summary>
		public double weight;

    /// <summary>
    /// Initializes a new instance of the 
    /// <see cref="ArtificialNeuralNetwork.Connection"/> class.
    /// </summary>
    /// <param name="from">The sending neuron.</param>
    /// <param name="to">The recieving neuron.</param>
    /// <param name="weight">The weight of the connection.</param>
		public Connection(Neuron from, Neuron to, double weight) {
			this.from = from;
			this.to = to;
			this.weight = weight;
		}
	}
}