using Hashing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Graphical_Game_Of_Life
{
    public partial class GameForm : Form
    {
        private const string NewSaveText = "(New...)";
        Database db;
        readonly string Username;
        ToroidalGameOfLife Game;
        int Rows, Columns;
        readonly Timer autoAdvanceTimer;
        bool gridOff;
        Color drawColor;
        public GameForm(string username, Database database)
        {
            InitializeComponent();
            db = database;
            Username = username;
            drawColor = Color.DarkRed;
            autoAdvanceTimer = new Timer();
            autoAdvanceTimer.Tick += AutoAdvanceTimer_Tick;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Text += $" - Signed in as \"{Username}\"";
            Rows = (int)rowNumericUpDown.Value;
            Columns = (int)columnNumericUpDown.Value;
            EnumerateSavegames();
            Game = new ToroidalGameOfLife(Rows, Columns);
            renderPanel.Invalidate();
        }

        private void EnumerateSavegames()
        {
            SavegameListBox.Items.Clear();
            string[] saveNames = db.ListSavegames(Username);
            SavegameListBox.Items.AddRange(saveNames);
            SavegameListBox.Items.Add(NewSaveText);
        }

        private void renderPanel_Resize(object sender, EventArgs e)
        {
            renderPanel.Invalidate();
        }

        private void rowOrColumnCountChanged(object sender, EventArgs e)
        {
            Rows = (int)rowNumericUpDown.Value;
            Columns = (int)columnNumericUpDown.Value;
            Game.ResizeField(Rows, Columns);
            renderPanel.Invalidate();
        }

        private void advanceButton_Click(object sender, EventArgs e)
        {
            Game.GotoNextGen();
            renderPanel.Invalidate();
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
            renderPanel.Invalidate();
        }

        private void DrawField(Graphics g, float width, float height, bool noGrid = false)
        {
            float cellWidth = width / Columns;
            float cellHeight = height / Rows;
            Pen p = new Pen(SystemColors.WindowFrame, 1);
            Color lightDrawColor = Color.FromArgb(127, drawColor);
            Brush b = new LinearGradientBrush(
                new PointF(0, 0),
                new PointF(width, height),
                lightDrawColor,
                drawColor
                );

            bool[,] fieldArray = Game.AsArray();
            RectangleF[] rects = new RectangleF[Columns * Rows];
            int k = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (fieldArray[i, j])
                    {
                        rects[k++] = new RectangleF(j * cellWidth, i * cellHeight, cellWidth, cellHeight);
                    }
                }
            }
            g.FillRectangles(b, rects);
            if (!noGrid)
            {
                for (int y = 1; y <= Rows; y++)
                {
                    g.DrawLine(p, 0, y * cellHeight, Columns * cellWidth, y * cellHeight);
                }
                for (int x = 1; x <= Columns; x++)
                {
                    g.DrawLine(p, x * cellWidth, 0, x * cellWidth, Rows * cellHeight);
                }
            }
        }

        private void renderPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawField(g, e.ClipRectangle.Width, e.ClipRectangle.Height, gridOff);
        }

        private void screenshotButton_Click(object sender, EventArgs e)
        {
            const int WIDTH = 1000; const int HEIGHT = 1000;
            Bitmap bitmap = new Bitmap(WIDTH, HEIGHT);
            DrawField(Graphics.FromImage(bitmap), WIDTH, HEIGHT);
            Clipboard.SetImage(bitmap);
        }

        private void cellColourButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = drawColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                drawColor = dialog.Color;
            }
            renderPanel.Invalidate();
        }

        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            if (selected == NewSaveText)
            {
                string saveName = InputDialog.Show("Name of new save?", "New Save");
                if (saveName != null)
                {
                    Savegame newSave = new Savegame(Columns, Rows, Game.GetSerialised(), saveName);
                    db.AddSavegame(newSave, Username);
                }
            }
            else if (selected != null)
            {
                DialogResult result = MessageBox.Show($"Overwrite save \"{selected}\"?", "Overwrite Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Savegame newSave = new Savegame(Columns, Rows, Game.GetSerialised(), selected);
                    db.UpdateSavegame(newSave, Username);
                }
            }
            // TODO: can create a new save but cannot overwrite an old one
            // no loading yet, gotta do that
            EnumerateSavegames();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            if (!(selected == NewSaveText || selected == null))
            {
                Savegame loadedSave = db.LoadSavegame(Username, selected);
                Columns = loadedSave.Columns;
                Rows = loadedSave.Rows;
                Game = ToroidalGameOfLife.Deserialise(loadedSave.Serialised, Rows, Columns);
                renderPanel.Invalidate();
            }
        }

        private void deleteSaveButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            if (selected != null && selected != NewSaveText)
            {
                DialogResult result = MessageBox.Show($"Delete save \"{selected}\"?", "Delete Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    db.DeleteSavegame(selected, Username);
                }
            }
        }
        private void ShareSaveButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            string username = InputDialog.Show("Username to share with?", "Share Save");
            if (username != null && selected != null)
            {
                bool worked = db.ShareSavegame(selected, username);
                if (!worked) MessageBox.Show("User does not exist, or already has access to save.");
            }
        }
        private void gridOffCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            gridOff = gridOffCheckbox.Checked;
            renderPanel.Invalidate();
        }

        //
        // Mouse Event Handlers and Globals
        //

        bool mouseDown, currentWay;
        bool isDragMode;
        (int x, int y) previousTile;

        private void dragModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            isDragMode = dragModeCheckbox.Checked;
        }

        private void renderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDragMode)
            {
                float cellWidth = renderPanel.Bounds.Width / (float)Columns;
                float cellHeight = renderPanel.Bounds.Height / (float)Rows;
                int row = (int)(e.Y / cellHeight);
                int column = (int)(e.X / cellWidth);
                currentWay = !Game.GetCell(row, column);
                Game.SetCell(row, column, currentWay);
                renderPanel.Invalidate();
                mouseDown = true;
                previousTile = (row, column);
            }
        }

        private void renderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragMode && mouseDown)
            {
                if (e.Y < 0 || e.Y >= renderPanel.Bounds.Height
                    || e.X < 0 || e.X >= renderPanel.Bounds.Width)
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
                    renderPanel.Invalidate();
                    previousTile = (row, column);
                }
            }
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
                renderPanel.Invalidate();
            }
        }
    }
}