using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    public partial class MainForm : Form
    {
        int generationCounter;
        int cellsNumber;
        ShapeContainer container;
        Cell[,] cellMatrix;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GenerateMatrix();
        }

        private void TxtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSize.Text))
            {
                int matrixSize = Convert.ToInt16(txtSize.Text);

                if (matrixSize > 4 && matrixSize <= 40)
                {
                    GenerateMatrix();
                }
                else
                {
                    MessageBox.Show("El tamaño de la matriz debe ser entre 5 y 40.");
                }
            }
            else
            {
                MessageBox.Show("Debes asignar un tamaño a la matriz antes de gerenarla.");
            }

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                timer.Stop();
                btnStart.Text = generationCounter > 0 ? "Continuar" : "Comenzar";
            }
            else
            {
                timer.Enabled = true;
                timer.Start();
                btnStart.Text = "Parar";
            }
        }

        private void BarSpeed_Scroll(object sender, EventArgs e)
        {
            timer.Interval = (sender as TrackBar).Value;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    cellMatrix[j, i].isAlive = false;
                    cellMatrix[j, i].BackColor = cellMatrix[j, i].backgroundColor;
                }
            }
            
            generationCounter = 0;
            timer.Enabled = false;
            timer.Stop();
            btnStart.Text = "Comenzar";
            lblGenerations.Text = $"Generacion: {generationCounter}";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cellsNumber; i++)
            { 
                for (int j = 0; j < cellsNumber; j++)
                {
                    Cell.CountAliveNeighbours(i, j, cellsNumber, cellMatrix); 
                } 
            }

            if (IsGameOver())
            {
                timer.Enabled = false;
                timer.Stop();
                btnStart.Text = "Comenzar";
                MessageBox.Show($"Juego terminado, número de generaciones: {generationCounter}");
                generationCounter = 0;
            }
            else
            {
                Cell.NextGeneration(cellsNumber, cellMatrix);
                generationCounter++;
            }
            lblGenerations.Text = $"Generacion: {generationCounter}";
        }

        private void BtnBorderColor_Click(object sender, EventArgs e)
        {
            clrBorders.ShowDialog();
            ReplaceMatrix();
            picBorder.BackColor = clrBorders.Color;
        }

        private void Btn_BackgroundColor_Click(object sender, EventArgs e)
        {
            clrBackground.ShowDialog();
            ReplaceMatrix();
            picBackground.BackColor = clrBackground.Color;
        }

        private void Btn_FillColor_Click(object sender, EventArgs e)
        {
            clrFill.ShowDialog();
            ReplaceMatrix();
            picFill.BackColor = clrFill.Color;
        }

        private void GenerateMatrix()
        {
            if (container != null)
            {
                container.Dispose();
            }
            container = new ShapeContainer();

            int row, column, x, y, cellSize;

            container.Parent = frame;
            cellsNumber = Convert.ToInt16(txtSize.Text);
            cellMatrix = new Cell[cellsNumber, cellsNumber];
            row = column = x = y = 0;
            cellSize = frame.Width / cellsNumber;

            while (y < cellSize * cellsNumber)
            {
                while (x < cellSize * cellsNumber)
                {
                    cellMatrix[column, row] = new Cell(container, x, y, cellSize, clrBorders.Color,clrBackground.Color,clrFill.Color);
                    x += cellSize;
                    column++;
                }

                x = 0;
                row++;
                column = 0;
                y += cellSize;
            }
        }

        private void ReplaceMatrix()
        {
            cellsNumber = Convert.ToInt16(txtSize.Text);

            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    cellMatrix[j, i].BorderColor = clrBorders.Color;
                    cellMatrix[j, i].BackColor = cellMatrix[j, i].isAlive ? clrFill.Color : clrBackground.Color;
                    cellMatrix[j, i].backgroundColor = clrBackground.Color;
                    cellMatrix[j, i].fillColor = clrFill.Color;
                }
            }
        }

        public bool IsGameOver()
        {
            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    if (cellMatrix[j, i].isAlive)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}