using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinarElNumero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JuegoAdivinanza juego = new JuegoAdivinanza();
            juego.mostrarNombre();

            do
            {
                juego.LimpiarConsola();
                juego.verificarAdivinanza();
                juego.VolverAJugar();
            } while (!juego.JuegoTerminado);
        }
    }
}
