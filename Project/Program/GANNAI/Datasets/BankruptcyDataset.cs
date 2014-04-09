using System;
using System.Collections.Generic;
using System.Globalization;

namespace Datasets {
  public class BankruptcyDataset : Dataset {
    public BankruptcyDataset(double validationPercent = 0.0) : base(validationPercent) {
      string csv = Properties.Resources.bankruptcy;

      DataSet.AddRange(ParseDataFromString(csv));
      CreateMappedDataset();
    }

    private double InputMap(string c){
      string negative = "N";
      string average = "A";
      string positive = "P";
      double neg = 0.1;
      double avg = 0.5;
      double pos = 1.0;
      string C = c.Trim();

      if(String.Equals(C, negative))
        return neg;
      else if(String.Equals(C, average))
        return avg;
      else if(String.Equals(C, positive))
        return pos;
      else
        throw new Exception(String.Format("Unexpected value for output column. "
          + "Expected either {0}, {1}, or {2} but got {3}..."
          , negative, average, positive, C));
    }
    
    private double OutputMap(string c){
      string NB = "NB";
      string B = "B";
      double nb = 0.0;
      double b = 1.0;
      string C = c.Trim();

      if(String.Equals(C, NB))
        return nb;
      else if(String.Equals(C, B))
        return b;
      else
        throw new Exception(String.Format("Unexpected value for input column. "
          + "Expected either {0} or {1} but got {2}..."
          , NB, B, C));
    }

    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return new int[]{
        6 //bankcrupt or not  (B, NB)
      };
    }

    public override int[] InputIndicies() {
      return new int[] {
        0, //Industrial risk (positive, average, negative)
        1, //Management risk
        2, //Financial flexibility
        3, //Credibility
        4, //Competitiveness
        5  //Operating risk
      };
    }

    protected override void CreateMappedDataset() {
      foreach(List<string> row in DataSet) {
        int columns = row.Count;
        
        Line data = new Line();
        MappedDataSet.Add(data);
        
        for(int i = 0; i < columns - 1; i++) {
          if(i > 5)
            throw new Exception("The column is out of bounds. "
            + "The bankruptcy dataset contains 5 input columns. "
            + "Tried to access the " + i + "th column!");
          else
            data.AddEntry(new LineEntry("column " + i, InputMap(row[i]), i));
        }
        
        data.AddEntry(new LineEntry(row[6], OutputMap(row[6]), 6));
      }
    }

    #endregion
  }
}
