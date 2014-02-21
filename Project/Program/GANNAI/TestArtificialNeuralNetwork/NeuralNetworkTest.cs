using NUnit.Framework;
using System;
using ArtificialNeuralNetwork;

namespace GANNAINTests {
  [TestFixture()]
  public class ArtificialNeuralNetworkTest {
    [Test()]
    public void BasicStructureTest() {
      NeuralNetwork nn = new NeuralNetwork(1, 2, 2);
      Assert.AreEqual(1, nn.InputNeurons.Count);
      Assert.AreEqual(2, nn.HiddenNeurons.Count);
      Assert.AreEqual(2, nn.OutputNeurons.Count);

      NeuralNetwork nn1 = new NeuralNetwork(100, 200, 200);
      Assert.AreEqual(100, nn1.InputNeurons.Count);
      Assert.AreEqual(200, nn1.HiddenNeurons.Count);
      Assert.AreEqual(200, nn1.OutputNeurons.Count);
    }

    [Test()]
    public void InputTest() {
      NeuralNetwork nn = new NeuralNetwork(2, 3, 2);
      double[] v = { 0.0, 0.1 };

      nn.SetInput(v);
      nn.GetOutput();

      for(int i = 0; i < v.Length; i++) {
        Assert.AreEqual(v[i], nn.InputNeurons[i].Value, 0.0);
      }
    }

    [Test()]
    public void CalculationTest() {
      NeuralNetwork nn = new NeuralNetwork(2, 3, 2);
      double[] v = {0.2, 0.2};
      nn.SetInput(v); 

      for(int i = 0; i < nn.HiddenNeurons.Count; i++)
        for(int j = 0; j < nn.InputNeurons.Count; j++)
          nn.HiddenNeurons[i].AddInputConnection(nn.InputNeurons[j], 1.0);       
      for(int i = 0; i < nn.OutputNeurons.Count; i++)
        for(int j = 0; j < nn.HiddenNeurons.Count; j++)
          nn.OutputNeurons[i].AddInputConnection(nn.HiddenNeurons[j], 1.0);
      //first hidden values then output values
      double resultHidden = 1 / (1 + Math.Exp(-(0.2 * 1.0 + 0.2 * 1.0)));
      double resultOutput = 1 / (1 + Math.Exp(-(resultHidden * 1.0 + resultHidden * 1.0 + resultHidden * 1.0)));

      nn.GetOutput();

      for(int i = 0; i < nn.InputNeurons.Count; i++)
        Assert.AreEqual(v[i], nn.InputNeurons[i].Value, 0.0);

      for(int i = 0; i < nn.HiddenNeurons.Count; i++)
        Assert.AreEqual(resultHidden, nn.HiddenNeurons[i].Value, 0.0);

      for(int i = 0; i < nn.OutputNeurons.Count; i++)
        Assert.AreEqual(resultOutput, nn.OutputNeurons[i].Value, 0.0);

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

