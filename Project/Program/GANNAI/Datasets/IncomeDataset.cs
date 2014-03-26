using System;
using System.Collections.Generic;

namespace Datasets {
  public class IncomeDataset : Dataset {
    public IncomeDataset(double validationPercent = 0.4) : base(validationPercent) {
      string csvString = Properties.Resources.adult;

      DataSet.AddRange(ParseDataFromString(csvString));

      CreateValidationAndTestSet();
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

		public static bool IncomeMap(char c) {
			return c == '<';
		}

    public static double AgeMap(string age) {
      double mappedAge = Double.Parse(age);

      // Cut into levels Young (0-25), Middle-aged (26-45),
      // Senior (46-65) and Old (66+).
      if(mappedAge >= 0 && mappedAge <= 25)
        return 0.0;
      else if(mappedAge > 25 && mappedAge <= 45)
        return 1.0;
      else if(mappedAge > 45 && mappedAge <= 65)
        return 2.0;
      else if(mappedAge > 65)
        return 3.0;
      else
        throw new Exception("Unknown age mapping: " + age);
    }

    public static double WorkClassMap(string workClass) {
      List<string> options = OptionsCreator("Private", "Self-emp-not-inc",
        "Self-emp-inc", "Federal-gov", "Local-gov", "State-gov", "Without-pay", "Never-worked");

      return options.FindIndex(s => String.Equals(s, workClass));
    }

    public static double EducationNumMap(string educationNum) {
      return Double.Parse(educationNum);
    }

    public static double MaritalStatusMap(string maritalStatus) {
      List<string> options = OptionsCreator("Married-civ-spouse", "Divorced", "Never-married",
        "Separated", "Widowed", "Married-spouse-absent", "Married-AF-spouse");

      return (double)options.FindIndex(s => String.Equals(s, maritalStatus));
    }

    public static double OccupationMap(string occupation) {
      List<string> options = OptionsCreator("Tech-support", "Craft-repair", "Other-service",
        "Sales", "Exec-managerial", "Prof-specialty", "Handlers-cleaners", "Machine-op-inspct",
        "Adm-clerical", "Farming-fishing", "Transport-moving", "Priv-house-serv", "Protective-serv",
        "Armed-Forces");

      return (double)options.FindIndex(s => String.Equals(s, occupation));
    }

    public static double RelationshipMap(string relationship) {
      List<string> options = OptionsCreator("Wife", "Own-child", "Husband", "Not-in-family",
        "Other-relative", "Unmarried");

      return (double)options.FindIndex(s => String.Equals(s, relationship));
    }
    
    public static double RaceMap(string race) {
      List<string> options = OptionsCreator("White", "Asian-Pac-Islander",
        "Amer-Indian-Eskimo", "Other", "Black");

      return (double)options.FindIndex(s => String.Equals(s, race));
    }

    public static double SexMap(string sex) {
      List<string> options = OptionsCreator("Female", "Male");

      return (double)options.FindIndex(s => String.Equals(s, sex));
    }

    public static double CapitalGainMap(string capitalGain, double median) {
      double gain = Double.Parse(capitalGain);

      //cut into levels None (0), Low (0 < median of the values greater zero < max) and High (>=max).
      if(gain == 0.0)
        return 0.0;
      else if(gain < median)
        return 1.0;
      else if(gain >= median)
        return 2.0;
      else
        throw new Exception("Unknown capital gain mapping: " + capitalGain + " with median: " + median.ToString());
    }

    public static double CapitalLossMap(string capitalLoss, double median) {
      return CapitalGainMap(capitalLoss, median);
    }

    public static double HoursPerWeekMap(string hoursPerWeek) {
      double hpw = Double.Parse(hoursPerWeek);

      // Cut into levels Part-time (0-25), Full-time (25-40), Over-time (40-60) and Too-much (60+).
      if(hpw >= 0 && hpw <= 25)
        return 0.0;
      else if(hpw > 25 && hpw <= 40)
        return 1.0;
      else if(hpw > 40 && hpw <= 60)
        return 2.0;
      else if(hpw > 60)
        return 3.0;
      else
        throw new Exception("Unknown hours per week mapping: " + hoursPerWeek);
    }

    public static double NativeCountryMap(string nativeCountry) {
      List<string> options = OptionsCreator("United-States", "Cambodia", "England", "Puerto-Rico",
        "Canada", "Germany", "Outlying-US(Guam-USVI-etc)", "India", "Japan", "Greece", "South", "China",
        "Cuba", "Iran", "Honduras", "Philippines", "Italy", "Poland", "Jamaica", "Vietnam", "Mexico",
        "Portugal", "Ireland", "France", "Dominican-Republic", "Laos", "Ecuador", "Taiwan", "Haiti",
        "Columbia", "Hungary", "Guatemala", "Nicaragua", "Scotland", "Thailand", "Yugoslavia", "El-Salvador",
        "Trinadad&Tobago", "Peru", "Hong", "Holand-Netherlands");

      return (double)options.FindIndex(s => String.Equals(s, nativeCountry));
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



    #region implemented abstract members of Dataset

    public override int[] OutputIndicies() {
      return new int[] { 14 };
    }

    public override int[] InputIndicies() {
      List<int> indicies = new List<int>();

      int outputIndex = OutputIndicies()[0];

      for(int i = 0; i < outputIndex; i++) {
        // Remove fnlwgt and education fields
        if(i !=2 && i != 3) {
          indicies.Add(i);
        }
      }

      return indicies.ToArray();
    }
    #endregion
  }
}

