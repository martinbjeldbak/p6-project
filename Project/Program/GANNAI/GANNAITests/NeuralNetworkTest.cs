using NUnit.Framework;
using System;
using ArtificialNeuralNetwork;

namespace GANNAITests {
  [TestFixture()]
  public class ArtificialNeuralNetworkTest {
    [Test()]
    public void CalculationTest() {
      double[] weights = new double[(2 * 3) + (3 * 2)];
      for(int i = 0; i < (2 * 3) + (3 * 2); i++)
        weights[i] = 1.0;

      NeuralNetwork nn = new NeuralNetwork(2, 3, 2, weights);

      //first test
      double[] inputVector = { 0.2, 0.2 };
      nn.SetInput(inputVector);
      
      //first hidden values then output value
      double result = 1 / (1 + Math.Exp(-(0.2 * 1.0 + 0.2 * 1.0)));
      result = 1 / (1 + Math.Exp(-(result * 1.0 + result * 1.0 + result * 1.0)));

      double[] outputVector = nn.GetOutput();

      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //second test
      inputVector[0] = 0.1; 
      inputVector[1] = 0.4;
      nn.SetInput(inputVector);

      result = 1 / (1 + Math.Exp(-(0.1 * 1.0 + 0.4 * 1.0)));
      result = 1 / (1 + Math.Exp(-(result * 1.0 + result * 1.0 + result * 1.0)));

      outputVector = nn.GetOutput();
      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //third test
      for(int i = 0; i < (2 * 3) + (3 * 2); i++)
        weights[i] = 0.0;
      NeuralNetwork nn2 = new NeuralNetwork(2, 3, 2, weights);
      inputVector[0] = 0.1;
      inputVector[1] = 0.4;
      nn2.SetInput(inputVector);

      result = 1 / (1 + Math.Exp(-(0.1 * 0.0 + 0.4 * 0.0)));
      result = 1 / (1 + Math.Exp(-(result * 0.0 + result * 0.0 + result * 0.0)));

      outputVector = nn2.GetOutput();
      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      //fourth test
      weights[0] = 0.1;
      for(int i = 1; i < (2 * 3) + (3 * 2); i++)
        weights[i] = weights[i - 1] + 0.2;
      NeuralNetwork nn3 = new NeuralNetwork(2, 3, 2, weights);
      inputVector[0] = 0.3;
      inputVector[1] = 0.6;
      nn3.SetInput(inputVector);

      result = 1 / (1 + Math.Exp(-(0.3 * 0.0 + 0.6 * 0.0)));
      result = 1 / (1 + Math.Exp(-(result * 0.0 + result * 0.0 + result * 0.0)));

      outputVector = nn3.GetOutput();
      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      double[] inp_hdn_result = new double[3];
      for(int i = 0, k = 0; i < inp_hdn_result.Length; i++)
        inp_hdn_result[i] = 1 / (1 + Math.Exp(-(inputVector[0] * weights[k++]
        + inputVector[1] * weights[k++])));
          
      double[] hdn_oup_result = new double[2];
      for(int i = 0, k = 0; i < hdn_oup_result.Length; i++)
        hdn_oup_result[i] = 1 / (1 + Math.Exp(-(inp_hdn_result[0] * weights[k++]
        + inp_hdn_result[1] * weights[k++] + inp_hdn_result[2] * weights[k++])));

      outputVector = nn3.GetOutput();
      for(int i = 0; i < hdn_oup_result.Length; i++)
        Assert.AreEqual(hdn_oup_result[i], outputVector[i], 0.0);

    }
  }
}
