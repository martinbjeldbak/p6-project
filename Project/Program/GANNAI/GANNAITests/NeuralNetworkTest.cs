using NUnit.Framework;
using System;
using ArtificialNeuralNetwork;
using Genetics;
using System.Windows.Forms;
using GANNAI;

namespace GANNAITests {
  [TestFixture()]
  public class ArtificialNeuralNetworkTest {

    [Test()]
    public void TestOutputOnDNA() {
      Configuration.Game = new GameWith7Inputs8Outputs();

      NNMaker nnMaker = new SimpleNNMaker(10, 10);
      DNA dna = new DNA(nnMaker.DNALength());
      NeuralNetwork neuralNetwork = nnMaker.MakeNeuralNetwork(dna);

      double[] input = new double[7];
      double[] lastInput = new double[7];
      double[] output;
      double[] lastOutput = new double[0];

      for (int p = 0; p < 7; p++) {
        input[p] = Utility.RandomDouble() * 100.0 - 50.0;
        lastInput[p] = input[p];
      }
      for (int i = 0; i < 10; i++) {
        neuralNetwork.SetInput(input);
        output = neuralNetwork.GetOutput();
        if (lastOutput.Length != 0) {
          for (int s = 0; s < 8; s++)
            Assert.AreEqual(output[s], lastOutput[s]);
        }
        lastOutput = output;
        if (lastInput.Length != 0) {
          for (int s = 0; s < 7; s++)
            Assert.AreEqual(input[s], lastInput[s]);
        }
        lastInput = input;
      }
    }

    [Test()]
    public void TestMultipleRuns() {

      //FIRST TEST
      double[] weights = new double[(2 * 3) + (3 * 2)];
      for (int i = 0; i < (2 * 3) + (3 * 2); i++)
        weights[i] = 1.0;
      NeuralNetwork nn = new NeuralNetwork(2, 3, 2, weights);
      double[] inputVector = { 0.2, 0.2 };
      nn.SetInput(inputVector);

      //EXPECTED OUTPUT
      double result = 1 / (1 + Math.Exp(-(0.2 * 1.0 + 0.2 * 1.0)));
      result = 1 / (1 + Math.Exp(-(result * 1.0 + result * 1.0 + result * 1.0)));

      //ACTUAL OUTPUT
      double[] outputVector = nn.GetOutput();
      for (int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //Check output again
      nn.SetInput(inputVector);
      outputVector = nn.GetOutput();
      for (int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);
    }


    [Test()]
    public void CalculationTest() {
      //FIRST TEST
      double[] weights = new double[(2 * 3) + (3 * 2)];
      for(int i = 0; i < (2 * 3) + (3 * 2); i++)
        weights[i] = 1.0;
      NeuralNetwork nn = new NeuralNetwork(2, 3, 2, weights);
      double[] inputVector = { 0.2, 0.2 };
      nn.SetInput(inputVector);

      //EXPECTED OUTPUT
      double result = 1 / (1 + Math.Exp(-(0.2 * 1.0 + 0.2 * 1.0)));
      result = 1 / (1 + Math.Exp(-(result * 1.0 + result * 1.0 + result * 1.0)));

      //ACTUAL OUTPUT
      double[] outputVector = nn.GetOutput();
      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //SECOND TEST
      inputVector[0] = 0.1; 
      inputVector[1] = 0.4;
      nn.SetInput(inputVector);

      //EXPECTED OUTPUT
      result = 1 / (1 + Math.Exp(-(0.1 * 1.0 + 0.4 * 1.0)));
      result = 1 / (1 + Math.Exp(-(result * 1.0 + result * 1.0 + result * 1.0)));

      //ACTUAL OUTPUT
      outputVector = nn.GetOutput();
      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //THIRD TEST
      for(int i = 0; i < (2 * 3) + (3 * 2); i++)
        weights[i] = 0.0;
      NeuralNetwork nn2 = new NeuralNetwork(2, 3, 2, weights);
      inputVector[0] = 0.1;
      inputVector[1] = 0.4;
      nn2.SetInput(inputVector);

      //EXPECTED OUTPUT
      result = 1 / (1 + Math.Exp(-(0.1 * 0.0 + 0.4 * 0.0)));
      result = 1 / (1 + Math.Exp(-(result * 0.0 + result * 0.0 + result * 0.0)));

      //ACTUAL OUTPUT
      outputVector = nn2.GetOutput();
      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //FOURTH TEST
      weights[0] = 0.1;
      for(int i = 1; i < (2 * 3) + (3 * 2); i++)
        weights[i] = weights[i - 1] + 0.2;
      NeuralNetwork nn3 = new NeuralNetwork(2, 3, 2, weights);
      inputVector[0] = 0.3;
      inputVector[1] = 0.6;
      nn3.SetInput(inputVector);

      //EXPECTED OUTPUT
      int k = 0;
      double[] inp_hdn_result = new double[3];
      for(int i = 0; i < inp_hdn_result.Length; i++)
        inp_hdn_result[i] = 1 / (1 + Math.Exp(-(inputVector[0] * weights[k++]
        + inputVector[1] * weights[k++])));
          
      double[] hdn_oup_result = new double[2];
      for(int i = 0; i < hdn_oup_result.Length; i++)
        hdn_oup_result[i] = 1 / (1 + Math.Exp(-(inp_hdn_result[0] * weights[k++]
        + inp_hdn_result[1] * weights[k++] + inp_hdn_result[2] * weights[k++])));

      //ACTUAL OUTPUT
      outputVector = nn3.GetOutput();
      for(int i = 0; i < hdn_oup_result.Length; i++)
        Assert.AreEqual(hdn_oup_result[i], outputVector[i], 0.0);
    }
  }

  class GameWith7Inputs8Outputs : AITrainableGame {

    public double CalcFitness(AIPlayer aiplayer) {
      throw new NotImplementedException();
    }

    public int NumInputs() {
      return 7;
    }

    public int NumOutputs() {
      return 8;
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }


    public AITrainableGame GetNewGameInstance() {
      throw new NotImplementedException();
    }
  }

}
