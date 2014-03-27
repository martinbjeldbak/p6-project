using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Datasets {
  public class IncomeDataset : Dataset {
    

    private double gainMedian, lossMedian = Double.NegativeInfinity;

    public double GainMedian {
      get {
        return gainMedian = (Double.IsNegativeInfinity(gainMedian) ? CapitalGainMedian() : gainMedian);
      }
    }

    public double LossMedian {
      get {
        return lossMedian = (Double.IsNegativeInfinity(lossMedian) ? CapitalLossMedian() : lossMedian);
      }
    }

    private double CapitalGainMedian() {
      List<double> gains = new List<double>();

      foreach (List<string> line in DataSet) {
        gains.Add(Double.Parse(line[10]));
      }

      return Util.ComputeMedian(gains.OrderBy(n => n).ToList());
    }

    private double CapitalLossMedian() {
      List<double> losses = new List<double>();

      foreach (List<string> line in DataSet) {
        losses.Add(Double.Parse(line[11]));
      }

      return Util.ComputeMedian(losses.OrderBy(n => n).ToList());
    }

    public IncomeDataset(double validationPercent = 0.4) : base(validationPercent) {
      string csvString = Properties.Resources.adult;

      DataSet.AddRange(ParseDataFromString(csvString));

      CreateValidationAndTestSet();

      CreateMappedDataset();
      CreateMappedValidationAndTestSet();
    }


    protected override void CreateMappedDataset() {
      foreach (List<string> stringLine in DataSet) {
        int cols = stringLine.Count;

        Line line = new Line();
        MappedDataSet.Add(line);

        for (int i = 0; i < cols; i++) {
          string value = stringLine[i];

          //if(line.IndexOf("?") != -1)
          //  continue;
          switch (i) {
            case 0:
              line.AddEntry(new LineEntry("age", IncomeDataset.AgeMap(value), i));
              break;
            case 1:
              line.AddEntry(new LineEntry("workclass", IncomeDataset.WorkClassMap(value), i));
              break;
            case 2:
              // Fitting weight, not needed
              break;
            case 3:
              // Education in words, case 4 is the same in years
              break;
            case 4:
              line.AddEntry(new LineEntry("education-num", IncomeDataset.EducationNumMap(value), i));
              break;
            case 5:
              line.AddEntry(new LineEntry("marital-status", IncomeDataset.MaritalStatusMap(value), i));
              break;
            case 6:
              line.AddEntry(new LineEntry("occupation", IncomeDataset.OccupationMap(value), i));
              break;
            case 7:
              line.AddEntry(new LineEntry("relationship", IncomeDataset.RelationshipMap(value), i));
              break;
            case 8:
              line.AddEntry(new LineEntry("race", IncomeDataset.RaceMap(value), i));
              break;
            case 9:
              line.AddEntry(new LineEntry("sex", IncomeDataset.SexMap(value), i));
              break;
            case 10:
              line.AddEntry(new LineEntry("capital-gain", IncomeDataset.CapitalGainMap(value, GainMedian), i));
              break;
            case 11:
              line.AddEntry(new LineEntry("capital-loss", IncomeDataset.CapitalLossMap(value, LossMedian), i));
              break;
            case 12:
              line.AddEntry(new LineEntry("hours-per-week", IncomeDataset.HoursPerWeekMap(value), i));
              break;
            case 13:
              line.AddEntry(new LineEntry("native-country", IncomeDataset.NativeCountryMap(value), i));
              break;
            case 14:
              line.AddEntry(new LineEntry("salary >50K?", IncomeDataset.IncomeMap(value[0]), i));
              break;
            default:
              throw new Exception("No mapping of inputs");
          }
        }
      }
    }

    public static string IncomeMap(int index) {
      switch(index) {
        case 0:
          return ">50K";
        case 1:
          return "<=50K";
        default:
          throw new Exception("No such mapping to adult income class");
      }
    }

		public static double IncomeMap(char c) {
			return c == '>' ? 1 : 0;
		}

    # region Static maps of strings in dataset to ints
    public static int AgeMap(string age) {
      double mappedAge = int.Parse(age);

      // Cut into levels Young (0-25), Middle-aged (26-45),
      // Senior (46-65) and Old (66+).
      if(mappedAge >= 0 && mappedAge <= 25)
        return 0;
      else if(mappedAge > 25 && mappedAge <= 45)
        return 1;
      else if(mappedAge > 45 && mappedAge <= 65)
        return 2;
      else if(mappedAge > 65)
        return 3;
      else
        throw new Exception("Unknown age mapping: " + age);
    }

    public static int WorkClassMap(string workClass) {
      List<string> options = OptionsCreator("Private", "Self-emp-not-inc",
        "Self-emp-inc", "Federal-gov", "Local-gov", "State-gov", "Without-pay", "Never-worked");

      return options.FindIndex(s => String.Equals(s, workClass));
    }

    public static int EducationNumMap(string educationNum) {
      return int.Parse(educationNum);
    }

    public static int MaritalStatusMap(string maritalStatus) {
      List<string> options = OptionsCreator("Married-civ-spouse", "Divorced", "Never-married",
        "Separated", "Widowed", "Married-spouse-absent", "Married-AF-spouse");

      return options.FindIndex(s => String.Equals(s, maritalStatus));
    }

    public static int OccupationMap(string occupation) {
      List<string> options = OptionsCreator("Tech-support", "Craft-repair", "Other-service",
        "Sales", "Exec-managerial", "Prof-specialty", "Handlers-cleaners", "Machine-op-inspct",
        "Adm-clerical", "Farming-fishing", "Transport-moving", "Priv-house-serv", "Protective-serv",
        "Armed-Forces");

      return options.FindIndex(s => String.Equals(s, occupation));
    }

    public static int RelationshipMap(string relationship) {
      List<string> options = OptionsCreator("Wife", "Own-child", "Husband", "Not-in-family",
        "Other-relative", "Unmarried");

      return options.FindIndex(s => String.Equals(s, relationship));
    }
    
    public static int RaceMap(string race) {
      List<string> options = OptionsCreator("White", "Asian-Pac-Islander",
        "Amer-Indian-Eskimo", "Other", "Black");

      return options.FindIndex(s => String.Equals(s, race));
    }

    public static int SexMap(string sex) {
      List<string> options = OptionsCreator("Female", "Male");

      return options.FindIndex(s => String.Equals(s, sex));
    }

    public static int CapitalGainMap(string capitalGain, double median) {
      double gain = int.Parse(capitalGain);

      //cut into levels None (0), Low (0 < median of the values greater zero < max) and High (>=max).
      if(gain == 0)
        return 0;
      else if(gain < median)
        return 1;
      else if(gain >= median)
        return 2;
      else
        throw new Exception("Unknown capital gain mapping: " + capitalGain + " with median: " + median.ToString());
    }

    public static int CapitalLossMap(string capitalLoss, double median) {
      return CapitalGainMap(capitalLoss, median);
    }

    public static int HoursPerWeekMap(string hoursPerWeek) {
      double hpw = int.Parse(hoursPerWeek);

      // Cut into levels Part-time (0-25), Full-time (25-40), Over-time (40-60) and Too-much (60+).
      if(hpw >= 0 && hpw <= 25)
        return 0;
      else if(hpw > 25 && hpw <= 40)
        return 1;
      else if(hpw > 40 && hpw <= 60)
        return 2;
      else if(hpw > 60)
        return 3;
      else
        throw new Exception("Unknown hours per week mapping: " + hoursPerWeek);
    }

    public static int NativeCountryMap(string nativeCountry) {
      List<string> options = OptionsCreator("United-States", "Cambodia", "England", "Puerto-Rico",
        "Canada", "Germany", "Outlying-US(Guam-USVI-etc)", "India", "Japan", "Greece", "South", "China",
        "Cuba", "Iran", "Honduras", "Philippines", "Italy", "Poland", "Jamaica", "Vietnam", "Mexico",
        "Portugal", "Ireland", "France", "Dominican-Republic", "Laos", "Ecuador", "Taiwan", "Haiti",
        "Columbia", "Hungary", "Guatemala", "Nicaragua", "Scotland", "Thailand", "Yugoslavia", "El-Salvador",
        "Trinadad&Tobago", "Peru", "Hong", "Holand-Netherlands");

      return options.FindIndex(s => String.Equals(s, nativeCountry));
    }

    private static List<string> OptionsCreator(params string[] options) {
      List<string> l = new List<string>();
      l.AddRange(options);
      return l;
    }

    /// <summary>
    /// Gets the final sampling weight.
    /// </summary>
    /// <returns>The parsed weight</returns>
    /// <param name="fnlwgt">Fnlwgt.</param>
    //public static double FnlwgtMap(string fnlwgt) {
    //  return Double.Parse(fnlwgt);
    //}

    //public static double EducationMap(string education) {
    //  List<string> options = new List<string>() { "Bachelors", "Some-college", "11th", "HS-grad",
    //    "Prof-school", "Assoc-acdm", "Assoc-voc", "9th", "7th-8th", "12th", "Masters", "1st-4th",
    //    "10th", "Doctorate", "5th-6th", "Preschool" };

    //  return (double)options.FindIndex(s => String.Compare(s, education));
    //}
    #endregion

    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return MappedDataSet.First().entries.Where(e => e.Column == 14).Select(e => e.Column).ToArray();
    }

    public override int[] InputIndicies() {
      return MappedDataSet.First().entries.Where(e => e.Column != 14).Select(e => e.Column).ToArray();
    }

    #endregion
  }
}

