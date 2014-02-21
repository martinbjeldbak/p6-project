using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
  public class NeuralNetwork {
    //list of neurons in network
    private List<InputNeuron> inputNeurons;
    private List<ChildNeuron> hiddenNeurons;
    private List<ChildNeuron> outputNeurons;

    public NeuralNetwork(int inp, int hdn, int oup, int l = 1){
      inputNeurons = new List<InputNeuron>();
      hiddenNeurons = new List<ChildNeuron>();
      outputNeurons = new List<ChildNeuron>();

      //validation
      if(inp < 0)
        throw new Exception("Must have at least one input neuron!" 
          + inp + " input neurons where given.");
      if(hdn < 0)
        throw new Exception("Must have at least one hidden neuron!" 
          + hdn + " hidden neurons where given.");
      if(oup < 0)
        throw new Exception("Must have at least one output neuron!" 
          + oup + " output neurons where given.");
      if(l < 1)
        throw new Exception("Incorrect number of layers. Must be greater than zero!" 
          + l + " layers where given.");

      //add input neurons to network
      for(int i = 0; i < inp; i++)
        AddInput(new InputNeuron());

      //add hidden neurons to network
      //take layers (l) into account
      if(l == 1) {
        for(int i = 0; i < hdn; i++)
          AddHidden(new ChildNeuron());
      }
      else {
        //TODO: How to we handle multiple layers?
        for(int j = 0; j < l; j++) {
          for(int i = 0; i < hdn; i++)
            AddOutput(new ChildNeuron());
        }
      }

      //add output neurons to network
      for(int i = 0; i < oup; i++)
          AddOutput(new ChildNeuron());
    }

    //add input neuron
    public void AddInput(InputNeuron neuron) {
      inputNeurons.Add(neuron);
    }
    //add hidden neuron
    public void AddHidden(ChildNeuron neuron) {
      hiddenNeurons.Add(neuron);
    }
    //add output neuron
    public void AddOutput(ChildNeuron neuron) {
      outputNeurons.Add(neuron);
    }

    //set input
    public void SetInput(double[] vals) {
      if (inputNeurons.Count != vals.Length)
        throw new Exception("Size of input doesn't match number of input neurons.");
      for (int i = 0; i < vals.Length; i++)
        inputNeurons[i].SetValue(vals[i]);
    }

    //calculate output
    public double[] GetOutput() {
      //calculate value of hidden neurons
      for (int i = 0; i < hiddenNeurons.Count; i++)
        hiddenNeurons[i].Calculate();

      //calculate value of output neurons
      double[] output = new double[outputNeurons.Count];
      for(int i = 0; i < outputNeurons.Count; i++) {
        outputNeurons[i].Calculate();
        output[i] = outputNeurons[i].Value;
      }
      return output;
    }

  }
}

