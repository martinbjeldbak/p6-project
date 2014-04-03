using System;

namespace Datasets {
  public class LeafDataset : Dataset {
    public LeafDataset() {
    }

    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return new int[] { 
        0 //The class of the specimen 
      }; 
    }

    public override int[] InputIndicies() {
      return new int[] { 
        2,  //Eccentricity
        3,  //Aspect ratio
        4,  //Elongation
        5,  //Solidity
        6,  //Stochastic Convexity
        7,  //Isoperimetric Factor
        8,  //Maximal Indentation Depth
        9,  //Lobedness
        10, //Average Intensity
        11, //Average Contrast
        12, //Smoothness
        13, //Third moment
        14, //Uniformity
        15  //Entropy
      }; 
    }

    protected override void CreateMappedDataset() {
      throw new NotImplementedException();
    }

    #endregion
  }
}

