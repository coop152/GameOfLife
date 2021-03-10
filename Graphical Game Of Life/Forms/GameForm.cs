using Hashing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Graphical_Game_Of_Life
{
    public partial class GameForm : Form
    {
        Database db;
        readonly string Username;
        ToroidalGameOfLife Game;
        readonly Timer autoAdvanceTimer;
        bool gridOff;
        Color drawColor = Color.Turquoise;
        Func<bool[,], ToroidalGameOfLife>[] GameTypes = 
        {
            (array) => new ToroidalGameOfLife(array),
            (array) => new ToroidalHighLife(array),
            (array) => new ToroidalPlusLife(array),
            (array) => new CustomToroidalGameOfLife(array)
        };
        public GameForm(string username, Database database)
        {
            InitializeComponent();
            db = database;
            Username = username;
            autoAdvanceTimer = new Timer();
            autoAdvanceTimer.Tick += AutoAdvanceTimer_Tick;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Text += $" - Signed in as \"{Username}\"";
            int rows = (int)rowNumericUpDown.Value;
            int columns = (int)columnNumericUpDown.Value;
            EnumerateSavegames();
            GameTypeComboBox.SelectedIndex = 0;
            Game = new ToroidalGameOfLife(rows, columns);
            renderPictureBox.Invalidate();
        }
        private void GameTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Game != null)
            {
                ComboBox comboBox = sender as ComboBox;
                Game = GameTypes[comboBox.SelectedIndex](Game.AsArray());
                if (comboBox.SelectedIndex != 3)
                {
                    UnderpopulationThresholdUpDown.Enabled = false;
                    RebirthThresholdUpDown.Enabled = false;
                    OverpopulationThresholdUpDown.Enabled = false;
                }
                else
                {
                    UnderpopulationThresholdUpDown.Enabled = true;
                    RebirthThresholdUpDown.Enabled = true;
                    OverpopulationThresholdUpDown.Enabled = true;
                }
            }
        }

        private void EnumerateSavegames()
        {
            SavegameListBox.Items.Clear();
            string[] saveNames = db.ListSavegames(Username);
            SavegameListBox.Items.AddRange(saveNames);
        }

        private void renderPictureBox_Resize(object sender, EventArgs e)
        {
            renderPictureBox.Invalidate();
        }

        private void rowOrColumnCountChanged(object sender, EventArgs e)
        {
            int rows = (int)rowNumericUpDown.Value;
            int columns = (int)columnNumericUpDown.Value;
            Game.ResizeField(rows, columns);
            renderPictureBox.Invalidate();
        }

        private void advanceButton_Click(object sender, EventArgs e)
        {
            Game.GotoNextGen();
            renderPictureBox.Invalidate();
        }

        private void autoAdvanceCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            autoAdvanceTimer.Interval = (int)(timePauseUpDown.Value * 1000);
            if (autoAdvanceCheckbox.Checked)
            {
                advanceButton.Enabled = false;
                autoAdvanceCheckbox.BackColor = Color.PaleTurquoise;
                autoAdvanceTimer.Start();
            }
            else
            {
                autoAdvanceTimer.Stop();
                advanceButton.Enabled = true;
                autoAdvanceCheckbox.BackColor = SystemColors.Control;
            }
        }

        private void AutoAdvanceTimer_Tick(object sender, EventArgs e)
        {
            Game.GotoNextGen();
            renderPictureBox.Invalidate();
        }

        private void DrawField(Graphics g, float width, float height)
        {
            int columns = Game.Columns;
            int rows = Game.Rows;
            float cellWidth = width / columns;
            float cellHeight = height / rows;
            Color lightDrawColor = Color.FromArgb(127, drawColor);
            Brush b = new LinearGradientBrush(
                new PointF(0, 0),
                new PointF(width, height),
                lightDrawColor,
                drawColor
                );
            //Brush bShad = new LinearGradientBrush(
            //    new PointF(0, 0),
            //    new PointF(width, height),
            //    Color.Gray,
            //    Color.Black
            //    );
            bool[,] fieldArray = Game.AsArray();
            RectangleF[] rects = new RectangleF[columns * rows];
            //RectangleF[] shadows = new RectangleF[columns * rows];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (fieldArray[i, j])
                    {
                        //shadows[k] = new RectangleF((j + 0.1f) * cellWidth, (i + 0.1f) * cellHeight, cellWidth, cellHeight);
                        rects[k++] = new RectangleF(j * cellWidth, i * cellHeight, cellWidth, cellHeight);
                    }
                }
            }
            //g.FillRectangles(bShad, shadows);
            g.FillRectangles(b, rects);
            Pen p = new Pen(SystemColors.WindowFrame, 1);
            if (!gridOff) // Draw grid
            {
                for (int y = 1; y <= rows; y++)
                {
                    g.DrawLine(p, 0, y * cellHeight, columns * cellWidth, y * cellHeight);
                }
                for (int x = 1; x <= columns; x++)
                {
                    g.DrawLine(p, x * cellWidth, 0, x * cellWidth, rows * cellHeight);
                }
            }
        }

        private void renderPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawField(g, e.ClipRectangle.Width, e.ClipRectangle.Height);
        }

        private void screenshotButton_Click(object sender, EventArgs e)
        {
            const int WIDTH = 1000; const int HEIGHT = 1000;
            Bitmap bitmap = new Bitmap(WIDTH, HEIGHT);
            DrawField(Graphics.FromImage(bitmap), WIDTH, HEIGHT);
            Clipboard.SetImage(bitmap);
        }
        private void ThresholdsChanged(object sender, EventArgs e)
        {
            Game.BirthThreshold = (int)RebirthThresholdUpDown.Value;
            Game.UnderpopulationThreshold = (int)UnderpopulationThresholdUpDown.Value;
            Game.OverpopulationThreshold = (int)OverpopulationThresholdUpDown.Value;
        }

        private void cellColourButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = drawColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                drawColor = dialog.Color;
            }
            renderPictureBox.Invalidate();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            string saveName = InputDialog.Show("Name of new save?", "New Save");
            if (saveName != null)
            {
                Savegame newSave = new Savegame(Game.Columns, Game.Rows, Game.GetSerialised(), saveName);
                db.AddSavegame(newSave, Username);
                EnumerateSavegames();
            }
        }
        private void SaveGameButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            if (selected != null)
            {
                DialogResult result = MessageBox.Show($"Overwrite save \"{selected}\"?", "Overwrite Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Savegame newSave = new Savegame(Game.Columns, Game.Rows, Game.GetSerialised(), selected);
                    db.UpdateSavegame(newSave, Username);
                }
            }
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            if (selected != null)
            {
                Savegame save = db.LoadSavegame(Username, selected);
                rowNumericUpDown.Value = save.Rows;
                columnNumericUpDown.Value = save.Columns;
                Game = ToroidalGameOfLife.Deserialise(save.Serialised, save.Rows, save.Columns);
                GameTypeComboBox.SelectedIndex = 0;
                ThresholdsChanged(sender, e);
                renderPictureBox.Invalidate();
            }
        }

        private void deleteSaveButton_Click(object sender, EventArgs e)
        {
            string selected = (string)SavegameListBox.SelectedItem;
            if (selected != null)
            {
                DialogResult result = MessageBox.Show($"Delete save \"{selected}\"?", "Delete Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    db.DeleteSavegame(selected, Username);
                }
                EnumerateSavegames();
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
            renderPictureBox.Invalidate();
        }

        //
        // Mouse Event Handlers and Globals
        //

        bool mouseDown, currentWay;
        (int x, int y) previousTile;

        private void renderPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            float cellWidth = renderPictureBox.Bounds.Width / (float)Game.Columns;
            float cellHeight = renderPictureBox.Bounds.Height / (float)Game.Rows;
            int row = (int)(e.Y / cellHeight);
            int column = (int)(e.X / cellWidth);
            currentWay = !Game.GetCell(row, column);
            Game.SetCell(row, column, currentWay);
            renderPictureBox.Invalidate();
            mouseDown = true;
            previousTile = (row, column);
        }

        private void renderPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (e.Y < 0 || e.Y >= renderPictureBox.Bounds.Height
                    || e.X < 0 || e.X >= renderPictureBox.Bounds.Width)
                {
                    return;
                }
                float cellWidth = renderPictureBox.Bounds.Width / (float)Game.Columns;
                float cellHeight = renderPictureBox.Bounds.Height / (float)Game.Rows;
                int row = (int)(e.Y / cellHeight);
                int column = (int)(e.X / cellWidth);
                if ((row, column) != previousTile)
                {
                    Game.SetCell(row, column, currentWay);
                    renderPictureBox.Invalidate();
                    previousTile = (row, column);
                }
            }
        }


        private void renderPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}