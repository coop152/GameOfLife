﻿namespace Graphical_Game_Of_Life
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.renderPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rowBoxLabel = new System.Windows.Forms.Label();
            this.rowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.columnBoxLabel = new System.Windows.Forms.Label();
            this.columnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dragModeCheckbox = new System.Windows.Forms.CheckBox();
            this.HorizontalSeperator = new System.Windows.Forms.Label();
            this.advanceButton = new System.Windows.Forms.Button();
            this.timePauseLabel = new System.Windows.Forms.Label();
            this.timePauseUpDown = new System.Windows.Forms.NumericUpDown();
            this.autoAdvanceCheckbox = new System.Windows.Forms.CheckBox();
            this.gridOffCheckbox = new System.Windows.Forms.CheckBox();
            this.cellColourButton = new System.Windows.Forms.Button();
            this.bottomOptionsPanel = new System.Windows.Forms.Panel();
            this.bottomOptionsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SavegameListBox = new System.Windows.Forms.ListBox();
            this.loadGameButton = new System.Windows.Forms.Button();
            this.saveGameButton = new System.Windows.Forms.Button();
            this.deleteSaveButton = new System.Windows.Forms.Button();
            this.ShareSaveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.optionsFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePauseUpDown)).BeginInit();
            this.bottomOptionsPanel.SuspendLayout();
            this.bottomOptionsFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.Controls.Add(this.renderPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.optionsPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bottomOptionsPanel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.17683F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.82317F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 656);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // renderPanel
            // 
            this.renderPanel.BackColor = System.Drawing.Color.White;
            this.renderPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.renderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.renderPanel.Location = new System.Drawing.Point(3, 3);
            this.renderPanel.Name = "renderPanel";
            this.renderPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.SetRowSpan(this.renderPanel, 2);
            this.renderPanel.Size = new System.Drawing.Size(650, 650);
            this.renderPanel.TabIndex = 2;
            this.renderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.renderPanel_Paint);
            this.renderPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.renderPanel_MouseClick);
            this.renderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.renderPanel_MouseDown);
            this.renderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.renderPanel_MouseMove);
            this.renderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.renderPanel_MouseUp);
            this.renderPanel.Resize += new System.EventHandler(this.renderPanel_Resize);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.optionsFlowPanel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(659, 3);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(122, 414);
            this.optionsPanel.TabIndex = 1;
            // 
            // optionsFlowPanel
            // 
            this.optionsFlowPanel.Controls.Add(this.rowBoxLabel);
            this.optionsFlowPanel.Controls.Add(this.rowNumericUpDown);
            this.optionsFlowPanel.Controls.Add(this.columnBoxLabel);
            this.optionsFlowPanel.Controls.Add(this.columnNumericUpDown);
            this.optionsFlowPanel.Controls.Add(this.dragModeCheckbox);
            this.optionsFlowPanel.Controls.Add(this.cellColourButton);
            this.optionsFlowPanel.Controls.Add(this.HorizontalSeperator);
            this.optionsFlowPanel.Controls.Add(this.advanceButton);
            this.optionsFlowPanel.Controls.Add(this.timePauseLabel);
            this.optionsFlowPanel.Controls.Add(this.timePauseUpDown);
            this.optionsFlowPanel.Controls.Add(this.autoAdvanceCheckbox);
            this.optionsFlowPanel.Controls.Add(this.gridOffCheckbox);
            this.optionsFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.optionsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsFlowPanel.Name = "optionsFlowPanel";
            this.optionsFlowPanel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.optionsFlowPanel.Size = new System.Drawing.Size(120, 412);
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
            // dragModeCheckbox
            // 
            this.dragModeCheckbox.AutoSize = true;
            this.dragModeCheckbox.Location = new System.Drawing.Point(3, 84);
            this.dragModeCheckbox.Name = "dragModeCheckbox";
            this.dragModeCheckbox.Size = new System.Drawing.Size(79, 17);
            this.dragModeCheckbox.TabIndex = 3;
            this.dragModeCheckbox.Text = "Drag Mode";
            this.dragModeCheckbox.UseVisualStyleBackColor = true;
            this.dragModeCheckbox.CheckedChanged += new System.EventHandler(this.dragModeCheckbox_CheckedChanged);
            // 
            // HorizontalSeperator
            // 
            this.HorizontalSeperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HorizontalSeperator.Location = new System.Drawing.Point(3, 156);
            this.HorizontalSeperator.Name = "HorizontalSeperator";
            this.HorizontalSeperator.Size = new System.Drawing.Size(114, 1);
            this.HorizontalSeperator.TabIndex = 5;
            // 
            // advanceButton
            // 
            this.advanceButton.Location = new System.Drawing.Point(3, 160);
            this.advanceButton.Name = "advanceButton";
            this.advanceButton.Size = new System.Drawing.Size(114, 23);
            this.advanceButton.TabIndex = 4;
            this.advanceButton.Text = "Next Turn";
            this.advanceButton.UseVisualStyleBackColor = true;
            this.advanceButton.Click += new System.EventHandler(this.advanceButton_Click);
            // 
            // timePauseLabel
            // 
            this.timePauseLabel.AutoSize = true;
            this.timePauseLabel.Location = new System.Drawing.Point(3, 186);
            this.timePauseLabel.Name = "timePauseLabel";
            this.timePauseLabel.Size = new System.Drawing.Size(63, 13);
            this.timePauseLabel.TabIndex = 6;
            this.timePauseLabel.Text = "Time Pause";
            // 
            // timePauseUpDown
            // 
            this.timePauseUpDown.DecimalPlaces = 2;
            this.timePauseUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.timePauseUpDown.Location = new System.Drawing.Point(3, 202);
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
            // autoAdvanceCheckbox
            // 
            this.autoAdvanceCheckbox.AutoSize = true;
            this.autoAdvanceCheckbox.Location = new System.Drawing.Point(3, 228);
            this.autoAdvanceCheckbox.Name = "autoAdvanceCheckbox";
            this.autoAdvanceCheckbox.Size = new System.Drawing.Size(94, 17);
            this.autoAdvanceCheckbox.TabIndex = 8;
            this.autoAdvanceCheckbox.Text = "Auto-Advance";
            this.autoAdvanceCheckbox.UseVisualStyleBackColor = true;
            this.autoAdvanceCheckbox.CheckedChanged += new System.EventHandler(this.autoAdvanceCheckbox_CheckedChanged);
            // 
            // gridOffCheckbox
            // 
            this.gridOffCheckbox.AutoSize = true;
            this.gridOffCheckbox.Location = new System.Drawing.Point(3, 251);
            this.gridOffCheckbox.Name = "gridOffCheckbox";
            this.gridOffCheckbox.Size = new System.Drawing.Size(121, 17);
            this.gridOffCheckbox.TabIndex = 2;
            this.gridOffCheckbox.Text = "No Grid (Less Flash)";
            this.gridOffCheckbox.UseVisualStyleBackColor = true;
            this.gridOffCheckbox.CheckedChanged += new System.EventHandler(this.gridOffCheckbox_CheckedChanged);
            // 
            // cellColourButton
            // 
            this.cellColourButton.Location = new System.Drawing.Point(3, 107);
            this.cellColourButton.Name = "cellColourButton";
            this.cellColourButton.Size = new System.Drawing.Size(114, 46);
            this.cellColourButton.TabIndex = 10;
            this.cellColourButton.Text = "Cell Colour";
            this.cellColourButton.UseVisualStyleBackColor = true;
            this.cellColourButton.Click += new System.EventHandler(this.cellColourButton_Click);
            // 
            // bottomOptionsPanel
            // 
            this.bottomOptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bottomOptionsPanel.Controls.Add(this.bottomOptionsFlowPanel);
            this.bottomOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomOptionsPanel.Location = new System.Drawing.Point(659, 423);
            this.bottomOptionsPanel.Name = "bottomOptionsPanel";
            this.bottomOptionsPanel.Size = new System.Drawing.Size(122, 230);
            this.bottomOptionsPanel.TabIndex = 3;
            // 
            // bottomOptionsFlowPanel
            // 
            this.bottomOptionsFlowPanel.Controls.Add(this.SavegameListBox);
            this.bottomOptionsFlowPanel.Controls.Add(this.saveGameButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.loadGameButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.deleteSaveButton);
            this.bottomOptionsFlowPanel.Controls.Add(this.ShareSaveButton);
            this.bottomOptionsFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomOptionsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.bottomOptionsFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomOptionsFlowPanel.Name = "bottomOptionsFlowPanel";
            this.bottomOptionsFlowPanel.Size = new System.Drawing.Size(120, 228);
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
            // ShareSaveButton
            // 
            this.ShareSaveButton.Location = new System.Drawing.Point(3, 191);
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
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GameForm";
            this.Text = "Game of Life";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsFlowPanel.ResumeLayout(false);
            this.optionsFlowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timePauseUpDown)).EndInit();
            this.bottomOptionsPanel.ResumeLayout(false);
            this.bottomOptionsFlowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.FlowLayoutPanel optionsFlowPanel;
        private System.Windows.Forms.Label rowBoxLabel;
        private System.Windows.Forms.NumericUpDown rowNumericUpDown;
        private System.Windows.Forms.Label columnBoxLabel;
        private System.Windows.Forms.NumericUpDown columnNumericUpDown;
        private System.Windows.Forms.CheckBox dragModeCheckbox;
        private System.Windows.Forms.Label HorizontalSeperator;
        private System.Windows.Forms.Button advanceButton;
        private System.Windows.Forms.Label timePauseLabel;
        private System.Windows.Forms.NumericUpDown timePauseUpDown;
        private System.Windows.Forms.CheckBox autoAdvanceCheckbox;
        private System.Windows.Forms.Panel renderPanel;
        private System.Windows.Forms.Panel bottomOptionsPanel;
        private System.Windows.Forms.FlowLayoutPanel bottomOptionsFlowPanel;
        private System.Windows.Forms.CheckBox gridOffCheckbox;
        private System.Windows.Forms.ListBox SavegameListBox;
        private System.Windows.Forms.Button loadGameButton;
        private System.Windows.Forms.Button saveGameButton;
        private System.Windows.Forms.Button cellColourButton;
        private System.Windows.Forms.Button deleteSaveButton;
        private System.Windows.Forms.Button ShareSaveButton;
    }
}

