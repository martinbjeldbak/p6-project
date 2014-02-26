using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Genetics;
using FallingStars;

namespace GANNAIUI {
  public partial class Form1 : Form {

    AITrainer aiTrainer;

    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void StartTraining() {
      if (Configuration.Game == null) {
        MessageBox.Show("No game selected");
        return;
      }

      int iterations;
      try {
        iterations = Int32.Parse(num_iterations.Text);
      }
      catch (FormatException) {
        MessageBox.Show("Number of iterations must be a positive integer");
        return;
      }
      if (iterations <= 0) {
        MessageBox.Show("Number of iterations must be a positive integer");
        return;
      }

      aiTrainer.Train(iterations);

      //print fitness values
      listBox1.Items.Clear();
      double[] fitnessValues = aiTrainer.GetFitnessValues();
      for (int i = 0; i < fitnessValues.Length; i++)
        listBox1.Items.Add(fitnessValues[i]);

      continueButton.Enabled = true;
      visualizeButton.Enabled = true;
    }

    private void goButton_Click(object sender, EventArgs e) {
     
      aiTrainer = new AITrainer();

      StartTraining();
    }

    private void FallingStarsRadioButton_CheckedChanged(object sender, EventArgs e) {
      continueButton.Enabled = false;
      visualizeButton.Enabled = false;
      Configuration.Game = new FallingStarsGame();
    }

    private void BombermanRadioButton_CheckedChanged(object sender, EventArgs e) {
      continueButton.Enabled = false;
      visualizeButton.Enabled = false;
      Configuration.Game = null;
    }

    private void SnakeRadioButton_CheckedChanged(object sender, EventArgs e) {
      continueButton.Enabled = false;
      visualizeButton.Enabled = false;
      Configuration.Game = null;
    }

    private void continueButton_Click(object sender, EventArgs e) {
      StartTraining();
    }

    private void visualizeButton_Click(object sender, EventArgs e) {
      Form form = new Form();
      form.Show();
      Configuration.Game.Visualize(aiTrainer.GetBest(), form);
    }
  }
}
