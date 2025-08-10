using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora = new Calculadora();
        private string entrada = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                //Evita múltiples puntos decimales
                if (btn.Text == "," && entrada.Contains(",")) return;
                entrada += btn.Text;
                txtDisplay.Text = entrada;
            }
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            if ( double.TryParse(entrada, out double numero))
            {
                calculadora.IngresarNumero(numero);
                Button btn = sender as Button;
                calculadora.Operar(btn.Text);
                entrada = ""; // Resetea la entrada para el siguiente número
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if( double.TryParse(entrada, out double numero))
            {
                try
                {
                    double resultado = calculadora.Calcular(numero);
                    txtDisplay.Text = resultado.ToString();
                    entrada = resultado.ToString(); // Actualiza la entrada con el resultado
                }
                catch (DivideByZeroException ex)
                {
                    txtDisplay.Text = ex.Message;
                    entrada = "";
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if ( entrada.Length > 0)
            {
                // Elimina el último carácter de la entrada
                entrada = entrada.Substring(0,entrada.Length -1);
                txtDisplay.Text = entrada;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            calculadora.Limpiar();
            entrada = "";
            txtDisplay.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
