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
        0 //The wine class
      };
    }

    public override int[] InputIndicies() {
      return new int[] {        
        1,  //Alcohol   
        2,  //Malic acid 
        3,  //Ash 
        4,  //Alcalinity of ash 
        5,  //Magnesium 
        6,  //Total phenols 
        7,  //Flavanoids 
        8,  //Nonflavanoid phenols 
        9,  //Proanthocyanins 
        10,  //Color intensity 
        11, //Hue 
        12, //OD280/OD315 of diluted wines 
        13  //Proline 
      };
    }

    protected override void CreateMappedDataset() {
      foreach(List<string> row in DataSet) {
        int columns = row.Count;
        
        Line data = new Line();
        MappedDataSet.Add(data);
        
        data.AddEntry(new LineEntry(row[0], Double.Parse(row[0]), 0));
        
        for(int i = 1; i < columns; i++) {
          if(i > columns - 1)
            throw new Exception("The column is out of bounds. "
              + "The wine dataset contains " + columns + " columns. "
              + "Tried to access the " + (i+1) + "th column!");
          else
            data.AddEntry(new LineEntry("column " + i, Double.Parse(row[i], CultureInfo.InvariantCulture), i));
        }
      }
    }

    #endregion
  }
}

