using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
	public class InputNeuron : Neuron {
    //list of connections from this neuron
    //input neurons only have outgoing connections
    private List<Connection> outputs = new List<Connection>();

    //neuron value
    public double Value { get; private set; }
    //set the input value
    public void SetValue(double value){
      this.Value = value;
    }
    //return the input value
    public double Calculate(){
      return Value;
    }
	}
}

