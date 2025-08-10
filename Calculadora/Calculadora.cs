using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculadora
    {
        public double ValorActual { get; private set; }
        private double _ValorAnterior;
        private string _operadorPendiente;

        //Ingresa un número a la calculadora
        public void IngresarNumero(double numero)
        {
            ValorActual = numero;
        }
        // Realiza la operación pendiente 
        public void Operar(string operador)
        {
            _ValorAnterior = ValorActual;
            _operadorPendiente = operador;
            ValorActual = 0;
        }

        //
        public double Calcular(double segundoNumero)
        {
            switch (_operadorPendiente)
            {
                case "+": ValorActual = _ValorAnterior + segundoNumero; break;
                case "-": ValorActual = _ValorAnterior - segundoNumero; break;
                case "*": ValorActual = _ValorAnterior * segundoNumero; break;
                case "/": 
                    if ( segundoNumero == 0)
                        throw new DivideByZeroException("No se puede dividir por cero.");
                    ValorActual = _ValorAnterior / segundoNumero; break;
                case "%": ValorActual = _ValorAnterior % segundoNumero; break;
                default: 
                    throw new InvalidOperationException("Operador no válido.");
            }
            _operadorPendiente = null; // Resetea el operador pendiente
            return ValorActual;
        }

        public void Limpiar()
        {
            ValorActual = 0;
            _ValorAnterior = 0;
            _operadorPendiente = null;
        }
    }
}
