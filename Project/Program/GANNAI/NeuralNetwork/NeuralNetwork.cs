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
    public void AddInput(InputNeuron neuron) {
      inputNeurons.Add(neuron);
    }
    //add hidden neuron
    public void AddHidden(Neuron neuron) {
      hiddenNeurons.Add(neuron);
    }
    //add output neuron
    public void AddOutput(Neuron neuron) {
      outputNeurons.Add(neuron);
    }

    //set input
    public void SetInput(double[] vals) {
      if (inputNeurons.Count != vals.Length)
        throw new Exception("Size of input doesn't match number of input neurons");
      for (int i = 0; i < vals.Length; i++)
        inputNeurons[i].SetValue(vals[i]);
    }

    //calc output
    public double[] GetOutput() {
      //calc value of hidden neurons
      for (int i = 0; i < hiddenNeurons.Count; i++)
        hiddenNeurons[i].Calculate();

      //calc value of output neurons
      double[] output = new double[outputNeurons.Count];
      for (int i = 0; i < OutputNeurons.Count; i++)
        output[i] = outputNeurons[i].NeuronValue;
      return output;
    }

  }
}

