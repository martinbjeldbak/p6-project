using NUnit.Framework;
using System;
using ArtificialNeuralNetwork;

namespace GANNAITests {
  [TestFixture()]
  public class ArtificialNeuralNetworkTest {
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
}
