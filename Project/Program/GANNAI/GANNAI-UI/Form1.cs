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
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void button1_Click(object sender, EventArgs e) {
      int iterations;
      try {
        iterations = Int32.Parse(num_iterations.Text);
      }
      catch (FormatException){
        MessageBox.Show("Number of iterations must be a positive integer");
        return;
      }
      if (iterations <= 0) {
        MessageBox.Show("Number of iterations must be a positive integer");
        return;
      }

      AITrainableGame game = new FallingStarsGame();
      AITrainer aiTrainer = new AITrainer();
      AIPlayer aiplayer = aiTrainer.TrainAIPlayer(game, iterations);
      Form form = new Form();
      game.Visualize(aiplayer, new Form());
    }
  }
}
