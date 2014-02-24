using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
  public class NeuralNetwork {
    //list of neurons in network
    private List<InputNeuron> inputNeurons;
    private List<ChildNeuron> hiddenNeurons;
    private List<ChildNeuron> outputNeurons;

    public NeuralNetwork(int inp, int hdn, int oup) {
      InitiateNetwork(inp, hdn, oup);
      AddConnections();
    }

    public NeuralNetwork(int inp, int hdn, int oup, double[] weights) {
      InitiateNetwork(inp, hdn, oup);
      AddConnections(weights);
    }

    private void InitiateNetwork(int inp, int hdn, int oup){
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

      //add input neurons to network
      for(int i = 0; i < inp; i++)
        AddInput(new InputNeuron());
      //add hidden neurons to network
      for(int i = 0; i < hdn; i++)
        AddHidden(new ChildNeuron());
      //add output neurons to network
      for(int i = 0; i < oup; i++)
        AddOutput(new ChildNeuron());
    }

    private void AddConnections(){
      //connect network (input to hidden)
      for(int i = 0; i < hiddenNeurons.Count; i++) {
        for(int j = 0; j < inputNeurons.Count; j++) {
          hiddenNeurons[j].AddInputConnection(inputNeurons[i]);
        }
      }
      //connect network (hidden to output)
      for(int i = 0; i < outputNeurons.Count; i++) {
        for(int j = 0; j < hiddenNeurons.Count; j++) {
          outputNeurons[i].AddInputConnection(hiddenNeurons[j]);
        }
      }
    }

    private void AddConnections(double[] weights) {
      if(weights.Length != (inputNeurons.Count * hiddenNeurons.Count) 
        + (hiddenNeurons.Count * outputNeurons.Count))
        throw new Exception("Number of weights do not correspond to number of connections.");

      //connect network (input to hidden)
      int weightIndex = 0;
      for(int i = 0; i < hiddenNeurons.Count; i++) {
        for(int j = 0; j < inputNeurons.Count; j++) {
          hiddenNeurons[i].AddInputConnection(inputNeurons[j], weights[weightIndex++]);
        }
      }
      //connect network (hidden to output)
      for(int i = 0; i < outputNeurons.Count; i++) {
        for(int j = 0; j < hiddenNeurons.Count; j++) {
          outputNeurons[i].AddInputConnection(hiddenNeurons[j], weights[weightIndex++]);
        }
      }
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
      if(inputNeurons.Count != vals.Length)
        throw new Exception("Size of input doesn't match number of input neurons.");
      for(int i = 0; i < vals.Length; i++)
        inputNeurons[i].SetValue(vals[i]);
    }
    //calculate output
    public double[] GetOutput() {
      //calculate value of hidden neurons
      for(int i = 0; i < hiddenNeurons.Count; i++)
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

