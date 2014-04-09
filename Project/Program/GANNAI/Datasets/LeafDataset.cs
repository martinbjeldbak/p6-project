using System;
using System.Collections.Generic;
using System.Globalization;

namespace Datasets {
  public class LeafDataset : Dataset {
    public LeafDataset(double validationPercent = 0.0) : base(validationPercent) {
        string csv = Properties.Resources.leaf;

        DataSet.AddRange(ParseDataFromString(csv));
        CreateMappedDataset();
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
      foreach(List<string> row in DataSet) {
        int columns = row.Count;
        
        Line data = new Line();
        MappedDataSet.Add(data);
        
        data.AddEntry(new LineEntry(row[0], Double.Parse(row[0]), 0));
        
        for(int i = 2; i < columns; i++) {
          if(i > 15)
            throw new Exception("The column is out of bounds. "
              + "The leaf dataset contains 15 input columns. "
              + "Tried to access the " + i + "th column!");
          else
            data.AddEntry(new LineEntry("column " + i, Double.Parse(row[i], CultureInfo.InvariantCulture), i));
        }
      }
    }

    #endregion
  }
}

