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
  public class SnakeGame : AITrainableGame {

    Random random;
    bool alive;
    AIPlayer aiplayer;
    int snakeX, snakeY;
    int foodX, foodY;
    int score;
    int[,] map;
    int mapWidth, mapHeight;
    int ticks;
    int lastDir = 0;

    public SnakeGame() {
      mapWidth = 10;
      mapHeight = 10;
      RestartGame();
    }

    private void RestartGame() {
      random = new Random(242); //use the same seed to play the same map over and over
      ticks = 0;
      alive = true;
      map = new int[mapWidth, mapHeight];
      snakeX = map.GetLength(0) / 2;
      snakeY = map.GetLength(1) / 2;
      foodX = 2;
      foodY = 2;
      score = 0;
    }

    void Tick() {
      ticks++;

      int action = GetAIPlayerOutput();
      MoveSnake(action);
      PickUpFood();
      DecreaseSnakeLength();

    }

    private int GetAIPlayerOutput() {
      //calc inputs
      int rightOk = snakeX == mapWidth - 1 ? 0 : (map[snakeX + 1, snakeY] == 0 ? 1 : 0);
      int leftOk = snakeX == 0 ? 0 : (map[snakeX - 1, snakeY] == 0 ? 1 : 0);
      int bottomOk = snakeY == mapHeight - 1 ? 0 : (map[snakeX, snakeY + 1] == 0 ? 1 : 0);
      int topOk = snakeY == 0 ? 0 : (map[snakeX, snakeY - 1] == 0 ? 1 : 0);
      int foodVertical = foodY == snakeY ? 0 : (foodY > snakeY ? 1 : -1);
      int foodHorizontal = foodX == snakeX ? 0 : (foodX > snakeX ? 1 : -1);


      return aiplayer.GetOutput(new double[] { foodVertical, foodHorizontal, rightOk, leftOk, topOk, bottomOk });
    }

    private void PickUpFood() {
      if (snakeX == foodX && snakeY == foodY) {
        score++;
        while (map[foodX, foodY] != 0) {
          foodX = random.Next(0, mapWidth);
          foodY = random.Next(0, mapHeight);
        }
      }
    }

    private void DecreaseSnakeLength() {
      for (int i = 0; i < mapWidth; i++)
        for (int p = 0; p < mapHeight; p++)
          if (map[i, p] > 0)
            map[i, p]--;
    }

    private void MoveSnake(int action) {

      if (action == 0) { //turn left
        switch (lastDir) {
          case 0: MoveUp(); break;
          case 1: MoveLeft(); break;
          case 2: MoveDown(); break;
          case 3: MoveRight(); break;
        }
      }
      else if (action == 1) { //keep same direction
        switch (lastDir) {
          case 0: MoveRight(); break;
          case 1: MoveUp(); break;
          case 2: MoveLeft(); break;
          case 3: MoveDown(); break;
        }
      }
      else if (action == 2) { //turn right
        switch (lastDir) {
          case 0: MoveDown(); break;
          case 1: MoveRight(); break;
          case 2: MoveUp(); break;
          case 3: MoveLeft(); break;
        }
      }
    }

    private void MoveRight() {
      if (snakeX == mapWidth - 1 || map[snakeX + 1, snakeY] != 0) {
        alive = false;
      }
      else {
        snakeX++;
        map[snakeX, snakeY] = score + 5;
        lastDir = 0;
      }
    }
    private void MoveLeft() {
      if (snakeX == 0 || map[snakeX - 1, snakeY] != 0) {
        alive = false;
      }
      else {
        snakeX--;
        map[snakeX, snakeY] = score + 5;
        lastDir = 2;
      }
    }
    private void MoveUp() {
      if (snakeY == 0 || map[snakeX, snakeY - 1] != 0) {
        alive = false;
      }
      else {
        snakeY--;
        map[snakeX, snakeY] = score + 5;
        lastDir = 1;
      }
    }
    private void MoveDown() {
      if (snakeY == mapHeight - 1 || map[snakeX, snakeY + 1] != 0) {
        alive = false;
      }
      else {
        snakeY++;
        map[snakeX, snakeY] = score + 5;
        lastDir = 3;
      }
    }

    public double CalcFitness(AIPlayer aiplayer) {
      this.aiplayer = aiplayer;
      RestartGame();
      while (alive && ticks < 400) {
        Tick();
      }
      return score + ticks / 1000.0;
    }

    public int NumInputs() {
      return 6;
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
      while (alive && ticks < 300) {
        Tick();
        DrawMapToForm(form);
        Thread.Sleep(40);
      }
    }

    void DrawMapToForm(Form form) {
      int size = 20;

      SolidBrush redBrush = new SolidBrush(Color.Red);
      SolidBrush blueBrush = new SolidBrush(Color.Blue);
      SolidBrush blackBrush = new SolidBrush(Color.Black);
      SolidBrush grayBrush = new SolidBrush(Color.Gray);

      Brush brush;

      Graphics g = form.CreateGraphics();

      g.Clear(Color.White);
      g.FillRectangle(grayBrush, new Rectangle(0, 0, mapWidth * size, mapHeight * size));
      for (int x = 0; x < mapWidth; x++) {
        for (int y = 0; y < mapHeight; y++) {
          brush = map[x, y] > 0 ? blackBrush : null;
          if (x == snakeX && y == snakeY) {
            brush = blueBrush;
          }
          if (x == foodX && y == foodY)
            brush = redBrush;
          if (brush != null)
            g.FillRectangle(brush, new Rectangle(x*size, y*size, size, size));
        }
      }

      g.DrawString(ticks.ToString(), new Font("Arial", 20), new SolidBrush(Color.Black), new PointF(300, 15));
      g.DrawString(score.ToString(), new Font("Arial", 20), new SolidBrush(Color.Black), new PointF(300, 45));

    }
  }
}
