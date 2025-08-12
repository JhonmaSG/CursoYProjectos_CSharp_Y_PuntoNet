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
            Console.WriteLine("Bienvenido a Adivina el Número");
            Console.Write("Por favor, introduce tu nombre: ");
            string jugador = Console.ReadLine();
            Console.Write("Introduce el límite superior del número a adivinar: ");
            int limite = (int)Convert.ToInt64(Console.ReadLine());
            Console.Write("Introduce el número máximo de intentos: ");
            int maxIntentos = (int)Convert.ToInt64(Console.ReadLine());

            JuegoAdivinanza juego = new JuegoAdivinanza(jugador, maxIntentos, limite);
            juego.pedirNombre();
            while (!juego.JuegoTerminado)
            {
                juego.LimpiarConsola();
                juego.verificarAdivinanza();
                if (juego.JuegoTerminado)
                {
                    Console.WriteLine("¡Felicidades " + jugador + "! Has adivinado el número secreto.");
                }
                else
                {
                    juego.pedirNumero();
                }
            }
        }
    }
}
