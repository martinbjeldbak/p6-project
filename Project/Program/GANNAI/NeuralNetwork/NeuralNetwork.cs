using System;
using System.Text;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork {
    /// <summary>
    /// Neural network.
    /// </summary>
    public class NeuralNetwork {
        /// <summary>
        /// The input neurons.
        /// </summary>
        private List<InputNeuron> inputNeurons;
        /// <summary>
        /// The hidden neurons.
        /// </summary>
        private List<ChildNeuron> hiddenNeurons;
        /// <summary>
        /// The output neurons.
        /// </summary>
        private List<ChildNeuron> outputNeurons;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="ArtificialNeuralNetwork.NeuralNetwork"/> class.
        /// </summary><param name="inp">Number of input neurons to be built.</param>
        /// <param name="hdn">Number of hidden neurons to be built.</param>
        /// <param name="oup">Number of output neurons to be built.</param>
        public NeuralNetwork(int inp, int hdn, int oup) {
            InitiateNetwork(inp, hdn, oup);
            AddConnections();
        }

        public NeuralNetwork(int inp, int hdn, int oup, double[] weights, double[] thresholds) {
            if(thresholds.Length != hdn + oup)
                throw new Exception("The amount of thresholds (" + thresholds.Length + ") needs to equal " + hdn + oup);
                
            InitiateNetwork(inp, hdn, oup, thresholds);
            AddConnections(weights);
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="ArtificialNeuralNetwork.NeuralNetwork"/> class.
        /// </summary>
        /// <param name="inp">Number of input neurons to be built.</param>
        /// <param name="hdn">Number of hidden neurons to be built.</param>
        /// <param name="oup">Number of output neurons to be built.</param>
        /// <param name="weights">Weights to be distributed in the network.</param>
        public NeuralNetwork(int inp, int hdn, int oup, double[] weights) {
            InitiateNetwork(inp, hdn, oup);
            AddConnections(weights);
        }

        /// <summary>
        /// Initiates the network. No connections added yet.
        /// </summary>
        /// <param name="inp">Number of input neurons to be built.</param>
        /// <param name="hdn">Number of hidden neurons to be built.</param>
        /// <param name="oup">Number of output neurons to be built.</param>
        private void InitiateNetwork(int inp, int hdn, int oup, double[] thresholds = null) {
            if(thresholds == null)
                thresholds = new double[hdn + oup];

            inputNeurons = new List<InputNeuron>();
            hiddenNeurons = new List<ChildNeuron>();
            outputNeurons = new List<ChildNeuron>();

            if(inp < 0)
                throw new Exception("Must have at least one input neuron!"
                + inp + " input neurons were given.");
            if(hdn < 0)
                throw new Exception("Must have at least one hidden neuron!"
                + hdn + " hidden neurons were given.");
            if(oup < 0)
                throw new Exception("Must have at least one output neuron!"
                + oup + " output neurons were given.");

            for(int i = 0; i < inp; i++)
                AddInput(new InputNeuron());
            for(int i = 0; i < hdn; i++)
                AddHidden(new ChildNeuron(thresholds[i]));
            for(int i = 0; i < oup; i++)
                AddOutput(new ChildNeuron(thresholds[hdn - 1 + i]));
        }

        /// <summary>
        /// Adds the connections in the network.
        /// Begins with input neurons, then hidden and finally output neurons.
        /// Weights are distributed in that order.
        /// </summary>
        /// <param name="weights">Weights to be distributed in the network.
        /// Default is null, which leads to random values.</param>
        private void AddConnections(double[] weights = null) {
            if(weights == null) {
                for(int i = 0; i < hiddenNeurons.Count; i++) {
                    for(int j = 0; j < inputNeurons.Count; j++) {
                        hiddenNeurons[j].AddInputConnection(inputNeurons[i]);
                    }
                }
                for(int i = 0; i < outputNeurons.Count; i++) {
                    for(int j = 0; j < hiddenNeurons.Count; j++) {
                        outputNeurons[i].AddInputConnection(hiddenNeurons[j]);
                    }
                }
            }
            else {
                if(weights.Length != (inputNeurons.Count * hiddenNeurons.Count)
                + (hiddenNeurons.Count * outputNeurons.Count))
                    throw new Exception("Number of weights do not correspond to number of connections.");

                int weightIndex = 0;
                for(int i = 0; i < hiddenNeurons.Count; i++) {
                    for(int j = 0; j < inputNeurons.Count; j++) {
                        hiddenNeurons[i].AddInputConnection(inputNeurons[j], weights[weightIndex++]);
                    }
                }
                for(int i = 0; i < outputNeurons.Count; i++) {
                    for(int j = 0; j < hiddenNeurons.Count; j++) {
                        outputNeurons[i].AddInputConnection(hiddenNeurons[j], weights[weightIndex++]);
                    }
                }
            }
        }

        /// <summary>
        /// Adds an input neuron.
        /// </summary>
        /// <param name="neuron">Input neuron.</param>
        public void AddInput(InputNeuron neuron) {
            inputNeurons.Add(neuron);
        }

        /// <summary>
        /// Adds a hidden neuron.
        /// </summary>
        /// <param name="neuron">Output neuron.</param>
        public void AddHidden(ChildNeuron neuron) {
            hiddenNeurons.Add(neuron);
        }

        /// <summary>
        /// Adds an output neuron.
        /// </summary>
        /// <param name="neuron">Output neuron.</param>
        public void AddOutput(ChildNeuron neuron) {
            outputNeurons.Add(neuron);
        }

        /// <summary>
        /// Sets the input vector.
        /// </summary>
        /// <param name="vals">The input vector.</param>
        public void SetInput(double[] vals) {
            if(inputNeurons.Count != vals.Length)
                throw new Exception("Size of input doesn't match number of input neurons."
                + "Excepted " + inputNeurons.Count + " inputs, but got " + vals.Length + "."
                );
            for(int i = 0; i < vals.Length; i++)
                inputNeurons[i].SetValue(vals[i]);
        }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <returns>The output as an array.</returns>
        public double[] GetOutput() {
            for(int i = 0; i < hiddenNeurons.Count; i++)
                hiddenNeurons[i].Calculate();
        
            double[] outputs = new double[outputNeurons.Count];
            for(int i = 0; i < outputNeurons.Count; i++) {
                outputNeurons[i].Calculate();
                outputs[i] = outputNeurons[i].Value;
            }
            return outputs;
        }

        public int GetNumberOfOutputs() {
            return outputNeurons.Count;
        }

        public int GetNumberOfInputs() {
            return inputNeurons.Count;
        }

        public bool[] GetOutputBinary() {
            for(int i = 0; i < hiddenNeurons.Count; i++)
                hiddenNeurons[i].Calculate();

            bool[] outputs = new bool[outputNeurons.Count];
            for(int i = 0; i < outputNeurons.Count; i++) {
                outputNeurons[i].Calculate();
                outputs[i] = outputNeurons[i].Value >= 0.5;
            }
            return outputs;
        }

        /// <summary>
        /// Sets the input vector using a binary format
        /// </summary>
        /// <param name="inputs"></param>
        public void SetInputBinary(bool[] inputs) {
            if(inputNeurons.Count != inputs.Length)
                throw new Exception("Size of input doesn't match number of input neurons."
                + "Excepted " + inputNeurons.Count + " inputs, but got " + inputs.Length + "."
                );
            for(int i = 0; i < inputs.Length; i++)
                inputNeurons[i].SetValue(inputs[i] ? 1 : 0);
        }
    }
}

