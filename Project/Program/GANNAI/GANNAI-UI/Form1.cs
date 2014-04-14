using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using GANNAI;
using Genetics;
using Games;

namespace GANNAIUI {
  public partial class Form1 : Form {

    Simulation simulation;
    ObservationSaver obs;
    AITrainableGame game;

    public Form1() {
      InitializeComponent();
      game = new SnakeGame();
    }

    private void StartTraining(int iterations) {
      simulation.Simulate(iterations, saveToDBButton.Checked ? obs : null);
    }

    private void PrintFitnessValues() {
      //print fitness values
      listBox1.Items.Clear();
      double[] fitnessValues = simulation.GetFitnessValues();
      for (int i = 0; i < fitnessValues.Length; i++)
        listBox1.Items.Add(fitnessValues[i]);
    }

    private void goButton_Click(object sender, EventArgs e) {
        int runs = getRuns();
        int iterations = getIterations();
        if (runs == -1 || iterations == -1)
            return;
        string[] attributeValues = new string[] {
            textBox_populationSize.Text,
            textBox_crossoverBredAmount.Text,
            textBox_mutateAfterCrossoverAmount.Text,
            textBox_mutationRate.Text,
            textBox_allowSinglePointCrossover.Text,
            textBox_allowTwoPointCrossover.Text,
            textBox_allowUniformCrossover.Text,
            comboBox_replacementRule.SelectedIndex.ToString(),
            textBox_initialMutation.Text,
            textBox_initialSimilarity.Text
        };
        GANNAI.ConfigurationParser confParser = new ConfigurationParser(attributeValues);
        double[] c;
        while ((c = confParser.getNextConfiguration()) != null) {
            simulation = new Simulation(game, (int)c[0], c[1], c[2], c[3], (int)c[4], (int)c[5], (int)c[6], (int)c[7], c[8], c[9]);
            for (int i = 0; i < runs; i++) {
                if (saveToDBButton.Checked) {
                    obs = new ObservationSaver(simulation);
                }
                StartTraining(iterations);
                progressBar1.Value = (int)(((confParser.getProgress() * (i+1)) / runs) * 100);
                obs.SaveBestBitstring(simulation.GetBest().DNA.Bitstring, simulation.GetBest().GetFitness());
            }
            PrintFitnessValues();
            visualizeButton.Enabled = true;
            generationCountLabel.Text = "Generation No: " + simulation.Population.Generation.ToString();
            diversityLabel.Text = "Diversity: " + simulation.Population.MeasureDiversity().ToString();
        }
    }

    private int getRuns() {
        int runs;
        try {
            runs = Int32.Parse(runsTextBox.Text);
        }
        catch (FormatException) {
            MessageBox.Show("Number of runs must be a positive integer");
            return -1;
        }
        if (runs <= 0) {
            MessageBox.Show("Number of runs must be a positive integer");
            return -1;
        }
        return runs;
    }

    private int getIterations(){
        int iterations;
        try {
            iterations = Int32.Parse(num_iterations.Text);
        }
        catch (FormatException) {
            MessageBox.Show("Number of iterations must be a positive integer");
            return -1;
        }
        if (iterations < 0) {
            MessageBox.Show("Number of iterations must be a positive integer or 0");
            return -1;
        }
        return iterations;
    }

    private void FallingStarsRadioButton_CheckedChanged(object sender, EventArgs e) {
      game = new FallingStarsGame();
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

    private void IncomeRadioButton_CheckedChanged(object sender, EventArgs e) {
      game = new Income();
      GameChanged();
    }

    private void SnakeRadioButton_CheckedChanged(object sender, EventArgs e) {
      game = new SnakeGame();
      GameChanged();
    }

    private void visualizeButton_Click(object sender, EventArgs e) {
      Form form = new Form();
      form.Show();
      simulation.Game.Visualize(simulation.GetBest(), form);
    }

    private void IrisRadioButton_Click(object sender, EventArgs e) {
      game = new Iris();
      GameChanged();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox_replacementRule.SelectedIndex = 0;
    }

    private void leafRadioButton_CheckedChanged(object sender, EventArgs e) {
        game = new Leaf();
        GameChanged();
    }

    private void bankruptcyRadioButton_CheckedChanged(object sender, EventArgs e) {
      game = new Bankruptcy();
        GameChanged();
    }

    private void purchaseRadioButton_CheckedChanged(object sender, EventArgs e) {
        game = new Purchase();
        GameChanged();
    }
  }
}
