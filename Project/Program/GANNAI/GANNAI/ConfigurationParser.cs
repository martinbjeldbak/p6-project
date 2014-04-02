using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Genetics;

namespace GANNAI
{
    public class ConfigurationParser
    {

        /// <summary>
        /// Element i contains a list of possible values for the i'th attribute
        /// </summary>
        private List<List<decimal>> attributeValueLists;
        private int[] currentIndexForAttributes;

        /// <summary>
        /// Parses a set of values for a number of attributes
        /// Each attributeValue must be on the form
        /// "0" -> {0}
        /// "0, 1, ..., n" -> {0, 1, ..., n}
        /// "[3-5] : 0.1" -> {3.0, 3.1, 3.2, ..., 5.0}
        /// </summary>
        /// <param name="str">array of attribute values</param>
        public ConfigurationParser(string[] attributeValues) {
            attributeValueLists = new List<List<decimal>>();
            currentIndexForAttributes = new int[attributeValues.Length];
            for (int i = 0; i < attributeValues.Length; i++) {
                attributeValueLists.Add(parseValues(attributeValues[i]));
                currentIndexForAttributes[i] = 0;
            }
        }

        /// <summary>
        /// Returns a value in the range [0.0-1.0] indicating the current progress.
        /// </summary>
        /// <returns>The progress</returns>
        public double getProgress() {
            double combinations = 1;
            double tried = 1;
            for (int i = 0; i < attributeValueLists.Count; i++) {
                combinations *= attributeValueLists[i].Count;
                tried *= currentIndexForAttributes[i] + 1;
            }
            return tried / combinations;
        }

        /// <summary>
        /// Returns an array of values for the next combination of attribute values.
        /// Returns null when all combinations are exhausted
        /// </summary>
        public double[] getNextConfiguration() {
            if (attributeValueLists == null)
                return null;

            double[] currentConf = currentConfiguration();
            int i = 0;
            while (i < attributeValueLists.Count) {
                if (currentIndexForAttributes[i] < attributeValueLists[i].Count - 1){
                    currentIndexForAttributes[i]++;
                    return currentConf;
                }
                else{
                    currentIndexForAttributes[i] = 0;
                }
                i++;
            }
            //all combinations are exhausted
            attributeValueLists = null;
            return currentConf;
        }

        /// <summary>
        /// Returns the values of the current confiugration
        /// </summary>
        /// <returns></returns>
        private double[] currentConfiguration() {
            double[] values = new double[attributeValueLists.Count];
            for (int i = 0; i < attributeValueLists.Count; i++) {
                values[i] = (double)attributeValueLists[i][currentIndexForAttributes[i]];
            }
            return values;
        }


        /// <summary>
        /// Parses a list of double values from a string which must be on the form
        /// "0" -> {0}
        /// "0, 1, ..., n" -> {0, 1, ..., n}
        /// "[3-5] : 0.1" -> {3.0, 3.1, 3.2, ..., 5.0}
        /// </summary>
        /// <param name="str">string to parse values from</param>
        /// <returns>a list of parsed values</returns>
        private List<decimal> parseValues(string str) {
            string errorMessageOnFailure = "Invalid string received for configuration attribute. Expected to be on the form \"v\" or \"v1, v2, ..., vn\" or \"[vstart-vend] : interval\". Received string: " + str;
            str = str.Replace(" ", "");
            if (str.Contains(',')) {
                string[] strValues = str.Split(',');
                if (strValues.Length == 0)
                    throw new Exception(errorMessageOnFailure);
                List<decimal> values = new List<decimal>();
                for (int i = 0; i < strValues.Length; i++){
                    decimal temp;
                    if (decimal.TryParse(strValues[i], NumberStyles.Number, CultureInfo.InvariantCulture, out temp)) {
                        values.Add(temp);
                    }
                    else{
                        throw new Exception(errorMessageOnFailure);
                    }
                }
                return values;
            }
            else if (str.Contains(":")) {
                string[] temp = str.Split('-');
                if (temp.Length != 2)
                    throw new Exception(errorMessageOnFailure);
                string[] temp2 = temp[1].Split(':');
                if (temp2.Length != 2)
                    throw new Exception(errorMessageOnFailure);
                string str_start = temp[0].Replace("[", "");
                string str_end = temp2[0].Replace("]", "");
                string str_interval = temp2[1];
                decimal start, end, interval;
                if (!Decimal.TryParse(str_start, NumberStyles.Number, CultureInfo.InvariantCulture, out start)) {
                    throw new Exception(errorMessageOnFailure);
                }
                if (!Decimal.TryParse(str_end, NumberStyles.Number, CultureInfo.InvariantCulture, out end)) {
                    throw new Exception(errorMessageOnFailure);
                }
                if (!Decimal.TryParse(str_interval, NumberStyles.Number, CultureInfo.InvariantCulture, out interval)) {
                    throw new Exception(errorMessageOnFailure);
                }
                List<decimal> values = new List<decimal>();
                for (decimal i = start; i <= end; i += interval)
                    values.Add(i);
                return values;

            }
            else {
                decimal result;
                if (decimal.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out result)) {
                    return new List<decimal>() { result };
                }
                else {
                    throw new Exception(errorMessageOnFailure);
                }
            }
        }
    }
}
