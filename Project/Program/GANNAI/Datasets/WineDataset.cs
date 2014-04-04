using System;
using System.Collections.Generic;
using System.Globalization;

namespace Datasets {
  public class WineDataset : Dataset {
    public WineDataset() : base() {
      string csv = Properties.Resources.wine;

      DataSet.AddRange(ParseDataFromString(csv));
      CreateMappedDataset();
    }

    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return new int[] {
        0 //Alcohol   
      };
    }

    public override int[] InputIndicies() {
      return new int[] {        
        1,  //Malic acid 
        2,  //Ash 
        3,  //Alcalinity of ash 
        4,  //Magnesium 
        5,  //Total phenols 
        6,  //Flavanoids 
        7,  //Nonflavanoid phenols 
        8,  //Proanthocyanins 
        9,  //Color intensity 
        10, //Hue 
        11, //OD280/OD315 of diluted wines 
        12, //Proline 
      };
    }

    protected override void CreateMappedDataset() {
      foreach(List<string> row in DataSet) {
        int columns = row.Count;
        
        Line data = new Line();
        MappedDataSet.Add(data);
        
        data.AddEntry(new LineEntry(row[0], Double.Parse(row[0]), 0));
        
        for(int i = 1; i < columns; i++) {
          if(i > 12)
            throw new Exception("The column is out of bounds. "
              + "The leaf dataset contains " + 13 + " columns. "
              + "Tried to access the " + (i+1) + "th column!");
          else
            data.AddEntry(new LineEntry("column " + i, Double.Parse(row[i], CultureInfo.InvariantCulture), i));
        }
      }
    }

    #endregion
  }
}

