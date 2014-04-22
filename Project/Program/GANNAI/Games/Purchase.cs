using System;
using Genetics;
using System.Collections.Generic;
using Datasets;
using System.Linq;

namespace Games {
  public class Purchase : AITrainableGame {
    PurchaseDataset purchase;
    
    public Purchase() : base() {
      this.purchase = new PurchaseDataset();
    }

    #region AITrainableGame implementation

    public double CalcFitness(AIPlayer aiplayer) {
      double fitness = 0.0;
      int numInputs = NumInputs();
      int numOutputs = NumOutputs();
      List<double> inputs;
      double[] allOutputs = new double[numOutputs];
      
      foreach(Line row in purchase.MappedDataSet) {
        inputs = new List<double>(numInputs);
        inputs.AddRange(row.entries.
          Where(e => purchase.InputIndicies().ToList().Contains(e.Column)).
          Select(e => e.Value));
        
        allOutputs = aiplayer.GetOutputs(inputs.ToArray());
        int[] outputs = new int[7];
        
        // A (0,1,2)
        outputs[0] = CheckArrayRange(Math.Max(Math.Max(allOutputs[0], 
          allOutputs[1]), allOutputs[2]), allOutputs, 0, 3, new int[]{ 0, 1, 2 });
        
        // B (0,1)
        outputs[1] = CheckArrayRange(Math.Max(allOutputs[3], 
          allOutputs[4]), allOutputs, 3, 5, new int[]{ 0, 1 });
        
        // C (1,2,3,4)
        outputs[2] = CheckArrayRange(Math.Max(Math.Max(allOutputs[5], allOutputs[6]), 
          Math.Max(allOutputs[7], allOutputs[8])), allOutputs, 5, 9, new int[] {
          1,
          2,
          3,
          4
        });
        
        // D (1,2,3)
        outputs[3] = CheckArrayRange(Math.Max(Math.Max(allOutputs[9], 
          allOutputs[10]), allOutputs[11]), allOutputs, 9, 12, new int[]{ 1, 2, 3 });
        
        // E (0,1)
        outputs[4] = CheckArrayRange(Math.Max(allOutputs[12], 
          allOutputs[13]), allOutputs, 12, 14, new int[]{ 0, 1 });
        
        // F (0,1,2,3)
        outputs[5] = CheckArrayRange(Math.Max(Math.Max(allOutputs[14], allOutputs[15]), 
          Math.Max(allOutputs[16], allOutputs[17])), allOutputs, 14, 18, new int[] {
          0,
          1,
          2,
          3
        });
        
        // G (1,2,3,4)
        outputs[6] = CheckArrayRange(Math.Max(Math.Max(allOutputs[18], allOutputs[19]), 
          Math.Max(allOutputs[20], allOutputs[21])), allOutputs, 18, 22, new int[] {
          1,
          2,
          3,
          4
        });
         
        //int sevenOutputsMustCorrespond = 0;
        for(int i = 14, j = 0; i < 21; i++, j++) {
          if(outputs[j] == row.entries[i].Value)
            fitness += 0.143;
          //  sevenOutputsMustCorrespond++;
          //else break;
          //if(sevenOutputsMustCorrespond == 7)
          //  fitness++;
        }
      }
      return fitness;
    }

    public int NumInputs() {
      return purchase.InputIndicies().Count();
    }

    public int NumOutputs() {
      return 22;
    }

    public int NumHidden() {
        return 10;
    }
    public int BitsPerWeight() {
        return 9;
    }

    public AITrainableGame GetNewGameInstance() {
      return this;
    }

    public void Visualize(AIPlayer aiplayer, System.Windows.Forms.Form form) {
      throw new NotImplementedException();
    }

    public string Name() {
      return "Purchase Classification";
    }

    #endregion
    
    private int CheckArrayRange(double prob, double[] all, int x, int y, int[] result) {
      for(int i = x, j = 0; i < y; i++, j++) {
        if(prob == all[i]) {
          return result[j];
        }
      }
      throw new Exception("WOOT!? Result was not expected.");
    }
  }
}

