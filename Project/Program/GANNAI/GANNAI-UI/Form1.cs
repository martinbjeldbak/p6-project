using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Genetics;
using FallingStars;

namespace GANNAIUI {
  public partial class Form1 : Form {

    Simulation simulation;

    public Form1() {
      InitializeComponent();
    }

    private void StartTraining() {
      if (simulation.Game == null) {
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
      if (iterations < 0) {
        MessageBox.Show("Number of iterations must be a positive integer");
        return;
      }

      ObservationSaver obs = saveToDBButton.Checked ? new ObservationSaver(simulation) : null;
      simulation.Simulate(iterations, obs);
      PrintFitnessValues();

      continueButton.Enabled = true;
      visualizeButton.Enabled = true;
      generationCountLabel.Text = "Generation No: " + simulation.Population.Generation.ToString();
      diversityLabel.Text = "Diversity: " + simulation.Population.MeasureDiversity(10).ToString();
    }

    private void PrintFitnessValues() {
      //print fitness values
      listBox1.Items.Clear();
      double[] fitnessValues = simulation.GetFitnessValues();
      for (int i = 0; i < fitnessValues.Length; i++)
        listBox1.Items.Add(fitnessValues[i]);
    }

    private void goButton_Click(object sender, EventArgs e) {
      simulation.Restart();
      StartTraining();
    }

    private void FallingStarsRadioButton_CheckedChanged(object sender, EventArgs e) {
      goButton.Enabled = true;
      continueButton.Enabled = false;
      visualizeButton.Enabled = false;
      simulation = new Simulation(new FallingStarsGame());
    }

    private void BombermanRadioButton_CheckedChanged(object sender, EventArgs e) {
      throw new Exception("Bomberman not implemented yet");
    }

    private void SnakeRadioButton_CheckedChanged(object sender, EventArgs e) {
      goButton.Enabled = true;
      continueButton.Enabled = false;
      visualizeButton.Enabled = false;
      simulation = new Simulation(new SnakeGame());
    }

    private void continueButton_Click(object sender, EventArgs e) {
      StartTraining();
    }

    private void visualizeButton_Click(object sender, EventArgs e) {
      Form form = new Form();
      form.Show();
      simulation.Game.Visualize(simulation.GetBest(), form);
    }

    private void measurePerformanceButton_Click(object sender, EventArgs e) {

    }
  }
}
