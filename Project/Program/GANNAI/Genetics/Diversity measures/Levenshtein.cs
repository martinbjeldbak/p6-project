using System;
using System.Linq;

namespace Genetics.DiversityMeasures {
    /// <summary>
    /// Meausres diversity solely based on fitness. It is the number
    /// of unique fitness values in the population, devided by the size
    /// of the population.
    /// </summary>
    public class Levenshtein : IDiversityMeasure {
        #region IDiversityMeasure implementation

        public double MeasureDiversity(Utility.SortList<AIPlayer> individuals) {
            int maxDist = individuals.Get(0).DNA.Length;
            int count = individuals.Count;
            double sum = 0;
            for (int i = 0; i < count; i++) {
                for (int p = i + 1; p < count; p++)
                    sum += LevenshteinDistance(individuals.Get(i).DNA.Bitstring, individuals.Get(p).DNA.Bitstring);
            }
            //calculate average distance between any two strings, and normalize to lie in range 0.0-1.0
            return (sum / (count * (count - 1) / 2)) / maxDist;
        }

        public string Name {
          get { return "Levenshtein"; }
        }

        #endregion

        /// <summary>
        /// Calculates Levenshtein distance between two bit strings
        /// Implementation found at http://en.wikipedia.org/wiki/Levenshtein_distance
        /// </summary>
        /// <param name="s">One bit string</param>
        /// <param name="t">Another bit string</param>
        /// <returns>The Levenshtein distance</returns>
        int LevenshteinDistance(bool[] s, bool[] t) {
            // degenerate cases
            if (s == t) return 0;
            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[t.Length + 1];
            int[] v1 = new int[t.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < s.Length; i++) {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < t.Length; j++) {
                    var cost = (s[i] == t[j]) ? 0 : 1;
                    v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[t.Length];
        }
    }
}

