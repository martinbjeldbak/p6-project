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
            this.IncomeRadioButton = new System.Windows.Forms.RadioButton();
            this.goButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.purchaseRadioButton = new System.Windows.Forms.RadioButton();
            this.bankruptcyRadioButton = new System.Windows.Forms.RadioButton();
            this.leafRadioButton = new System.Windows.Forms.RadioButton();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_replacementRule = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_initialSimilarity = new System.Windows.Forms.TextBox();
            this.textBox_initialMutation = new System.Windows.Forms.TextBox();
            this.textBox_allowTwoPointCrossover = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_mutateAfterCrossoverAmount = new System.Windows.Forms.TextBox();
            this.textBox_allowUniformCrossover = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_crossoverBredAmount = new System.Windows.Forms.TextBox();
            this.textBox_allowSinglePointCrossover = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_mutationRate = new System.Windows.Forms.TextBox();
            this.textBox_populationSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SnakeRadioButton
            // 
            this.SnakeRadioButton.AutoSize = true;
            this.SnakeRadioButton.Checked = true;
            this.SnakeRadioButton.Location = new System.Drawing.Point(42, 22);
            this.SnakeRadioButton.Name = "SnakeRadioButton";
            this.SnakeRadioButton.Size = new System.Drawing.Size(56, 17);
            this.SnakeRadioButton.TabIndex = 0;
            this.SnakeRadioButton.TabStop = true;
            this.SnakeRadioButton.Text = "Snake";
            this.SnakeRadioButton.UseVisualStyleBackColor = true;
            this.SnakeRadioButton.CheckedChanged += new System.EventHandler(this.SnakeRadioButton_CheckedChanged);
            // 
            // FallingStarsRadioButton
            // 
            this.FallingStarsRadioButton.AutoSize = true;
            this.FallingStarsRadioButton.Location = new System.Drawing.Point(152, 22);
            this.FallingStarsRadioButton.Name = "FallingStarsRadioButton";
            this.FallingStarsRadioButton.Size = new System.Drawing.Size(82, 17);
            this.FallingStarsRadioButton.TabIndex = 1;
            this.FallingStarsRadioButton.Text = "Falling Stars";
            this.FallingStarsRadioButton.UseVisualStyleBackColor = true;
            this.FallingStarsRadioButton.CheckedChanged += new System.EventHandler(this.FallingStarsRadioButton_CheckedChanged);
            // 
            // IncomeRadioButton
            // 
            this.IncomeRadioButton.AutoSize = true;
            this.IncomeRadioButton.Location = new System.Drawing.Point(290, 22);
            this.IncomeRadioButton.Name = "IncomeRadioButton";
            this.IncomeRadioButton.Size = new System.Drawing.Size(60, 17);
            this.IncomeRadioButton.TabIndex = 2;
            this.IncomeRadioButton.Text = "Income";
            this.IncomeRadioButton.UseVisualStyleBackColor = true;
            this.IncomeRadioButton.CheckedChanged += new System.EventHandler(this.IncomeRadioButton_CheckedChanged);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(47, 413);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 4;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.purchaseRadioButton);
            this.groupBox1.Controls.Add(this.bankruptcyRadioButton);
            this.groupBox1.Controls.Add(this.leafRadioButton);
            this.groupBox1.Controls.Add(this.IrisRadioButton);
            this.groupBox1.Controls.Add(this.IncomeRadioButton);
            this.groupBox1.Controls.Add(this.FallingStarsRadioButton);
            this.groupBox1.Controls.Add(this.SnakeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(47, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 107);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select game";
            // 
            // purchaseRadioButton
            // 
            this.purchaseRadioButton.AutoSize = true;
            this.purchaseRadioButton.Location = new System.Drawing.Point(42, 68);
            this.purchaseRadioButton.Name = "purchaseRadioButton";
            this.purchaseRadioButton.Size = new System.Drawing.Size(70, 17);
            this.purchaseRadioButton.TabIndex = 6;
            this.purchaseRadioButton.Text = "Purchase";
            this.purchaseRadioButton.UseVisualStyleBackColor = true;
            this.purchaseRadioButton.CheckedChanged += new System.EventHandler(this.purchaseRadioButton_CheckedChanged);
            // 
            // bankruptcyRadioButton
            // 
            this.bankruptcyRadioButton.AutoSize = true;
            this.bankruptcyRadioButton.Location = new System.Drawing.Point(290, 45);
            this.bankruptcyRadioButton.Name = "bankruptcyRadioButton";
            this.bankruptcyRadioButton.Size = new System.Drawing.Size(79, 17);
            this.bankruptcyRadioButton.TabIndex = 5;
            this.bankruptcyRadioButton.Text = "Bankruptcy";
            this.bankruptcyRadioButton.UseVisualStyleBackColor = true;
            this.bankruptcyRadioButton.CheckedChanged += new System.EventHandler(this.bankruptcyRadioButton_CheckedChanged);
            // 
            // leafRadioButton
            // 
            this.leafRadioButton.AutoSize = true;
            this.leafRadioButton.Location = new System.Drawing.Point(152, 45);
            this.leafRadioButton.Name = "leafRadioButton";
            this.leafRadioButton.Size = new System.Drawing.Size(46, 17);
            this.leafRadioButton.TabIndex = 4;
            this.leafRadioButton.Text = "Leaf";
            this.leafRadioButton.UseVisualStyleBackColor = true;
            this.leafRadioButton.CheckedChanged += new System.EventHandler(this.leafRadioButton_CheckedChanged);
            // 
            // IrisRadioButton
            // 
            this.IrisRadioButton.AutoSize = true;
            this.IrisRadioButton.Location = new System.Drawing.Point(42, 45);
            this.IrisRadioButton.Name = "IrisRadioButton";
            this.IrisRadioButton.Size = new System.Drawing.Size(38, 17);
            this.IrisRadioButton.TabIndex = 3;
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
            this.groupBox2.Location = new System.Drawing.Point(47, 150);
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
            this.listBox1.Size = new System.Drawing.Size(244, 160);
            this.listBox1.TabIndex = 7;
            // 
            // visualizeButton
            // 
            this.visualizeButton.Enabled = false;
            this.visualizeButton.Location = new System.Drawing.Point(567, 200);
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
            this.saveToDBButton.Location = new System.Drawing.Point(177, 417);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_replacementRule);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_initialSimilarity);
            this.groupBox3.Controls.Add(this.textBox_initialMutation);
            this.groupBox3.Controls.Add(this.textBox_allowTwoPointCrossover);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox_mutateAfterCrossoverAmount);
            this.groupBox3.Controls.Add(this.textBox_allowUniformCrossover);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_crossoverBredAmount);
            this.groupBox3.Controls.Add(this.textBox_allowSinglePointCrossover);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_mutationRate);
            this.groupBox3.Controls.Add(this.textBox_populationSize);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(47, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(676, 155);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // comboBox_replacementRule
            // 
            this.comboBox_replacementRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_replacementRule.FormattingEnabled = true;
            this.comboBox_replacementRule.Items.AddRange(new object[] {
            "Naive",
            "Ancestor Elitism",
            "Ancestor Elitism Random Immigrants",
            "Single Parent Elitism"});
            this.comboBox_replacementRule.Location = new System.Drawing.Point(350, 45);
            this.comboBox_replacementRule.Name = "comboBox_replacementRule";
            this.comboBox_replacementRule.Size = new System.Drawing.Size(171, 21);
            this.comboBox_replacementRule.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(527, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Replacement rule";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(527, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Allow two point crossover";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Initial mutation";
            // 
            // textBox_initialSimilarity
            // 
            this.textBox_initialSimilarity.Location = new System.Drawing.Point(350, 20);
            this.textBox_initialSimilarity.Name = "textBox_initialSimilarity";
            this.textBox_initialSimilarity.Size = new System.Drawing.Size(171, 20);
            this.textBox_initialSimilarity.TabIndex = 40;
            this.textBox_initialSimilarity.Text = "0";
            // 
            // textBox_initialMutation
            // 
            this.textBox_initialMutation.Location = new System.Drawing.Point(43, 123);
            this.textBox_initialMutation.Name = "textBox_initialMutation";
            this.textBox_initialMutation.Size = new System.Drawing.Size(100, 20);
            this.textBox_initialMutation.TabIndex = 38;
            this.textBox_initialMutation.Text = "0";
            // 
            // textBox_allowTwoPointCrossover
            // 
            this.textBox_allowTwoPointCrossover.Location = new System.Drawing.Point(350, 97);
            this.textBox_allowTwoPointCrossover.Name = "textBox_allowTwoPointCrossover";
            this.textBox_allowTwoPointCrossover.Size = new System.Drawing.Size(171, 20);
            this.textBox_allowTwoPointCrossover.TabIndex = 46;
            this.textBox_allowTwoPointCrossover.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Mutate after crossover amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(527, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Initial similarity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Allow single point crossover";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Crossover bred amount";
            // 
            // textBox_mutateAfterCrossoverAmount
            // 
            this.textBox_mutateAfterCrossoverAmount.Location = new System.Drawing.Point(42, 71);
            this.textBox_mutateAfterCrossoverAmount.Name = "textBox_mutateAfterCrossoverAmount";
            this.textBox_mutateAfterCrossoverAmount.Size = new System.Drawing.Size(100, 20);
            this.textBox_mutateAfterCrossoverAmount.TabIndex = 36;
            this.textBox_mutateAfterCrossoverAmount.Text = "0.1";
            // 
            // textBox_allowUniformCrossover
            // 
            this.textBox_allowUniformCrossover.Location = new System.Drawing.Point(350, 123);
            this.textBox_allowUniformCrossover.Name = "textBox_allowUniformCrossover";
            this.textBox_allowUniformCrossover.Size = new System.Drawing.Size(171, 20);
            this.textBox_allowUniformCrossover.TabIndex = 42;
            this.textBox_allowUniformCrossover.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(527, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Allow uniform crossover";
            // 
            // textBox_crossoverBredAmount
            // 
            this.textBox_crossoverBredAmount.Location = new System.Drawing.Point(43, 45);
            this.textBox_crossoverBredAmount.Name = "textBox_crossoverBredAmount";
            this.textBox_crossoverBredAmount.Size = new System.Drawing.Size(100, 20);
            this.textBox_crossoverBredAmount.TabIndex = 34;
            this.textBox_crossoverBredAmount.Text = "0.5";
            // 
            // textBox_allowSinglePointCrossover
            // 
            this.textBox_allowSinglePointCrossover.Location = new System.Drawing.Point(350, 71);
            this.textBox_allowSinglePointCrossover.Name = "textBox_allowSinglePointCrossover";
            this.textBox_allowSinglePointCrossover.Size = new System.Drawing.Size(171, 20);
            this.textBox_allowSinglePointCrossover.TabIndex = 44;
            this.textBox_allowSinglePointCrossover.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Mutation rate";
            // 
            // textBox_mutationRate
            // 
            this.textBox_mutationRate.Location = new System.Drawing.Point(43, 97);
            this.textBox_mutationRate.Name = "textBox_mutationRate";
            this.textBox_mutationRate.Size = new System.Drawing.Size(100, 20);
            this.textBox_mutationRate.TabIndex = 32;
            this.textBox_mutationRate.Text = "0.05";
            // 
            // textBox_populationSize
            // 
            this.textBox_populationSize.Location = new System.Drawing.Point(43, 20);
            this.textBox_populationSize.Name = "textBox_populationSize";
            this.textBox_populationSize.Size = new System.Drawing.Size(100, 20);
            this.textBox_populationSize.TabIndex = 30;
            this.textBox_populationSize.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Population size";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(531, 413);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(192, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 446);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton SnakeRadioButton;
    private System.Windows.Forms.RadioButton FallingStarsRadioButton;
    private System.Windows.Forms.RadioButton IncomeRadioButton;
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
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox textBox_initialSimilarity;
    private System.Windows.Forms.TextBox textBox_initialMutation;
    private System.Windows.Forms.TextBox textBox_allowTwoPointCrossover;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox textBox_mutateAfterCrossoverAmount;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox_allowUniformCrossover;
    private System.Windows.Forms.TextBox textBox_crossoverBredAmount;
    private System.Windows.Forms.TextBox textBox_allowSinglePointCrossover;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox textBox_mutationRate;
    private System.Windows.Forms.TextBox textBox_populationSize;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.RadioButton leafRadioButton;
    private System.Windows.Forms.RadioButton bankruptcyRadioButton;
    private System.Windows.Forms.RadioButton purchaseRadioButton;
    private System.Windows.Forms.ComboBox comboBox_replacementRule;
  }
}

