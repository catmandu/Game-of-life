using System;
using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    public class casilla : RectangleShape
    {
        public bool estado;
        public int vecinosVivos;

        public casilla(ShapeContainer contenedor,int x, int y, int medida)
        {
            estado = false;
            this.Parent = contenedor;
            this.BackStyle = BackStyle.Opaque;
            this.SelectionColor = System.Drawing.Color.Transparent;
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(medida, medida);
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.BlueViolet;
            vecinosVivos = 0;
        }

    }
}
