using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
	public class InputNeuron : Neuron {
    //list of connections from this neuron
    //input neurons only have outgoing connections
    private List<Connection> outputs = new List<Connection>();

    //the value of the input
    private double value;
    //set the input value
    public void setValue(double value){
      this.value = value;
    }
    //return the input value
    public double calculate(){
      return value;
    }
	}
}

