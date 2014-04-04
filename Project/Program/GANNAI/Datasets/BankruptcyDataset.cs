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
        
        data.AddEntry(new LineEntry(row[0], Double.Parse(row[0]), 0));
        
        for(int i = 0; i < columns; i++) {
          if(i > 5)
            throw new Exception("The column is out of bounds. "
            + "The bankruptcy dataset contains " + 6 + " input columns. "
            + "Tried to access the " + i + "th column!");
          else
            data.AddEntry(new LineEntry("column " + i, Double.Parse(row[i], CultureInfo.InvariantCulture), i));
        }
      }
    }

    #endregion
  }
}
