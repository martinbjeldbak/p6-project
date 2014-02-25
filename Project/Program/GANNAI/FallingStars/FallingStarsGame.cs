using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Genetics;
using GANNAI;

namespace FallingStars {
  public class FallingStarsGame : AITrainableGame {

    bool alive;
    AIPlayer aiplayer;
    int playerX;
    bool[,] map;
    int mapWidth = 7;
    int mapHeight = 10;
    int ticks;

    private void RestartGame() {
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
      int newStarPosX = Utility.RandomInt(0, mapWidth);
      newMap[newStarPosX, 0] = true;


      //calculate the inputs
      int in1 = playerX;
      int in2 = map[playerX, mapHeight - 2] ? 1 : 0;

      bool[] outputs = aiplayer.GetOutputs(new int[]{in1, in2});

      if (outputs[0]) { //move left
        playerX--;
        if (playerX < 0)
          playerX = 0;
      }
      else if (outputs[1]) { //move right
        playerX++;
        if (playerX > mapWidth - 1)
          playerX = mapWidth - 1;
      }
      //else if outputs[2],  dont move

      CheckIfDead();

      //update map
      map = newMap;
    }

    public void CheckIfDead() {
      if (map[playerX, mapHeight - 1])
        alive = false;
    }

    public double CalcFitness(AIPlayer aiplayer) {
      this.aiplayer = aiplayer;
      RestartGame();
      while (alive) {
        Tick();
      }
      return ticks;
    }

    public double NumInputs() {
      return 2;
    }

    public double NumOutputs() {
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
        Thread.Sleep(500);
      }
    }

    void DrawMapToForm(Form form) {
      int size = 10;

      Pen pen;

      Graphics g = form.CreateGraphics();
      for (int x = 0; x < mapWidth; x++) {
        for (int y = 0; y < mapHeight; y++) {
          pen = map[x, y] ? new Pen(Color.Black, 5) : null;
          if (y == mapHeight - 1 && x == playerX) {
            pen = map[x, y] ? new Pen(Color.Red, 5) : new Pen(Color.Green, 5);
          }
          if (pen != null)
            g.DrawRectangle(pen, new Rectangle(x*size, y*size, size, size));
        }
      }
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
  }
}
