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
using Games;

namespace GANNAIUI {
  public partial class Form1 : Form {

    Simulation simulation;
    ObservationSaver obs;

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
        MessageBox.Show("Number of iterations must be a positive integer or 0");
        return;
      }

      simulation.Simulate(iterations, saveToDBButton.Checked ? obs : null);
      PrintFitnessValues();
      visualizeButton.Enabled = true;
      generationCountLabel.Text = "Generation No: " + simulation.Population.Generation.ToString();
      diversityLabel.Text = "Diversity: " + simulation.Population.MeasureDiversity().ToString();
    }

    private void PrintFitnessValues() {
      //print fitness values
      listBox1.Items.Clear();
      double[] fitnessValues = simulation.GetFitnessValues();
      for (int i = 0; i < fitnessValues.Length; i++)
        listBox1.Items.Add(fitnessValues[i]);
    }

    private void goButton_Click(object sender, EventArgs e) {
      if (saveToDBButton.Checked) {
        obs = new ObservationSaver(simulation);
      }

      int runs;
      try
      {
          runs = Int32.Parse(runsTextBox.Text);
      }
      catch (FormatException)
      {
          MessageBox.Show("Number of runs must be a positive integer");
          return;
      }
      if (runs <= 0)
      {
          MessageBox.Show("Number of runs must be a positive integer");
          return;
      }

      for (int i = 0; i < runs; i++ )
          StartTraining();
    }

    private void FallingStarsRadioButton_CheckedChanged(object sender, EventArgs e) {
      simulation = new Simulation(new FallingStarsGame());
      GameChanged();
    }

    private void GameChanged(){
      goButton.Enabled = true;
      visualizeButton.Enabled = false;
      saveToDBButton.Enabled = true;
      listBox1.Items.Clear();
      generationCountLabel.Text = "Generation No:";
      diversityLabel.Text = "Diversity:";
    }

    private void BombermanRadioButton_CheckedChanged(object sender, EventArgs e) {
      //throw new Exception("Bomberman not implemented yet");
      simulation = new Simulation(new Income());
      GameChanged();
    }

    private void SnakeRadioButton_CheckedChanged(object sender, EventArgs e) {
      simulation = new Simulation(new SnakeGame());
      GameChanged();
    }

    private void visualizeButton_Click(object sender, EventArgs e) {
      Form form = new Form();
      form.Show();
      simulation.Game.Visualize(simulation.GetBest(), form);
    }

    private void IrisRadioButton_Click(object sender, EventArgs e) {
      simulation = new Simulation(new Iris());
      GameChanged();
    }
  }
}
