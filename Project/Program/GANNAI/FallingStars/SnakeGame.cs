﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Genetics;

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
    int lastDir;

    public SnakeGame() {
      mapWidth = 10;
      mapHeight = 10;
      RestartGame();
    }

    public AITrainableGame GetNewGameInstance() {
      return new SnakeGame();
    }

    private void RestartGame() {
      random = new Random(242); //use the same seed to play the same map over and over
      ticks = 0;
      alive = true;
      map = new int[mapWidth, mapHeight];
  
      snakeX = 0;
      snakeY = 0;
      foodX = 2;
      foodY = 6;
      score = 0;
      lastDir = 0;
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

      /*
      int i, dis;
      int right, left, top, bottom;

      

      i = snakeX + 1;
      dis = 0;
      while (i < mapWidth && map[i, snakeY] == 0) {
        dis++;
        i++;
      }
      right = dis;

      i = snakeX - 1;
      dis = 0;
      while (i > 0 && map[i, snakeY] == 0) {
        dis++;
        i--;
      }
      left = dis;

      i = snakeY + 1;
      dis = 0;
      while (i < mapHeight && map[snakeX, i] == 0) {
        dis++;
        i++;
      }
      bottom = dis;

      i = snakeY - 1;
      dis = 0;
      while (i > 0 && map[snakeX, i] == 0) {
        dis++;
        i--;
      }
      top = dis;
      */
      
      int right = snakeX == mapWidth - 1 ? -1 : (map[snakeX + 1, snakeY] == 0 ? 1 : -1);
      int left = snakeX == 0 ? -1 : (map[snakeX - 1, snakeY] == 0 ? 1 : -1);
      int bottom = snakeY == mapHeight - 1 ? -1 : (map[snakeX, snakeY + 1] == 0 ? 1 : -1);
      int top = snakeY == 0 ? -1 : (map[snakeX, snakeY - 1] == 0 ? 1 : -1);
      
      int foodVertical = foodY == snakeY ? 0 : (foodY > snakeY ? 1 : -1);
      int foodHorizontal = foodX == snakeX ? 0 : (foodX > snakeX ? 1 : -1);


      return aiplayer.GetOutput( new double[]{right, left, top, bottom, foodHorizontal, foodVertical});
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

      if (action == 0) { //move right
        if (lastDir != 2)
          MoveRight();
        else
          MoveLeft();
      }
      else if (action == 1) { //move up
        if (lastDir != 3)
          MoveUp();
        else
          MoveDown();
      }
      else if (action == 2) { //move left
        if (lastDir != 0)
          MoveLeft();
        else
          MoveRight();
      }
      else if (action == 3) { //move down
        if (lastDir != 1)
          MoveDown();
        else
          MoveUp();
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
      while (alive && ticks < 1000) {
        Tick();
      }
      return score + ticks / 1000.0;
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
      while (alive && ticks < 1000) {
        Tick();
        DrawMapToForm(form);
        Thread.Sleep(40);
      }
    }

    void DrawMapToForm(Form form) {
      int size = 20;

      SolidBrush redBrush = new SolidBrush(Color.Red);
      SolidBrush blueBrush = new SolidBrush(Color.Aqua);
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


    public int NumInputs() {
      return 6;
    }

    public int NumOutputs() {
      return 4;
    }

    /// <summary>
    /// Returns the name of the game as a string.
    /// </summary>
    public string Name(){
      return "Snake";
    }
  }
}
