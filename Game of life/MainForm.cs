using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    public partial class MainForm : Form
    {
        int boxesNumber;
        int generationCounter;
        Box[,] boxMatrix;

        public MainForm()
        {
            InitializeComponent();
            boxesNumber = 30;
            boxMatrix = new Box[boxesNumber, boxesNumber];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShapeContainer container = new ShapeContainer();
            container.Parent = frame;
            int row, column, x, y, size;
            row = column = x = y = 0;
            size = frame.Width / boxesNumber;

            while (y < size * boxesNumber)
            {
                while (x < size * boxesNumber)
                {
                    boxMatrix[column, row] = new Box(container, x, y, size);
                    x += size;
                    column++;
                }

                x = 0;
                row++;
                column = 0;
                y += size;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                timer.Stop();
                btnStart.Text = "Comenzar";
            }

            else
            {
                timer.Enabled = true;
                timer.Start();
                btnStart.Text = "Parar";
            }
        }

        private void barSpeed_Scroll(object sender, EventArgs e)
        {
            timer.Interval = (sender as TrackBar).Value;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < boxesNumber; i++)
            {
                for (int j = 0; j < boxesNumber; j++)
                {
                    boxMatrix[j, i].isAlive = false;
                    boxMatrix[j, i].BackColor = Color.White;
                }
            }
            
            generationCounter = 0;
            timer.Enabled = false;
            timer.Stop();
            btnStart.Text = "Comenzar";
            lblGenerations.Text = $"Generacion: {generationCounter}";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < boxesNumber; i++)
            { 
                for (int j = 0; j < boxesNumber; j++)
                {
                    Box.countAliveNeighbours(i, j, boxesNumber, boxMatrix); 
                } 
            }

            if (Box.isGameOver(boxesNumber, boxMatrix))
            {
                timer.Enabled = false;
                timer.Stop();
                btnStart.Text = "Comenzar";
                MessageBox.Show($"Juego terminado, numero de generaciones: {generationCounter}");
                generationCounter = 0;
            }
            else
            {
                Box.nextGeneration(boxesNumber, boxMatrix);
                generationCounter++;
            }
            lblGenerations.Text = $"Generacion: {generationCounter}";
        }
    }
}