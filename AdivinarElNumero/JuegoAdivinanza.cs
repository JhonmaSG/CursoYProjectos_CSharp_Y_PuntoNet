using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinarElNumero
{
    public class JuegoAdivinanza
    {
        private string jugador;
        private int numeroSecreto;
        private int numeroIngresado;
        private int limite;
        private int MaxIntentos = 10;
        private bool juegoTerminado = false;

        public int NumeroIngresado
        {
            get { return numeroIngresado; }
            set { numeroIngresado = value; }
        }

        public bool JuegoTerminado
        {
            get { return juegoTerminado; }
            set { juegoTerminado = value; }
        }

        public JuegoAdivinanza(string jugador, int MaxIntentos, int limite)
        {
            this.jugador = jugador;
            this.MaxIntentos = MaxIntentos;
            this.limite = limite;
            this.numeroSecreto = generarNumero(limite);
        }

        public int generarNumero(int limite)
        {
            return new Random().Next(1, limite);
        }

        public void pedirNombre()
        {
            Console.WriteLine("Hola " + this.jugador + ", ¡comencemos el juego!");
        }

        public void pedirNumero()
        {
            Console.WriteLine("Adivina el número secreto entre 1 y " + this.limite);
            Console.WriteLine("Tienes " + this.MaxIntentos + " intentos para adivinarlo.");
            Console.Write("Introduce un número:");
            this.numeroIngresado = (int)Convert.ToInt64(Console.ReadLine());
        }

        public void verificarAdivinanza()
        {
            while (this.numeroIngresado != this.numeroSecreto && !juegoTerminado)
            {
                pedirNumero();
                if (this.numeroIngresado < this.numeroSecreto)
                {
                    this.MaxIntentos--;
                    Console.WriteLine("El número es mayor que " + this.numeroIngresado);
                }
                else if (this.numeroIngresado > this.numeroSecreto)
                {
                    this.MaxIntentos--;
                    Console.WriteLine("El número es menor que " + this.numeroIngresado);
                }
                else
                {
                    Console.WriteLine("¡Felicidades! Has adivinado el número secreto: " + this.numeroSecreto);
                }
            }
            VolverAJugar();
        }

        public string VolverAJugar()
        {
            Console.WriteLine("¿Quieres volver a jugar? (s/n)");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "s" || respuesta == "S")
            {
                this.juegoTerminado = false;
                this.numeroSecreto = generarNumero(this.limite);
                this.MaxIntentos = 10;
                return "¡Comencemos de nuevo!";
            }
            else
            {
                this.juegoTerminado = true;
                return "Gracias por jugar, " + this.jugador + "!";
            }
        }

        public void LimpiarConsola()
        {
            Console.Clear();
        }
    }
}
