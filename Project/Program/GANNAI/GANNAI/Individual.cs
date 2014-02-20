using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GANNAI {
  public abstract class Individual {
    private DNA dna;
    public Individual(int dnaLength) {

    }
    public abstract double GetFitness();
    public Individual SinglePointCrossover(Individual other) {
      return null;
    }
    public Individual TwoPointCrossover(Individual other) {
      return null;
    }
    public Individual UniformCrossover(Individual other) {
      return null;
    }
  }
}
