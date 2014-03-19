using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Genetics;

namespace Games {
  public class FallingStarsGame : AITrainableGame {

    Random random;
    bool alive;
    AIPlayer aiplayer;
    int playerX;
    bool[,] map;
    int mapWidth;
    int mapHeight;
    int ticks;

    public FallingStarsGame() {
      mapWidth = 7;
      mapHeight = 10;
      RestartGame();
    }

    private void RestartGame() {
      random = new Random(242); //use the same seed to play the same map over and over
      ticks = 0;
      alive = true;
      map = new bool[mapWidth, mapHeight];
      playerX = map.GetLength(0) / 2;
    }

    void Tick() {
      ticks++;

      bool[,] newMap = new bool[mapWidth, mapHeight];
      for (int i = 0; i < mapWidth; i++)
        for (int p = 1; p < mapHeight; p++)
          newMap[i, p] = map[i, p-1];
      int newStarPosX = random.Next(0, mapWidth);
      newMap[newStarPosX, 0] = true;


      //calculate the inputs
      int in1 = playerX == 0 ? 1 : (map[playerX - 1, mapHeight - 1] ? 1 : 0);
      int in2 = playerX == mapWidth - 1 ? 1 : (map[playerX + 1, mapHeight - 1] ? 1 : 0);
      int in3 = map[playerX, mapHeight - 2] ? 1 : 0; //is there a star above?
      int in4 = playerX;


      int action = aiplayer.GetStrongestOutputIndex(new double[] { in1, in2, in3, in4 });
      //bool[] outputs = aiplayer.GetOutputs(new double[]{in1, in2, in3, in4});

      if (action == 0) { //move left
        if (playerX != 0 && !map[playerX-1, mapHeight - 1]){
          playerX--;
        }
      }
      else if (action == 2) { //move right
        if (playerX != mapWidth - 1 && !map[playerX + 1, mapHeight - 1]) {
          playerX++;
        }
      }
      //else if acction == 1,  dont move

      //update map
      map = newMap;

      DieIfHit();
    }

    public void DieIfHit() {
      if (map[playerX, mapHeight - 1])
        alive = false;
    }

    public double CalcFitness(AIPlayer aiplayer) {
      this.aiplayer = aiplayer;
      RestartGame();
      while (alive && ticks < 4000) {
        Tick();
      }
      return ticks;
    }

    public int NumInputs() {
      return 4;
    }

    public int NumOutputs() {
      return 3;
    }

    /// <summary>
    /// Visualizes the game being played by the given AIPlayer, drawn on the given Form
    /// </summary>
    /// <param name="aiplayer"></param>
    /// <param name="form"></param>
    public void Visualize(AIPlayer aiplayer, Form form) {
      form.Width = 400;
      form.Height = 400;
      this.aiplayer = aiplayer;
      RestartGame();
      while (alive) {
        Tick();
        DrawMapToForm(form);
        Thread.Sleep(200);
      }
    }

    void DrawMapToForm(Form form) {
      int size = 30;

      SolidBrush redBrush = new SolidBrush(Color.Red);
      SolidBrush blueBrush = new SolidBrush(Color.Blue);
      SolidBrush blackBrush = new SolidBrush(Color.Black);

      Brush brush;

      Graphics g = form.CreateGraphics();
      g.Clear(Color.White);
      for (int x = 0; x < mapWidth; x++) {
        for (int y = 0; y < mapHeight; y++) {
          brush = map[x, y] ? blueBrush : null;
          if (y == mapHeight - 1 && x == playerX) {
            brush = map[x, y] ? redBrush : blackBrush;
          }
          if (brush != null)
            g.FillRectangle(brush, new Rectangle(x*size, y*size, size, size));
        }
      }

      g.DrawString(ticks.ToString(), new Font("Arial", 20), new SolidBrush(Color.Black), new PointF(300, 15));

    }

    void DrawMapToConsole() {
      Console.Clear();
      for (int x = 0; x < mapWidth; x++ ) {
        Console.WriteLine();
        for (int y = 0; y < mapHeight; y++) {
          char c = map[x,y] ? 'O' : ' ';
          if (y == mapHeight - 1 && x == playerX){
            c = map[x, y] ? '+' : 'X';
          }
          Console.Write(c);
        }
      }
    }


    public AITrainableGame GetNewGameInstance() {
      return new FallingStarsGame();
    }

    /// <summary>
    /// Returns the name of the game as a string.
    /// </summary>
    public string Name(){
      return "Falling Stars";
    }
  }
}
