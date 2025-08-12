using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int maxIntentos = 10;
        private bool juegoTerminado = false;

        public string Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

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

        public int MaxIntentos
        {
            get { return MaxIntentos; }
            set { MaxIntentos = value; }
        }

        public int Limite
        {
            get { return limite; }
            set { limite = value; }
        }

        public JuegoAdivinanza()
        {
            Saludo();
        }

        public void Saludo()
        {
            LimpiarConsola();
            Console.WriteLine("Bienvenido a Adivina el Número");
            Console.Write("Por favor, introduce tu nombre: ");
            this.jugador = Console.ReadLine();
            Console.Write("Introduce el límite superior del número a adivinar: ");
            this.limite = (int)Convert.ToInt64(Console.ReadLine());
            Console.Write("Introduce el número máximo de intentos: ");
            this.maxIntentos = (int)Convert.ToInt64(Console.ReadLine());

            this.numeroSecreto = generarNumero(limite);
        }

        public int generarNumero(int limite)
        {
            return new Random().Next(1, limite);
        }

        public void mostrarNombre()
        {
            Console.WriteLine("Hola " + this.jugador + ", ¡comencemos el juego!");
        }

        public void pedirNumero()
        {
            Console.WriteLine("\nAdivina el número secreto entre 1 y " + this.limite);
            Console.WriteLine("Tienes " + this.maxIntentos + " intentos para adivinarlo.");
            Console.Write("Introduce un número:");
            this.numeroIngresado = (int)Convert.ToInt64(Console.ReadLine());
        }

        public void verificarAdivinanza()
        {
            while (this.numeroIngresado != this.numeroSecreto && !juegoTerminado)
            {
                if(this.maxIntentos == 0)
                {
                    LimpiarConsola();
                    Console.WriteLine("¡Has Perdido! Te quedaste sin Intentos");
                    Console.WriteLine("El número Secreto era: "+this.numeroSecreto);
                    JuegoTerminado = true;
                }
                else
                {
                    pedirNumero();
                    if (this.numeroIngresado < this.numeroSecreto)
                    {
                        this.maxIntentos--;
                        Console.WriteLine("El número es mayor que " + this.numeroIngresado);
                    }
                    else if (this.numeroIngresado > this.numeroSecreto)
                    {
                        this.maxIntentos--;
                        Console.WriteLine("El número es menor que " + this.numeroIngresado);
                    }
                    else
                    {
                        Console.WriteLine("¡Felicidades! Has adivinado el número secreto: " + this.numeroSecreto);
                    }
                }
            }
        }

        public void VolverAJugar()
        {
            Console.WriteLine("¿Quieres volver a jugar? (s/n)");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "s" || respuesta == "S")
            {
                this.juegoTerminado = false;
                Saludo();
            }
            else
            {
                this.juegoTerminado = true;
                Console.WriteLine("Gracias por jugar, " + this.jugador + "!");
            }
        }

        public void LimpiarConsola()
        {
            Console.Clear();
        }
    }
}
