using NUnit.Framework;
using System;
using ArtificialNeuralNetwork;

namespace GANNAINTests {
  [TestFixture()]
  public class ArtificialNeuralNetworkTest {

    [Test()]
    public void CalculationTest() {
      double[] weights = new double[(2*3)+(3*2)];
      for(int i = 0; i < (2*3)+(3*2); i++)
        weights[i] = 1.0;

      NeuralNetwork nn = new NeuralNetwork(2, 3, 2, weights);

      double[] inputVector = {0.2, 0.2};
      nn.SetInput(inputVector);
      
      //first hidden values then output values
      double result = 1 / (1 + Math.Exp(-(0.2 * 1.0 + 0.2 * 1.0)));
      result = 1 / (1 + Math.Exp(-(result * 1.0 + result * 1.0 + result * 1.0)));

      double[] outputVector = nn.GetOutput();
      Assert.AreEqual(2, outputVector.Length);

      for(int i = 0; i < 2; i++)
        Assert.AreEqual(result, outputVector[i], 0.0);

      /*
      nn.setInputVector(0.1, 0.4);

      cRes = 1 / (1 + Math.exp(-(0.1 * 1.0 + 0.4 * 1.0)));
      cRes = 1 / (1 + Math.exp(-(cRes * 1.0 + cRes * 1.0 + cRes * 1.0)));
      outputVector = nn.calculate();
      for(int i = 0; i < nn.getOutputNeurons().size(); i++){
        assertEquals(cRes, outputVector[i], 0.0);
      }

      NeuralNetwork nn2 = buildNetwork();
      nn2.setInputVector(0.1, 0.4);
      nn2 = addAllInput(nn2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

      cRes = 1 / (1 + Math.exp(-(0.1 * 0.0 + 0.4 * 0.0))); 
      cRes = 1 / (1 + Math.exp(-(cRes * 0.0 + cRes * 0.0 + cRes * 0.0)));
      outputVector = nn2.calculate();
      for(int i = 0; i < nn2.getOutputNeurons().size(); i++){
        assertEquals(cRes, outputVector[i], 0.0);
      }

      NeuralNetwork nn3 = buildNetwork();
      nn3.setInputVector(0.3, 0.6);
      double[] hw = {.1, .3, .4, .5, .6, .7};
      nn3 = addAllInput(nn3, hw);

      int k = 0;
      double[] newRes = new double[nn3.getHiddenNeurons().size()]; 
      for(int i = 0; i < nn3.getHiddenNeurons().size(); i++){
        newRes[i] = 1 / (1 + Math.exp(-(.3 * hw[k++] + .6 * hw[k++])));
      }
      k = 0;
      double[] tempRes = {newRes[0], newRes[1], newRes[2]};
      for(int i = 0; i < nn3.getOutputNeurons().size(); i++){
        newRes[i] = 1 / (1 + Math.exp(-(tempRes[0] * hw[k++] + tempRes[1] * hw[k++] + tempRes[2] * hw[k++])));
      }

      outputVector = nn3.calculate();
      for(int i = 0; i < nn3.getOutputNeurons().size(); i++){
        assertEquals(newRes[i], outputVector[i], 0.0);
      }
      */
    }
  }
}

