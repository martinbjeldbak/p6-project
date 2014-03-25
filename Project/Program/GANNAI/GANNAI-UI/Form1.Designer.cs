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
            this.IrisRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.runsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_iterations = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.visualizeButton = new System.Windows.Forms.Button();
            this.generationCountLabel = new System.Windows.Forms.Label();
            this.saveToDBButton = new System.Windows.Forms.CheckBox();
            this.diversityLabel = new System.Windows.Forms.Label();
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
            this.goButton.Location = new System.Drawing.Point(301, 234);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 4;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IrisRadioButton);
            this.groupBox1.Controls.Add(this.BombermanRadioButton);
            this.groupBox1.Controls.Add(this.FallingStarsRadioButton);
            this.groupBox1.Controls.Add(this.SnakeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(47, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 107);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select game";
            // 
            // IrisRadioButton
            // 
            this.IrisRadioButton.AutoSize = true;
            this.IrisRadioButton.Location = new System.Drawing.Point(42, 67);
            this.IrisRadioButton.Name = "IrisRadioButton";
            this.IrisRadioButton.Size = new System.Drawing.Size(38, 17);
            this.IrisRadioButton.TabIndex = 3;
            this.IrisRadioButton.TabStop = true;
            this.IrisRadioButton.Text = "Iris";
            this.IrisRadioButton.UseVisualStyleBackColor = true;
            this.IrisRadioButton.Click += new System.EventHandler(this.IrisRadioButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.runsTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.num_iterations);
            this.groupBox2.Location = new System.Drawing.Point(47, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 70);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AI settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Runs";
            // 
            // runsTextBox
            // 
            this.runsTextBox.Location = new System.Drawing.Point(89, 29);
            this.runsTextBox.Name = "runsTextBox";
            this.runsTextBox.Size = new System.Drawing.Size(100, 20);
            this.runsTextBox.TabIndex = 8;
            this.runsTextBox.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Iterations";
            // 
            // num_iterations
            // 
            this.num_iterations.Location = new System.Drawing.Point(271, 29);
            this.num_iterations.Name = "num_iterations";
            this.num_iterations.Size = new System.Drawing.Size(100, 20);
            this.num_iterations.TabIndex = 0;
            this.num_iterations.Text = "0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(479, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 186);
            this.listBox1.TabIndex = 7;
            // 
            // visualizeButton
            // 
            this.visualizeButton.Enabled = false;
            this.visualizeButton.Location = new System.Drawing.Point(382, 234);
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
            this.generationCountLabel.Location = new System.Drawing.Point(496, 18);
            this.generationCountLabel.Name = "generationCountLabel";
            this.generationCountLabel.Size = new System.Drawing.Size(88, 13);
            this.generationCountLabel.TabIndex = 10;
            this.generationCountLabel.Text = "Generation No: 0";
            // 
            // saveToDBButton
            // 
            this.saveToDBButton.AutoSize = true;
            this.saveToDBButton.Location = new System.Drawing.Point(47, 234);
            this.saveToDBButton.Name = "saveToDBButton";
            this.saveToDBButton.Size = new System.Drawing.Size(85, 17);
            this.saveToDBButton.TabIndex = 11;
            this.saveToDBButton.Text = "Save To DB";
            this.saveToDBButton.UseVisualStyleBackColor = true;
            // 
            // diversityLabel
            // 
            this.diversityLabel.AutoSize = true;
            this.diversityLabel.Location = new System.Drawing.Point(644, 18);
            this.diversityLabel.Name = "diversityLabel";
            this.diversityLabel.Size = new System.Drawing.Size(59, 13);
            this.diversityLabel.TabIndex = 12;
            this.diversityLabel.Text = "Diversity: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 298);
            this.Controls.Add(this.diversityLabel);
            this.Controls.Add(this.saveToDBButton);
            this.Controls.Add(this.generationCountLabel);
            this.Controls.Add(this.visualizeButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.goButton);
            this.Name = "Form1";
            this.Text = "Form1";
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
    private System.Windows.Forms.Button visualizeButton;
    private System.Windows.Forms.Label generationCountLabel;
    private System.Windows.Forms.CheckBox saveToDBButton;
    private System.Windows.Forms.Label diversityLabel;
    private System.Windows.Forms.RadioButton IrisRadioButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox runsTextBox;
  }
}

