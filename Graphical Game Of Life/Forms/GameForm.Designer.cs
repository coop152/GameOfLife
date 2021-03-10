namespace Graphical_Game_Of_Life
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.outerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.renderPictureBox = new System.Windows.Forms.PictureBox();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rowBoxLabel = new System.Windows.Forms.Label();
            this.rowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnBoxLabel = new System.Windows.Forms.Label();
            this.columnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HorizontalSeperator = new System.Windows.Forms.Label();
            this.GameTypeComboBox = new System.Windows.Forms.ComboBox();
            this.UnderpopulationThresholdLabel = new System.Windows.Forms.Label();
            this.UnderpopulationThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.RebirthThresholdLabel = new System.Windows.Forms.Label();
            this.RebirthThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.OverpopulationThresholdLabel = new System.Windows.Forms.Label();
            this.OverpopulationThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.cellColourButton = new System.Windows.Forms.Button();
            this.gridOffCheckbox = new System.Windows.Forms.CheckBox();
            this.HorizontalSeperator2 = new System.Windows.Forms.Label();
            this.advanceButton = new System.Windows.Forms.Button();
            this.autoAdvanceCheckbox = new System.Windows.Forms.CheckBox();
            this.timePauseLabel = new System.Windows.Forms.Label();
            this.timePauseUpDown = new System.Windows.Forms.NumericUpDown();
            this.bottomOptionsPanel = new System.Windows.Forms.Panel();
            this.bottomOptionsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SavegameListBox = new System.Windows.Forms.ListBox();
            this.saveGameButton = new System.Windows.Forms.Button();
            this.loadGameButton = new System.Windows.Forms.Button();
            this.deleteSaveButton = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.ShareSaveButton = new System.Windows.Forms.Button();
            this.outerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.renderPictureBox)).BeginInit();
            this.optionsPanel.SuspendLayout();
            this.optionsFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderpopulationThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RebirthThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverpopulationThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePauseUpDown)).BeginInit();
            this.bottomOptionsPanel.SuspendLayout();
            this.bottomOptionsFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // outerLayoutPanel
            // 
            this.outerLayoutPanel.ColumnCount = 2;
            this.outerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.outerLayoutPanel.Controls.Add(this.renderPictureBox, 0, 0);
            this.outerLayoutPanel.Controls.Add(this.optionsPanel, 1, 0);
            this.outerLayoutPanel.Controls.Add(this.bottomOptionsPanel, 1, 1);
            this.outerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.outerLayoutPanel.Name = "outerLayoutPanel";
            this.outerLayoutPanel.RowCount = 2;
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.outerLayoutPanel.Size = new System.Drawing.Size(784, 656);
            this.outerLayoutPanel.TabIndex = 0;
            // 
            // renderPictureBox
            // 
            this.renderPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderPictureBox.Location = new System.Drawing.Point(3, 3);
            this.renderPictureBox.Name = "renderPictureBox";
            this.outerLayoutPanel.SetRowSpan(this.renderPictureBox, 2);
            this.renderPictureBox.Size = new System.Drawing.Size(650, 650);
            this.renderPictureBox.TabIndex = 4;
            this.renderPictureBox.TabStop = false;
            this.renderPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.renderPictureBox_Paint);
            this.renderPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.renderPictureBox_MouseDown);
            this.renderPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.renderPictureBox_MouseMove);
            this.renderPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.renderPictureBox_MouseUp);
            this.renderPictureBox.Resize += new System.EventHandler(this.renderPictureBox_Resize);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.optionsFlowPanel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(659, 3);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(122, 395);
            this.optionsPanel.TabIndex = 1;
            // 
            // optionsFlowPanel
            // 
            this.optionsFlowPanel.Controls.Add(this.rowBoxLabel);
            this.optionsFlowPanel.Controls.Add(this.rowNumericUpDown);
            this.optionsFlowPanel.Controls.Add(this.columnBoxLabel);
            this.optionsFlowPanel.Controls.Add(this.columnNumericUpDown);
            this.optionsFlowPanel.Controls.Add(this.HorizontalSeperator);
            this.optionsFlowPanel.Controls.Add(this.GameTypeComboBox);
            this.optionsFlowPanel.Controls.Add(this.UnderpopulationThresholdLabel);
            this.optionsFlowPanel.Controls.Add(this.UnderpopulationThresholdUpDown);
            this.optionsFlowPanel.Controls.Add(this.RebirthThresholdLabel);
            this.optionsFlowPanel.Controls.Add(this.RebirthThresholdUpDown);
            this.optionsFlowPanel.Controls.Add(this.OverpopulationThresholdLabel);
            this.optionsFlowPanel.Controls.Add(this.OverpopulationThresholdUpDown);
            this.optionsFlowPanel.Controls.Add(this.cellColourButton);
            this.optionsFlowPanel.Controls.Add(this.gridOffCheckbox);
            this.optionsFlowPanel.Controls.Add(this.HorizontalSeperator2);
            this.optionsFlowPanel.Controls.Add(this.advanceButton);
            this.optionsFlowPanel.Controls.Add(this.autoAdvanceCheckbox);
            this.optionsFlowPanel.Controls.Add(this.timePauseLabel);
            this.optionsFlowPanel.Controls.Add(this.timePauseUpDown);
            this.optionsFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.optionsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsFlowPanel.Name = "optionsFlowPanel";
            this.optionsFlowPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.optionsFlowPanel.Size = new System.Drawing.Size(120, 393);
            this.optionsFlowPanel.TabIndex = 0;
            // 
            // rowBoxLabel
            // 
            this.rowBoxLabel.AutoSize = true;
            this.rowBoxLabel.Location = new System.Drawing.Point(3, 3);
            this.rowBoxLabel.Name = "rowBoxLabel";
            this.rowBoxLabel.Size = new System.Drawing.Size(34, 13);
            this.rowBoxLabel.TabIndex = 0;
            this.rowBoxLabel.Text = "Rows";
            // 
            // rowNumericUpDown
            // 
            this.rowNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rowNumericUpDown.Location = new System.Drawing.Point(3, 19);
            this.rowNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowNumericUpDown.Name = "rowNumericUpDown";
            this.rowNumericUpDown.Size = new System.Drawing.Size(114, 20);
            this.rowNumericUpDown.TabIndex = 0;
            this.rowNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.rowNumericUpDown.ValueChanged += new System.EventHandler(this.rowOrColumnCountChanged);
            // 
            // columnBoxLabel
            // 
            this.columnBoxLabel.AutoSize = true;
            this.columnBoxLabel.Location = new System.Drawing.Point(3, 42);
            this.columnBoxLabel.Name = "columnBoxLabel";
            this.columnBoxLabel.Size = new System.Drawing.Size(47, 13);
            this.columnBoxLabel.TabIndex = 1;
            this.columnBoxLabel.Text = "Columns";
            // 
            // columnNumericUpDown
            // 
            this.columnNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.columnNumericUpDown.Location = new System.Drawing.Point(3, 58);
            this.columnNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnNumericUpDown.Name = "columnNumericUpDown";
            this.columnNumericUpDown.Size = new System.Drawing.Size(114, 20);
            this.columnNumericUpDown.TabIndex = 2;
            this.columnNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.columnNumericUpDown.ValueChanged += new System.EventHandler(this.rowOrColumnCountChanged);
            // 
            // HorizontalSeperator
            // 
            this.HorizontalSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HorizontalSeperator.Location = new System.Drawing.Point(3, 84);
            this.HorizontalSeperator.Margin = new System.Windows.Forms.Padding(3);
            this.HorizontalSeperator.Name = "HorizontalSeperator";
            this.HorizontalSeperator.Size = new System.Drawing.Size(114, 1);
            this.HorizontalSeperator.TabIndex = 5;
            // 
            // GameTypeComboBox
            // 
            this.GameTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameTypeComboBox.FormattingEnabled = true;
            this.GameTypeComboBox.Items.AddRange(new object[] {
            "Game of Life",
            "HighLife",
            "PlusLife (Cross-Shaped Neighbourhood)",
            "Custom Rules"});
            this.GameTypeComboBox.Location = new System.Drawing.Point(3, 91);
            this.GameTypeComboBox.Name = "GameTypeComboBox";
            this.GameTypeComboBox.Size = new System.Drawing.Size(114, 21);
            this.GameTypeComboBox.TabIndex = 18;
            this.GameTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.GameTypeComboBox_SelectedIndexChanged);
            // 
            // UnderpopulationThresholdLabel
            // 
            this.UnderpopulationThresholdLabel.AutoSize = true;
            this.UnderpopulationThresholdLabel.Location = new System.Drawing.Point(3, 115);
            this.UnderpopulationThresholdLabel.Name = "UnderpopulationThresholdLabel";
            this.UnderpopulationThresholdLabel.Size = new System.Drawing.Size(108, 13);
            this.UnderpopulationThresholdLabel.TabIndex = 12;
            this.UnderpopulationThresholdLabel.Text = "Death if neighbours <";
            // 
            // UnderpopulationThresholdUpDown
            // 
            this.UnderpopulationThresholdUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UnderpopulationThresholdUpDown.Enabled = false;
            this.UnderpopulationThresholdUpDown.Location = new System.Drawing.Point(3, 131);
            this.UnderpopulationThresholdUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.UnderpopulationThresholdUpDown.Name = "UnderpopulationThresholdUpDown";
            this.UnderpopulationThresholdUpDown.Size = new System.Drawing.Size(114, 20);
            this.UnderpopulationThresholdUpDown.TabIndex = 13;
            this.UnderpopulationThresholdUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.UnderpopulationThresholdUpDown.ValueChanged += new System.EventHandler(this.ThresholdsChanged);
            // 
            // RebirthThresholdLabel
            // 
            this.RebirthThresholdLabel.AutoSize = true;
            this.RebirthThresholdLabel.Location = new System.Drawing.Point(3, 154);
            this.RebirthThresholdLabel.Name = "RebirthThresholdLabel";
            this.RebirthThresholdLabel.Size = new System.Drawing.Size(113, 13);
            this.RebirthThresholdLabel.TabIndex = 14;
            this.RebirthThresholdLabel.Text = "Rebirth if neighbours =";
            // 
            // RebirthThresholdUpDown
            // 
            this.RebirthThresholdUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RebirthThresholdUpDown.Enabled = false;
            this.RebirthThresholdUpDown.Location = new System.Drawing.Point(3, 170);
            this.RebirthThresholdUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.RebirthThresholdUpDown.Name = "RebirthThresholdUpDown";
            this.RebirthThresholdUpDown.Size = new System.Drawing.Size(114, 20);
            this.RebirthThresholdUpDown.TabIndex = 15;
            this.RebirthThresholdUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RebirthThresholdUpDown.ValueChanged += new System.EventHandler(this.ThresholdsChanged);
            // 
            // OverpopulationThresholdLabel
            // 
            this.OverpopulationThresholdLabel.AutoSize = true;
            this.OverpopulationThresholdLabel.Location = new System.Drawing.Point(3, 193);
            this.OverpopulationThresholdLabel.Name = "OverpopulationThresholdLabel";
            this.OverpopulationThresholdLabel.Size = new System.Drawing.Size(108, 13);
            this.OverpopulationThresholdLabel.TabIndex = 16;
            this.OverpopulationThresholdLabel.Text = "Death if neighbours >";
            // 
            // OverpopulationThresholdUpDown
            // 
            this.OverpopulationThresholdUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OverpopulationThresholdUpDown.Enabled = false;
            this.OverpopulationThresholdUpDown.Location = new System.Drawing.Point(3, 209);
            this.OverpopulationThresholdUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.OverpopulationThresholdUpDown.Name = "OverpopulationThresholdUpDown";
            this.OverpopulationThresholdUpDown.Size = new System.Drawing.Size(114, 20);
            this.OverpopulationThresholdUpDown.TabIndex = 17;
            this.OverpopulationThresholdUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.OverpopulationThresholdUpDown.ValueChanged += new System.EventHandler(this.ThresholdsChanged);
            // 
            // cellColourButton
            // 
            this.cellColourButton.Location = new System.Drawing.Point(3, 235);
            this.cellColourButton.Name = "cellColourButton";
            this.cellColourButton.Size = new System.Drawing.Size(114, 23);
            this.cellColourButton.TabIndex = 10;
            this.cellColourButton.Text = "Cell Colour";
            this.cellColourButton.UseVisualStyleBackColor = true;
            this.cellColourButton.Click += new System.EventHandler(this.cellColourButton_Click);
            // 
            // gridOffCheckbox
            // 
            this.gridOffCheckbox.AutoSize = true;
            this.gridOffCheckbox.Location = new System.Drawing.Point(3, 264);
            this.gridOffCheckbox.Name = "gridOffCheckbox";
            this.gridOffCheckbox.Size = new System.Drawing.Size(62, 17);
            this.gridOffCheckbox.TabIndex = 2;
            this.gridOffCheckbox.Text = "No Grid";
            this.gridOffCheckbox.UseVisualStyleBackColor = true;
            this.gridOffCheckbox.CheckedChanged += new System.EventHandler(this.gridOffCheckbox_CheckedChanged);
            // 
            // HorizontalSeperator2
            // 
            this.HorizontalSeperator2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HorizontalSeperator2.Location = new System.Drawing.Point(3, 287);
            this.HorizontalSeperator2.Margin = new System.Windows.Forms.Padding(3);
            this.HorizontalSeperator2.Name = "HorizontalSeperator2";
            this.HorizontalSeperator2.Size = new System.Drawing.Size(114, 1);
            this.HorizontalSeperator2.TabIndex = 11;
            // 
            // advanceButton
            // 
            this.advanceButton.Location = new System.Drawing.Point(3, 294);
            this.advanceButton.Name = "advanceButton";
            this.advanceButton.Size = new System.Drawing.Size(114, 23);
            this.advanceButton.TabIndex = 4;
            this.advanceButton.Text = "Next Turn";
            this.advanceButton.UseVisualStyleBackColor = true;
            this.advanceButton.Click += new System.EventHandler(this.advanceButton_Click);
            // 
            // autoAdvanceCheckbox
            // 
            this.autoAdvanceCheckbox.AutoSize = true;
            this.autoAdvanceCheckbox.Location = new System.Drawing.Point(3, 323);
            this.autoAdvanceCheckbox.Name = "autoAdvanceCheckbox";
            this.autoAdvanceCheckbox.Size = new System.Drawing.Size(94, 17);
            this.autoAdvanceCheckbox.TabIndex = 8;
            this.autoAdvanceCheckbox.Text = "Auto-Advance";
            this.autoAdvanceCheckbox.UseVisualStyleBackColor = true;
            this.autoAdvanceCheckbox.CheckedChanged += new System.EventHandler(this.autoAdvanceCheckbox_CheckedChanged);
            // 
            // timePauseLabel
            // 
            this.timePauseLabel.AutoSize = true;
            this.timePauseLabel.Location = new System.Drawing.Point(3, 343);
            this.timePauseLabel.Name = "timePauseLabel";
            this.timePauseLabel.Size = new System.Drawing.Size(67, 13);
            this.timePauseLabel.TabIndex = 6;
            this.timePauseLabel.Text = "Auto Interval";
            // 
            // timePauseUpDown
            // 
            this.timePauseUpDown.DecimalPlaces = 2;
            this.timePauseUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.timePauseUpDown.Location = new System.Drawing.Point(3, 359);
            this.timePauseUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timePauseUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.timePauseUpDown.Name = "timePauseUpDown";
            this.timePauseUpDown.Size = new System.Drawing.Size(114, 20);
            this.timePauseUpDown.TabIndex = 7;
            this.timePauseUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // bottomOptionsPanel
            // 
            this.bottomOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomOptionsPanel.Controls.Add(this.bottomOptionsFlowPanel);
            this.bottomOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomOptionsPanel.Location = new System.Drawing.Point(659, 404);
            this.bottomOptionsPanel.Name = "bottomOptionsPanel";
            this.bottomOptionsPanel.Size = new System.Drawing.Size(122, 249);
            this.bottomOptionsPanel.TabIndex = 3;
            // 
            // bottomOptionsFlowPanel
            // 
            this.bottomOptionsFlowPanel.Controls.Add(this.SavegameListBox);
            this.bottomOptionsFlowPanel.Controls.Add(this.saveGameButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.loadGameButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.deleteSaveButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.newGameButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.ShareSaveButton);
            this.bottomOptionsFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomOptionsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.bottomOptionsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomOptionsFlowPanel.Name = "bottomOptionsFlowPanel";
            this.bottomOptionsFlowPanel.Size = new System.Drawing.Size(120, 247);
            this.bottomOptionsFlowPanel.TabIndex = 0;
            // 
            // SavegameListBox
            // 
            this.SavegameListBox.FormattingEnabled = true;
            this.SavegameListBox.Location = new System.Drawing.Point(3, 3);
            this.SavegameListBox.Name = "SavegameListBox";
            this.SavegameListBox.Size = new System.Drawing.Size(114, 95);
            this.SavegameListBox.TabIndex = 3;
            // 
            // saveGameButton
            // 
            this.saveGameButton.Location = new System.Drawing.Point(3, 104);
            this.saveGameButton.Name = "saveGameButton";
            this.saveGameButton.Size = new System.Drawing.Size(114, 23);
            this.saveGameButton.TabIndex = 5;
            this.saveGameButton.Text = "Save";
            this.saveGameButton.UseVisualStyleBackColor = true;
            this.saveGameButton.Click += new System.EventHandler(this.SaveGameButton_Click);
            // 
            // loadGameButton
            // 
            this.loadGameButton.Location = new System.Drawing.Point(3, 133);
            this.loadGameButton.Name = "loadGameButton";
            this.loadGameButton.Size = new System.Drawing.Size(114, 23);
            this.loadGameButton.TabIndex = 7;
            this.loadGameButton.Text = "Load";
            this.loadGameButton.UseVisualStyleBackColor = true;
            this.loadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // deleteSaveButton
            // 
            this.deleteSaveButton.Location = new System.Drawing.Point(3, 162);
            this.deleteSaveButton.Name = "deleteSaveButton";
            this.deleteSaveButton.Size = new System.Drawing.Size(114, 23);
            this.deleteSaveButton.TabIndex = 8;
            this.deleteSaveButton.Text = "Delete";
            this.deleteSaveButton.UseVisualStyleBackColor = true;
            this.deleteSaveButton.Click += new System.EventHandler(this.deleteSaveButton_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(3, 191);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(114, 23);
            this.newGameButton.TabIndex = 10;
            this.newGameButton.Text = "New";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // ShareSaveButton
            // 
            this.ShareSaveButton.Location = new System.Drawing.Point(3, 220);
            this.ShareSaveButton.Name = "ShareSaveButton";
            this.ShareSaveButton.Size = new System.Drawing.Size(114, 23);
            this.ShareSaveButton.TabIndex = 9;
            this.ShareSaveButton.Text = "Share with User...";
            this.ShareSaveButton.UseVisualStyleBackColor = true;
            this.ShareSaveButton.Click += new System.EventHandler(this.ShareSaveButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 656);
            this.Controls.Add(this.outerLayoutPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GameForm";
            this.Text = "Game of Life";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.outerLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.renderPictureBox)).EndInit();
            this.optionsPanel.ResumeLayout(false);
            this.optionsFlowPanel.ResumeLayout(false);
            this.optionsFlowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderpopulationThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RebirthThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverpopulationThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePauseUpDown)).EndInit();
            this.bottomOptionsPanel.ResumeLayout(false);
            this.bottomOptionsFlowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel outerLayoutPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.FlowLayoutPanel optionsFlowPanel;
        private System.Windows.Forms.Label rowBoxLabel;
        private System.Windows.Forms.NumericUpDown rowNumericUpDown;
        private System.Windows.Forms.Label columnBoxLabel;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown;
        private System.Windows.Forms.Label HorizontalSeperator;
        private System.Windows.Forms.Button advanceButton;
        private System.Windows.Forms.Label timePauseLabel;
        private System.Windows.Forms.NumericUpDown timePauseUpDown;
        private System.Windows.Forms.CheckBox autoAdvanceCheckbox;
        private System.Windows.Forms.Panel bottomOptionsPanel;
        private System.Windows.Forms.FlowLayoutPanel bottomOptionsFlowPanel;
        private System.Windows.Forms.CheckBox gridOffCheckbox;
        private System.Windows.Forms.ListBox SavegameListBox;
        private System.Windows.Forms.Button loadGameButton;
        private System.Windows.Forms.Button saveGameButton;
        private System.Windows.Forms.Button cellColourButton;
        private System.Windows.Forms.Button deleteSaveButton;
        private System.Windows.Forms.Button ShareSaveButton;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.PictureBox renderPictureBox;
        private System.Windows.Forms.Label HorizontalSeperator2;
        private System.Windows.Forms.Label UnderpopulationThresholdLabel;
        private System.Windows.Forms.NumericUpDown UnderpopulationThresholdUpDown;
        private System.Windows.Forms.Label RebirthThresholdLabel;
        private System.Windows.Forms.NumericUpDown RebirthThresholdUpDown;
        private System.Windows.Forms.Label OverpopulationThresholdLabel;
        private System.Windows.Forms.NumericUpDown OverpopulationThresholdUpDown;
        private System.Windows.Forms.ComboBox GameTypeComboBox;
    }
}

