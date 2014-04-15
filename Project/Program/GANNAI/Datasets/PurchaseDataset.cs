using System;
using System.Collections.Generic;
using System.Globalization;

namespace Datasets {
  public class PurchaseDataset : Dataset {
    static List<string> states = new List<string>();
    static List<string> carValue = new List<string>();
    
    public PurchaseDataset() {
      string csv = Properties.Resources.purchase;

      DataSet.AddRange(ParseDataFromString(csv));
      System.Console.WriteLine("Dataset: " + DataSet.Count);
      
      CreateMappedDataset();
      
    }
    
    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return new int[]{
        17, // A (0,1,2)
        18, // B (0,1)
        19, // C (1,2,3,4)
        20, // D (1,2,3)
        21, // E (0,1)
        22, // F (0,1,2,3)
        23  // G (1,2,3,4)
      };
    }

    public override int[] InputIndicies() {
      return new int[]{
        //0, // customer_id
        //1, // shopping_pt
        //2, // record_type
        3, // day
        4, // time
        5, // state
        //6, // location
        7, // group_size
        8, // homeowner
        9, // car_age
        10,// car_value
        11,// risk_factor
        12,// age_oldest
        13,// age_youngest
        14,// married_couple
        15,// C_previous
        16,// duration_previous
        24 // cost
      };
    }

    protected override void CreateMappedDataset() {
      int count = 0;
      foreach(List<string> row in DataSet) {
        count++;
        if (count % 500 != 0)
          continue;
        
        int columns = row.Count;
        Line data = new Line();
        MappedDataSet.Add(data);
        double x = 0;
        
        // inputs
        data.AddEntry(new LineEntry("day", DayMap(row[3]), 3));
        data.AddEntry(new LineEntry("time", TimeMap(row[4]), 4));
        data.AddEntry(new LineEntry("state", StateMap(row[5]), 5));
        data.AddEntry(new LineEntry("group size", GroupSizeMap(row[7]), 7));
        data.AddEntry(new LineEntry("homeowner", HomeownerMap(row[8]), 8));
        data.AddEntry(new LineEntry("car age", CarAgeMap(row[9]), 9));
        data.AddEntry(new LineEntry("car value", CarValueMap(row[10]), 10));
        data.AddEntry(new LineEntry("risk factor", RiskFactorMap(row[11]), 11));
        data.AddEntry(new LineEntry("age, oldest", AgeOldestMap(row[12]), 12));
        data.AddEntry(new LineEntry("age, youngest", AgeYoungestMap(row[13]), 13));
        data.AddEntry(new LineEntry("married couple", MarriedCoupleMap(row[14]), 14));
        data.AddEntry(new LineEntry("C previous", CPreviousMap(row[15]), 15));
        data.AddEntry(new LineEntry("duration previous", DurationPreviousMap(row[16]), 16));
        
        // outputs
        for(int i = 17; i < 24; i++) {
          if(Double.TryParse(row[i], out x))
            data.AddEntry(new LineEntry(row[i], x, i));  
          else throw new Exception("Was expecting a double, but got " + row[i] + "."
            + "This was encountered in column " + i + "!"
            + "The index of the row is: " + DataSet.IndexOf(row));
        }
        // final output
        data.AddEntry(new LineEntry("cost", CostMap(row[24]), 24));
      }
      System.Console.WriteLine("MappedDataset: " + MappedDataSet.Count);
    }
    #endregion
    
    /*
    ** Methods to map the data
    */
    private double DayMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      switch(i) {
        case 0: return 0.1; //monday
        case 1: return 0.2;
        case 2: return 0.3; //wednesday
        case 3: return 0.4;
        case 4: return 0.8; //friday
        case 5: return 0.9;
        case 6: return 1.0; //sunday
        default: throw new Exception("Expected integer between 0 and 6, but got " + i + ".");
     }
    }
    
    private double TimeMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      string hh = s.Substring(0, 2);
      int i = Int32.Parse(hh);
      if(i >= 8 && i < 11)
        return 0.2;
      if(i >= 11 && i < 14)
        return 0.4;
      if(i >= 14 && i < 17)
        return 0.6;
      if(i >= 17 && i < 24 
        || i >= 0 && i < 8)
        return 0.8;
      throw new Exception("Range of hour is not correct! Got " + i + " as input..");
    }
    
    private double StateMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      string state = s.Trim();
      int i = states.IndexOf(state);
      if(i == -1) {
        states.Add(state);
        i = states.IndexOf(state);
      }
      return (i + 1) / 50;
    }
    
    private double GroupSizeMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i / 4;
    }
    
    private double HomeownerMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i == 0 ? 0.1 : 1.0;
    }
    
    private double CarAgeMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return (i + 1) / 40;
    }
    
    private double CarValueMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      string value = s.Trim();
      int i = carValue.IndexOf(value);
      if(i == -1) {
        carValue.Add(value);
        i = carValue.IndexOf(value);
      }
      return (i + 1) / 10;
    }
    
    private double RiskFactorMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i / 4; 
    }
    
    private double AgeOldestMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i / 80;
    }

    private double AgeYoungestMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i / 40; 
    }
    
    private double MarriedCoupleMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i == 0 ? 0.1 : 1.0;
    }
    
    private double CPreviousMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i == 0 ? 0.1 : i / 4;
    }
    
    private double DurationPreviousMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return (i + 1) / 20;
    }
    
    private double CostMap(string s) {
      if(String.Compare(s.Trim(), "NA") == 0)
        return 0.001;
      int i = Int32.Parse(s);
      return i / 1000;
    }
  }
}

