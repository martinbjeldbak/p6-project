using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
  public class NeuralNetwork {
    //list of neurons in network
    private List<InputNeuron> inputNeurons = new List<InputNeuron>();
    private List<Neuron> hiddenNeurons = new List<Neuron>();
    private List<Neuron> outputNeurons = new List<Neuron>();
    // getters
    public List<InputNeuron> InputNeurons {
      get { return inputNeurons; }
    }
    public List<Neuron> HiddenNeurons {
      get { return hiddenNeurons; }
    }
    public List<Neuron> OutputNeurons {
      get { return outputNeurons; }
    }

    //add input neuron
    public void addInput(InputNeuron neuron){
      inputNeurons.Add(neuron);
    }
    //add hidden neuron
    public void addHidden(Neuron neuron){
      hiddenNeurons.Add(neuron);
    }
    //add output neuron
    public void addOutput(Neuron neuron){
      outputNeurons.Add(neuron);
    }

    /////////////////////////
    /// SET INPUT VECTOR? ///
    /////////////////////////

  }
}

