using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] arg;
        public int contarUltimosBit(string dato,int acumula)
        {
            int suma = 0;
            for (int i = 0; i < dato.Length; i++)
            {
                if (acumula <= i)
                {
                    suma += 1;
                }
            }
            return suma;
        }
        public int contarUnos(int c,int fila)
        {
            int contar = 0;
            for(int f = 0; f < fila; f++)
            {
                if (arg[f, c] == 1)
                {
                    contar += 1;
                }

            }
            return contar;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string dato = txtDato.Text;
            string correcion = "";
            int divisor = int.Parse(txtDivisor.Text);
            int fila=0, column = 0;
            int resul = dato.Length / divisor;
            int acumula = resul * divisor;//es para hacer la multiplicacion del divisor con el resul
            //nos sirve para realizar cuantos ceros tengo que agregar a los ultimos espacios 
            if (dato.Length%divisor==0) {
                correcion = dato;
                fila = resul;
            }
            else
            {
                int addCeros = divisor-contarUltimosBit(dato, acumula);
                for (int i=0;i<dato.Length;i++) {
                    if (acumula == i) {
                        for (int b = 0; b < addCeros; b++) {
                            correcion += "0";
                        }
                    }
                    correcion += dato[i];
                }
                fila = resul + 1;                 
            }
            lblDatos.Text = correcion.ToString();
            column = divisor;
            lblResul.Text = "";
            dato = "";
            int pos = 0;
            arg = new int[fila, column];
            for (int f=0;f<fila;f++) {
                for (int c = 0; c < column; c++) {
                    arg[f, c] = int.Parse(correcion[pos].ToString());
                    lblResul.Text += correcion[pos].ToString();
                    pos += 1;
                }
                lblResul.Text += "\n";
            }
            lblResul.Text += "\n";
            int[] redun = new int[column];
            
            for (int i = 0; i < column; i++)
            {
                if (contarUnos(i, fila) % 2 == 0) {
                    redun[i] = 0;
                } else
                {
                    redun[i] = 1;
                }
                lblResul.Text += redun[i].ToString();
            }
            
        }
    }
}
