using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetics {
  public static class Configuration {
    private static AITrainableGame[] gameInstances;
    private static int nextGameInstanceId = 0;
    public static int PopulationSize = 100;
    public static AITrainableGame Game { 
      get {
        if (nextGameInstanceId >= gameInstances.Length)
          nextGameInstanceId = 0;
        return gameInstances[nextGameInstanceId++];
      }
      set {
        nextGameInstanceId = 0;
        gameInstances = new AITrainableGame[PopulationSize];
        for (int i = 0; i < PopulationSize; i++)
          gameInstances[i] = value.GetNewGameInstance();
      }
    }
    public static NNMaker NeuralNetworkMaker;
  }
}
