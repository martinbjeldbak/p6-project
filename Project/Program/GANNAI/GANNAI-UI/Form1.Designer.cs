namespace GANNAIUI {
  partial class Form1 {

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.SnakeRadioButton = new System.Windows.Forms.RadioButton();
      this.FallingStarsRadioButton = new System.Windows.Forms.RadioButton();
      this.BombermanRadioButton = new System.Windows.Forms.RadioButton();
      this.goButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.num_iterations = new System.Windows.Forms.TextBox();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.continueButton = new System.Windows.Forms.Button();
      this.visualizeButton = new System.Windows.Forms.Button();
      this.generationCountLabel = new System.Windows.Forms.Label();
      this.measurePerformanceButton = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // SnakeRadioButton
      // 
      this.SnakeRadioButton.AutoSize = true;
      this.SnakeRadioButton.Location = new System.Drawing.Point(42, 29);
      this.SnakeRadioButton.Name = "SnakeRadioButton";
      this.SnakeRadioButton.Size = new System.Drawing.Size(56, 17);
      this.SnakeRadioButton.TabIndex = 0;
      this.SnakeRadioButton.Text = "Snake";
      this.SnakeRadioButton.UseVisualStyleBackColor = true;
      this.SnakeRadioButton.CheckedChanged += new System.EventHandler(this.SnakeRadioButton_CheckedChanged);
      // 
      // FallingStarsRadioButton
      // 
      this.FallingStarsRadioButton.AutoSize = true;
      this.FallingStarsRadioButton.Location = new System.Drawing.Point(152, 29);
      this.FallingStarsRadioButton.Name = "FallingStarsRadioButton";
      this.FallingStarsRadioButton.Size = new System.Drawing.Size(82, 17);
      this.FallingStarsRadioButton.TabIndex = 1;
      this.FallingStarsRadioButton.Text = "Falling Stars";
      this.FallingStarsRadioButton.UseVisualStyleBackColor = true;
      this.FallingStarsRadioButton.CheckedChanged += new System.EventHandler(this.FallingStarsRadioButton_CheckedChanged);
      // 
      // BombermanRadioButton
      // 
      this.BombermanRadioButton.AutoSize = true;
      this.BombermanRadioButton.Location = new System.Drawing.Point(290, 29);
      this.BombermanRadioButton.Name = "BombermanRadioButton";
      this.BombermanRadioButton.Size = new System.Drawing.Size(81, 17);
      this.BombermanRadioButton.TabIndex = 2;
      this.BombermanRadioButton.Text = "Bomberman";
      this.BombermanRadioButton.UseVisualStyleBackColor = true;
      this.BombermanRadioButton.CheckedChanged += new System.EventHandler(this.BombermanRadioButton_CheckedChanged);
      // 
      // goButton
      // 
      this.goButton.Enabled = false;
      this.goButton.Location = new System.Drawing.Point(220, 197);
      this.goButton.Name = "goButton";
      this.goButton.Size = new System.Drawing.Size(75, 23);
      this.goButton.TabIndex = 4;
      this.goButton.Text = "Go";
      this.goButton.UseVisualStyleBackColor = true;
      this.goButton.Click += new System.EventHandler(this.goButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.BombermanRadioButton);
      this.groupBox1.Controls.Add(this.FallingStarsRadioButton);
      this.groupBox1.Controls.Add(this.SnakeRadioButton);
      this.groupBox1.Location = new System.Drawing.Point(47, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(410, 78);
      this.groupBox1.TabIndex = 5;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Select game";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.num_iterations);
      this.groupBox2.Location = new System.Drawing.Point(47, 111);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(410, 70);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "AI settings";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(93, 32);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Iterations";
      // 
      // num_iterations
      // 
      this.num_iterations.Location = new System.Drawing.Point(149, 29);
      this.num_iterations.Name = "num_iterations";
      this.num_iterations.Size = new System.Drawing.Size(100, 20);
      this.num_iterations.TabIndex = 0;
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(479, 34);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(244, 186);
      this.listBox1.TabIndex = 7;
      // 
      // continueButton
      // 
      this.continueButton.Enabled = false;
      this.continueButton.Location = new System.Drawing.Point(301, 197);
      this.continueButton.Name = "continueButton";
      this.continueButton.Size = new System.Drawing.Size(75, 23);
      this.continueButton.TabIndex = 8;
      this.continueButton.Text = "Continue";
      this.continueButton.UseVisualStyleBackColor = true;
      this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
      // 
      // visualizeButton
      // 
      this.visualizeButton.Enabled = false;
      this.visualizeButton.Location = new System.Drawing.Point(382, 197);
      this.visualizeButton.Name = "visualizeButton";
      this.visualizeButton.Size = new System.Drawing.Size(75, 23);
      this.visualizeButton.TabIndex = 9;
      this.visualizeButton.Text = "Visualize";
      this.visualizeButton.UseVisualStyleBackColor = true;
      this.visualizeButton.Click += new System.EventHandler(this.visualizeButton_Click);
      // 
      // generationCountLabel
      // 
      this.generationCountLabel.AutoSize = true;
      this.generationCountLabel.Location = new System.Drawing.Point(559, 12);
      this.generationCountLabel.Name = "generationCountLabel";
      this.generationCountLabel.Size = new System.Drawing.Size(68, 13);
      this.generationCountLabel.TabIndex = 10;
      this.generationCountLabel.Text = "Generation 0";
      // 
      // measurePerformanceButton
      // 
      this.measurePerformanceButton.Location = new System.Drawing.Point(47, 197);
      this.measurePerformanceButton.Name = "measurePerformanceButton";
      this.measurePerformanceButton.Size = new System.Drawing.Size(131, 23);
      this.measurePerformanceButton.TabIndex = 11;
      this.measurePerformanceButton.Text = "Mesaure Performance";
      this.measurePerformanceButton.UseVisualStyleBackColor = true;
      this.measurePerformanceButton.Click += new System.EventHandler(this.measurePerformanceButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(741, 236);
      this.Controls.Add(this.measurePerformanceButton);
      this.Controls.Add(this.generationCountLabel);
      this.Controls.Add(this.visualizeButton);
      this.Controls.Add(this.continueButton);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.goButton);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton SnakeRadioButton;
    private System.Windows.Forms.RadioButton FallingStarsRadioButton;
    private System.Windows.Forms.RadioButton BombermanRadioButton;
    private System.Windows.Forms.Button goButton;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox num_iterations;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button continueButton;
    private System.Windows.Forms.Button visualizeButton;
    private System.Windows.Forms.Label generationCountLabel;
    private System.Windows.Forms.Button measurePerformanceButton;
  }
}

