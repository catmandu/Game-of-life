using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Game_of_life
{
    public partial class frmPrincipal : Form
    {
        int cantidadCasilla;//cantidad de casillas en cada fila y en cada columna
        int generacion;//variable que lleva la cuenta de los ciclos transcurridos
        casilla[,] Matriz; //Matriz de casillas
        ShapeContainer contenedor = new ShapeContainer();//Contenedor de todas las casillas

        public frmPrincipal()
        {
            InitializeComponent();
            cantidadCasilla = 40;//Es el largo y ancho de la matriz de casillas
            generacion = 0;
            Matriz = new casilla[cantidadCasilla, cantidadCasilla];//Se asigna el tamaño de la matriz de casillas
            contenedor.Parent = Marco;//Se asigna un control padre al contenedor de las casillas
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            int fila, columna, x, y, medida;//fila y columna sirven de indice en la matriz, X y Y sirven de coordenadas para pintar la casilla y medida es el valor que representa las dimensiones de cada casilla
            fila = columna = 0;//Se inicializan fila y columna en 0 
            medida = Marco.Width / cantidadCasilla;//medida se asigna a un valor que varia en la cantidad de casillas que se quiera en la matriz
            x=y=0;//Se inicializan en el punto 0 del control "Marco"

            while (y < medida * cantidadCasilla)//comienza ciclo externo para pintar las casillas, este avanza cuando la fila esta terminada
            {
              while (x < medida * cantidadCasilla)//comienza ciclo interno para pintar las casillas de cada fila
              {  
                 Matriz[columna, fila] = new casilla(contenedor,x,y,medida);//Se crea un nuevo objeto de la clase "casilla" que conformara la matriz de casillas en la posicion que se le asigne
                 Matriz[columna, fila].MouseDown += new MouseEventHandler(casilla_Click);//Se crea un evento "OnClick" para la casilla anteriormente creada
                 x += medida;//x avanza "medida" veces en el plano de coordenadas
                 columna++;//El indice "columna" para la matriz avanza y se termina el ciclo interno al cumplirse la condicion
              }
                 x =0; //Se hace "reset" a la variable "x" para que se pueda hacer la misma operacion en las filas siguientes
                 fila++;//Se pasa a la fila siguiente
                 columna = 0;//Se hace "reset" en el indice "columna" para que se le pueda asignar a demas elementos
                 y += medida;//y avanza "medida" veces en el plano de coordenadas
            }
        }

        private void casilla_Click(object sender, MouseEventArgs e)
        {
            var comodin = (casilla)sender;//Se crea un objeto temporal "comodin" que es representante del objeto que desencadeno el evento (sender)

            if (!comodin.estado){comodin.BackColor = Color.Black;comodin.estado=true;}//Si el el atributo "estado" del comodin es falso, se activa
            
            else{comodin.BackColor = Color.White;comodin.estado = false;}//Si el "estado" es verdadero, la casilla se desactiva
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)//Al pulsar el boton, si el timer esta corriendo, lo detendra y cambiara el texto a "comenzar"
            {
                timer1.Enabled = false;
                timer1.Stop();
                btnComenzar.Text = "Comenzar";
            }

            else//si no, lo iniciara y cambiara el texto a "parar"
            {
                timer1.Enabled = true;
                timer1.Start();
                btnComenzar.Text = "Parar";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;//Asigna el intervalo del timer, para que las pulsaciones sean mas rapidas o lentas
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cantidadCasilla; i++)//Al hacer click, recorre la matriz "matando" a todas las casillas
            {
                for (int j = 0; j < cantidadCasilla; j++)
                {
                    Matriz[j, i].estado = false;
                    Matriz[j, i].BackColor = Color.White;
                }
            }

            //Se inicializa la variable generacion, se despliega su valor y se detiene el timer
            generacion = 0;
            timer1.Enabled = false;
            timer1.Stop();
            btnComenzar.Text = "Comenzar";
            lblGeneraciones.Text = "Generacion: " + generacion.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < cantidadCasilla; i++)
            { 
                for (int j = 0; j < cantidadCasilla; j++)
                {
                    contarVecinos(i, j); //recorre cada casilla en la matriz y llama al metodo contarVecinos
                } 
            }

            if (juegoTerminado())//En caso de que en toda la matriz ya no tenga casillas activadas o "vivas", es juego terminado y el timer se detiene, asi como el contador de generaciones se devuelve a 0
            {
                timer1.Enabled = false;
                timer1.Stop();
                btnComenzar.Text = "Comenzar";
                MessageBox.Show("Juego terminado, numero de generaciones: " + generacion.ToString());
                generacion = 0;
            }
            else
            {
                siguienteGeneracion();//Una vez terminada de recorrer la matriz, se pasa a determinar la siguiente generacion
                generacion++;
            }
            lblGeneraciones.Text = "Generacion: " + generacion.ToString();//se despliega la actual "generacion"
        }

        private void contarVecinos(int i, int j)//Se cuenta el numero de vecinos vivos de cada casilla para poder aplicar las reglas
        {
            Matriz[j, i].vecinosVivos = 0;

            if (j > 0 && i < (cantidadCasilla - 1) && Matriz[j - 1, i + 1].estado) { Matriz[j, i].vecinosVivos++; }//diagonal inferior izquierda

            if (j > 0 && Matriz[j - 1, i].estado) { Matriz[j, i].vecinosVivos++; }//izquierda

            if (j > 0 && i > 0 && Matriz[j - 1, i - 1].estado) { Matriz[j, i].vecinosVivos++; }//diagonal superior izquierda

            if (i > 0 && Matriz[j, i - 1].estado) { Matriz[j, i].vecinosVivos++; }//arriba

            if (j < (cantidadCasilla - 1) && i > 0 && Matriz[j + 1, i - 1].estado) { Matriz[j, i].vecinosVivos++; }//diagonal superior derecha

            if (j < (cantidadCasilla - 1) && Matriz[j + 1, i].estado) { Matriz[j, i].vecinosVivos++; }//derecha

            if (j < (cantidadCasilla - 1) && i < (cantidadCasilla - 1) && Matriz[j + 1, i + 1].estado) { Matriz[j, i].vecinosVivos++; }//diagonal inferior derecha

            if (i < (cantidadCasilla - 1) && Matriz[j, i + 1].estado) { Matriz[j, i].vecinosVivos++; }//abajo
        }

        private void reglas(int i, int j)//Aqui se aplican las 4 reglas del Juego, cambiando los estados de la casilla segun sea el caso
        {
            //Regla No. 1
            if (Matriz[j, i].estado && Matriz[j, i].vecinosVivos < 2) { Matriz[j, i].estado = false; }

            //Regla No. 2  
            if (Matriz[j, i].estado && Matriz[j, i].vecinosVivos >= 2 && Matriz[j, i].vecinosVivos <= 3) { Matriz[j, i].estado = true; }

            //Regla No. 3
            if (Matriz[j, i].estado && Matriz[j, i].vecinosVivos > 3) { Matriz[j, i].estado = false; }

            //Regla No. 4
            if (!Matriz[j, i].estado && Matriz[j, i].vecinosVivos == 3) { Matriz[j, i].estado = true; }
        }

        private void siguienteGeneracion()
        {
            for (int i = 0; i < cantidadCasilla; i++)
            {
                for (int j = 0; j < cantidadCasilla; j++)
                {
                    reglas(i, j);//Se aplican las reglas del juego a cada casilla una vez que ya se checaron todos sus vecinos

                    if (Matriz[j, i].estado) { Matriz[j, i].BackColor = Color.Black; }//Cada casilla con estado verdadero tiene color negro
                    else { Matriz[j, i].BackColor = Color.White; }//Cada casilla con estado falso tiene color blanco
                }
            }
        }

        private bool juegoTerminado()//metodo encargado de comprobar si hay alguna casilla activa en la matriz
        {
            for (int i = 0; i < cantidadCasilla; i++)
            {
                for (int j = 0; j < cantidadCasilla; j++)
                {
                    if (Matriz[j, i].estado) { return false; }
                }
            }
            return true;
        }
    }
}