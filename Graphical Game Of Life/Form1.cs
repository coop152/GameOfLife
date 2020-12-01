using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Game_Of_Life
{
    public partial class Form1 : Form
    {
        ToroidalGameOfLife Game;
        int Rows, Columns;
        Timer autoAdvanceTimer;
        public Form1()
        {
            InitializeComponent();
            autoAdvanceTimer = new Timer();
            autoAdvanceTimer.Tick += AutoAdvanceTimer_Tick;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Rows = (int)rowNumericUpDown.Value;
            Columns = (int)columnNumericUpDown.Value;
            Game = new ToroidalGameOfLife(Rows, Columns);
            DrawGrid(Rows, Columns);
        }

        private void DrawGrid(float rows, float columns)
        {
            Graphics g = renderPanel.CreateGraphics();
            g.Clear(BackColor);
            float cellWidth = renderPanel.Bounds.Width / columns;
            float cellHeight = renderPanel.Bounds.Height / rows;
            Pen p = new Pen(SystemColors.WindowFrame, 1);
            Brush b = new SolidBrush(Color.DarkRed);
            for (int y = 1; y <= rows; y++)
            {
                g.DrawLine(p, 0, y * cellHeight, columns * cellWidth, y * cellHeight);
            }
            for (int x = 1; x <= columns; x++)
            {
                g.DrawLine(p, x * cellWidth, 0, x * cellWidth, rows * cellHeight);
            }
            bool[,] fieldArray = Game.AsArray();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (fieldArray[i, j])
                    {
                        g.FillRectangle(b, j * cellWidth, i * cellHeight, cellWidth, cellHeight);
                    }
                }
            }
        }
        /*
        private void DrawSquareGrid(float rows, float columns)
        {
            Graphics g = renderPanel.CreateGraphics();
            g.Clear(BackColor);
            float cellSize = Math.Min(renderPanel.Bounds.Width / columns, renderPanel.Bounds.Height / rows);
            Pen p = new Pen(Color.DarkRed, 1);
            Brush b = new SolidBrush(Color.DarkRed);
            for (int y = 0; y <= rows; y++)
            {
                g.DrawLine(p, 0, y * cellSize, columns * cellSize, y * cellSize);
            }

            for (int x = 0; x <= columns; x++)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, rows * cellSize);
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Alive[i, j])
                    {
                        g.FillRectangle(b, j * cellSize, i * cellSize, cellSize, cellSize);
                    }
                }
            }
        }
        */
        private void renderPanel_Resize(object sender, EventArgs e)
        {
            DrawGrid(Rows, Columns);
        }

        private void rowOrColumnCountChanged(object sender, EventArgs e)
        {
            Rows = (int)rowNumericUpDown.Value;
            Columns = (int)columnNumericUpDown.Value;
            Game.ResizeField(Rows, Columns);
            DrawGrid(Rows, Columns);
        }
        private void advanceButton_Click(object sender, EventArgs e)
        {
            Game.GotoNextGen();
            DrawGrid(Rows, Columns);
        }

        private void dragModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            isDragMode = dragModeCheckbox.Checked;
        }

        bool mouseDown, currentWay;
        bool isDragMode;
        (int x, int y) previousTile;
        private void renderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDragMode)
            {
                float cellWidth = renderPanel.Bounds.Width / (float)Columns;
                float cellHeight = renderPanel.Bounds.Height / (float)Rows;
                int row = (int)(e.Y / cellHeight);
                int column = (int)(e.X / cellWidth);
                currentWay = Game.GetCell(row, column);
                Game.SetCell(row, column, currentWay);
                DrawGrid(Rows, Columns);
                mouseDown = true;
                previousTile = (row, column);
            }
        }

        private void renderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragMode && mouseDown)
            {
                if (e.Y < 0 || e.Y >= renderPanel.Bounds.Width 
                    || e.X < 0 || e.X >= renderPanel.Bounds.Height)
                {
                    return;
                }
                float cellWidth = renderPanel.Bounds.Width / (float)Columns;
                float cellHeight = renderPanel.Bounds.Height / (float)Rows;
                int row = (int)(e.Y / cellHeight);
                int column = (int)(e.X / cellWidth);
                if ((row, column) != previousTile)
                {
                    Game.SetCell(row, column, currentWay);
                    DrawGrid(Rows, Columns);
                    previousTile = (row, column);
                }
            }
        }
        private void autoAdvanceCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            autoAdvanceTimer.Interval = (int)(timePauseUpDown.Value * 1000);
            if (autoAdvanceCheckbox.Checked)
            {
                rowNumericUpDown.Enabled = false;
                columnNumericUpDown.Enabled = false;
                dragModeCheckbox.Enabled = false;
                advanceButton.Enabled = false;
                autoAdvanceCheckbox.BackColor = Color.PaleTurquoise;
                autoAdvanceTimer.Start();
            }
            else
            {
                autoAdvanceTimer.Stop();
                rowNumericUpDown.Enabled = true;
                columnNumericUpDown.Enabled = true;
                dragModeCheckbox.Enabled = true;
                advanceButton.Enabled = true;
                autoAdvanceCheckbox.BackColor = SystemColors.Control;
            }
        }

        private void AutoAdvanceTimer_Tick(object sender, EventArgs e)
        {
            Game.GotoNextGen();
            DrawGrid(Rows, Columns);
        }

        private void renderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void renderPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isDragMode)
            {
                float cellWidth = renderPanel.Bounds.Width / (float)Columns;
                float cellHeight = renderPanel.Bounds.Height / (float)Rows;
                int row = (int)(e.Y / cellHeight);
                int column = (int)(e.X / cellWidth);
                Game.FlipCell(row, column);
                DrawGrid(Rows, Columns);
            }
        }
    }

}
