using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    public class Box : RectangleShape
    {
        public bool isAlive;
        public int aliveNeighbours;

        public Box(ShapeContainer container, int x, int y, int size)
        {
            this.Parent = container;
            this.BackStyle = BackStyle.Opaque;
            this.SelectionColor = Color.Transparent;
            this.Location = new Point(x, y);
            this.Size = new Size(size, size);
            this.BackColor = Color.White;
            this.BorderColor = Color.LightGray;
            this.MouseDown += new MouseEventHandler(Box_MouseDown);
        }

        private void Box_MouseDown(object sender, MouseEventArgs e)
        {
            Box box = (Box)sender;

            box.isAlive = !box.isAlive;
            box.BackColor = box.isAlive ? Color.Black : Color.White;
        }

        public static void countAliveNeighbours(int i, int j, int boxesNumber, Box[,] boxMatrix)
        {
            boxMatrix[j, i].aliveNeighbours = 0;

            if(j > 0)
            {
                if (i < (boxesNumber - 1) && boxMatrix[j - 1, i + 1].isAlive) { boxMatrix[j, i].aliveNeighbours++; }

                if (boxMatrix[j - 1, i].isAlive) { boxMatrix[j, i].aliveNeighbours++; }

                if (i > 0 && boxMatrix[j - 1, i - 1].isAlive) { boxMatrix[j, i].aliveNeighbours++; }
            }

            if (i > 0 && boxMatrix[j, i - 1].isAlive) { boxMatrix[j, i].aliveNeighbours++; }

            if (j < (boxesNumber - 1))
            {
                if (i > 0 && boxMatrix[j + 1, i - 1].isAlive) { boxMatrix[j, i].aliveNeighbours++; }

                if (boxMatrix[j + 1, i].isAlive) { boxMatrix[j, i].aliveNeighbours++; }

                if (i < (boxesNumber - 1) && boxMatrix[j + 1, i + 1].isAlive) { boxMatrix[j, i].aliveNeighbours++; }
            }

            if (i < (boxesNumber - 1) && boxMatrix[j, i + 1].isAlive) { boxMatrix[j, i].aliveNeighbours++; }
        }

        public static void nextGeneration(int boxesNumber, Box[,] boxMatrix)
        {
            for (int i = 0; i < boxesNumber; i++)
            {
                for (int j = 0; j < boxesNumber; j++)
                {
                    applyRules(i, j, boxMatrix);
                    boxMatrix[j, i].BackColor = boxMatrix[j, i].isAlive ? Color.Black : Color.White;
                }
            }
        }

        private static void applyRules(int i, int j, Box[,] boxMatrix)
        {
            //Regla No. 1
            if (boxMatrix[j, i].isAlive && boxMatrix[j, i].aliveNeighbours < 2)
            {
                boxMatrix[j, i].isAlive = false;
                return;
            }

            //Regla No. 2  
            if (boxMatrix[j, i].isAlive && boxMatrix[j, i].aliveNeighbours >= 2 && boxMatrix[j, i].aliveNeighbours <= 3)
            {
                boxMatrix[j, i].isAlive = true;
                return;
            }

            //Regla No. 3
            if (boxMatrix[j, i].isAlive && boxMatrix[j, i].aliveNeighbours > 3)
            {
                boxMatrix[j, i].isAlive = false;
                return;
            }

            //Regla No. 4
            if (!boxMatrix[j, i].isAlive && boxMatrix[j, i].aliveNeighbours == 3)
            {
                boxMatrix[j, i].isAlive = true;
                return;
            }
        }

        public static bool isGameOver(int boxesNumber, Box[,] boxMatrix)
        {
            for (int i = 0; i < boxesNumber; i++)
            {
                for (int j = 0; j < boxesNumber; j++)
                {
                    if (boxMatrix[j, i].isAlive)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
