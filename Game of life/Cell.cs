using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    public class Cell : RectangleShape
    {

        int aliveNeighbours;
        bool cursorLeft;
        public bool isAlive;

        public Cell(ShapeContainer container, int x, int y, int size)
        {
            Parent = container;
            BackStyle = BackStyle.Opaque;
            SelectionColor = Color.Transparent;
            Location = new Point(x, y);
            Size = new Size(size, size);
            BackColor = Color.White;
            BorderColor = Color.LightGray;
            MouseDown += new MouseEventHandler(Cell_MouseDown);
            MouseMove += new MouseEventHandler(Cell_MouseMove);
            MouseLeave += new EventHandler(Cell_MouseLeave);
            cursorLeft = true;
        }

        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Cell cell = (Cell)sender;

                cell.isAlive = !cell.isAlive;
                cell.BackColor = cell.isAlive ? Color.Black : Color.White;
                cursorLeft = false;
            }
        }

        private void Cell_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && cursorLeft)
            {
                Cell cell = (Cell)sender;

                cell.isAlive = !cell.isAlive;
                cell.BackColor = cell.isAlive ? Color.Black : Color.White;
                cursorLeft = false;
            }
        }

        private void Cell_MouseLeave(object sender, EventArgs e)
        {
            cursorLeft = true;
        }

        public static void CountAliveNeighbours(int y, int x, int cellsNumber, Cell[,] cellMatrix)
        {
            cellMatrix[x, y].aliveNeighbours = 0;

            if(x > 0)
            {
                if (y < (cellsNumber - 1) && cellMatrix[x - 1, y + 1].isAlive) { cellMatrix[x, y].aliveNeighbours++; }

                if (cellMatrix[x - 1, y].isAlive) { cellMatrix[x, y].aliveNeighbours++; }

                if (y > 0 && cellMatrix[x - 1, y - 1].isAlive) { cellMatrix[x, y].aliveNeighbours++; }
            }

            if (y > 0 && cellMatrix[x, y - 1].isAlive) { cellMatrix[x, y].aliveNeighbours++; }

            if (x < (cellsNumber - 1))
            {
                if (y > 0 && cellMatrix[x + 1, y - 1].isAlive) { cellMatrix[x, y].aliveNeighbours++; }

                if (cellMatrix[x + 1, y].isAlive) { cellMatrix[x, y].aliveNeighbours++; }

                if (y < (cellsNumber - 1) && cellMatrix[x + 1, y + 1].isAlive) { cellMatrix[x, y].aliveNeighbours++; }
            }

            if (y < (cellsNumber - 1) && cellMatrix[x, y + 1].isAlive) { cellMatrix[x, y].aliveNeighbours++; }
        }

        private static void ApplyRules(ref Cell cell)
        {
            if (cell.aliveNeighbours < 2 || cell.aliveNeighbours > 3)
            {
                cell.isAlive = false;
            }
            else if (cell.aliveNeighbours == 3)
            {
                cell.isAlive = true;
            }
        }

        public static void NextGeneration(int cellsNumber, Cell[,] cellMatrix)
        {
            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    ApplyRules(ref cellMatrix[j, i]);
                    cellMatrix[j, i].BackColor = cellMatrix[j, i].isAlive ? Color.Black : Color.White;
                }
            }
        }

        //private bool isUpperLeftNeighbourAlive()
        //{

        //}

        //private bool isTopNeighbourAlive()
        //{

        //}

        //private bool isUpperRighttNeighbourAlive()
        //{

        //}

        //private bool isRightNeighbourAlive()
        //{

        //}

        //private bool isLowerRightNeighbourAlive()
        //{

        //}

        //private bool isBottomNeighbourAlive()
        //{

        //}

        //private bool isLowerLefttNeighbourAlive()
        //{

        //}

        //private bool isLeftNeighbourAlive()
        //{

        //}
    }
}
