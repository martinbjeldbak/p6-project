using System;
using Simple.Data;
using Genetics;
using FallingStars;
using System.Configuration;


namespace DBTesting {
  class MainClass {

    public static void Main(string[] args) {
      testInsertion();
      testSelection();
    }

    public static void testInsertion() {
      Simulation si = new Simulation(new SnakeGame(), 50);
      ObservationSaver os = new ObservationSaver(si);
      os.SavePopulation();
    }

    public static void testSelection(){
      Simulation si = new Simulation(new SnakeGame());
      ObservationSaver os = new ObservationSaver(si);
      os.SavePopulation();
      os.SavePopulation();
      os.SavePopulation();
    }
  }
}
