﻿using System;
using System.Linq;
using System.Collections.Generic;
using Utility;
using System.Threading;
using System.Threading.Tasks;

namespace Genetics {
    /// <summary>
    /// A phenotypic diversity measure for a collection of neural networks, Neural Neural Network
    /// Trait Diversity.
    /// </summary>
    public class NNTD : IDiversityMeasure {
        int runs;
        public NNTD(int runs = 100) {
            this.runs = runs;
        }

        #region IDiversityMeasure implementation
        public double MeasureDiversity(SortList<AIPlayer> individuals) {
            int outputSize = individuals.Get(0).neuralNetwork.GetNumberOfOutputs();

            double[] diversities = new double[runs];

            for (int j = 0; j < runs; j++) {
                int[] outputCount = new int[outputSize];
                double[] randInputs = new double[individuals.Get(0).neuralNetwork.GetNumberOfInputs()];
                for (int i = 0; i < randInputs.Length; i++)
                    randInputs[i] = RandomNum.RandomDouble();

                Parallel.For(0, individuals.Count, i => {
                    AIPlayer a = individuals.Get(i);
                    outputCount[a.GetStrongestOutputIndex(randInputs)]++;
                    double[] outputs = a.GetOutputs(randInputs);
                });

                double numerator = 0.0;
                int totalOrganisms = 0;
                for (int i = 0; i < outputSize; i++) {
                    numerator += outputCount[i] * (outputCount[i] - 1);
                    totalOrganisms += outputCount[i];
                }

                int s = individuals.Count;
                double demoninator = totalOrganisms * (totalOrganisms - 1);
                diversities[j] = 1.0 - numerator / demoninator;
            }

            double diversity = 0.0;
            for (int i = 0; i < runs; i++)
                diversity += diversities[i];

            return diversity / runs;
        }

        public string Name() {
            return "NNTD";
        }
        #endregion
    }
}
