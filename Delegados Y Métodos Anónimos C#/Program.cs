using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Delegados_Y_Métodos_Anónimos_C_
{
    delegate int Operar(int x, int y);
    delegate double Calculo(int x);
    delegate int Operacion(int x, int y);
    delegate int Transformar(int x);
    delegate int OperarArray(int[] array);
    delegate int OperacionCallback(int x, int y);
    delegate bool Validar(int x);
    internal class Program
    {
        static int Sumar(int a, int b) => a + b;

        static int SumarArray(int[] array)
        {
            int suma = 0;
            for (int i = 0; i < array.Length; i++)
            {
                suma += array[i];
            }
            return suma;
        }

        static int EjecutarOperacion(OperacionCallback op, int x, int y)
        {
            return op(x, y);
        }
        static int Restar(int a, int b) => a - b;
        static int Multiplicar(int a , int b) => a * b;
        static int Dividir(int a, int b)
        {
            if(b== 0)
            {
                Console.WriteLine("No se puede dividir entre 0");
                return 0;
            }
            else
            {
                return a / b;
            }
        }

        static bool ValidarNumero(int x) => x > 0;
        static bool ValidarPar(int x) => x%2 == 0;

        static int Doblar(int x) => x * 2;
        static int Triplicar(int x) => x * 3;
        static int Cuadrado(int x) => x * 2;

        static double RaizCuadrada(int x) => Math.Sqrt(x);
        static double Logaritmo(int x) => Math.Log(x);

        public delegate string ObtenerDelegadoTexto(string nombre);
        static void Mostrar(ObtenerDelegadoTexto miDelegado)
        {
            Console.WriteLine(miDelegado("Mundo"));
        }


        public delegate bool ValidarEdades(int x);
        static void ImprimirConsola(ValidarEdades miDelegado, int x)
        {
            Console.WriteLine(miDelegado(x));
        }

        static void Main(string[] args)
        {
            // EJERCICIO 1 2 3 
            Console.WriteLine("Ejercicio 1 2 3");

            Operacion op = Sumar;
            Console.WriteLine("Suma: " + op(5, 3));

            op = Restar;
            Console.WriteLine("Resta: " + op(5, 3));

            op = Multiplicar;
            Console.WriteLine("Multiplica: " + op(5,3));

            op = Dividir;
            Console.WriteLine("Dividir: " + op(5, 3));

            // EJERCICIO 4
            Console.WriteLine();
            Console.WriteLine("Ejercicio 4");

            Operacion multicast = Sumar;
            multicast += Restar;
            multicast += Multiplicar;
            multicast += Dividir;

            foreach (Operacion ope in multicast.GetInvocationList()) {
                Console.WriteLine(ope(5,3));
            }

            // EJERCICIO 5
            Console.WriteLine();
            Console.WriteLine("Ejercicio 5");

            Console.WriteLine("Suma: " + EjecutarOperacion(Sumar, 5, 3));
            Console.WriteLine("Resta: " + EjecutarOperacion(Restar, 5, 3));
            Console.WriteLine("Multiplica: " + EjecutarOperacion(Multiplicar, 5, 3));

            // EJERCICIO 6
            Console.WriteLine();
            Console.WriteLine("Ejercicio 6");

            Operar eje06 = Sumar;
            eje06 += Restar;
            eje06 += Multiplicar;

            foreach (Operar ope in eje06.GetInvocationList())
            {
                Console.WriteLine(ope.Method.Name + ": " + ope(5, 3));
            }

            // EJERCICIO 7
            Console.WriteLine();
            Console.WriteLine("Ejercicio 7");

            OperarArray eje07 = SumarArray;
            int[] arr = { 1, 2, 3, 4, 5 };

            Console.WriteLine(eje07(arr));

            // EJERCICIO 8 
            Console.WriteLine();
            Console.WriteLine("Ejercicio 8");

            Transformar transform = Doblar;
            transform += Triplicar; 
            transform += Cuadrado;

            foreach(Transformar trans in transform.GetInvocationList())
            {
                Console.WriteLine(trans.Method.Name + ": " + trans(3));
            }

            // EJERCICIO 10
            Console.WriteLine();
            Console.WriteLine("Ejercicio 10");

            Calculo cal = RaizCuadrada;
            cal += Logaritmo;

            foreach(Calculo calc in cal.GetInvocationList())
            {
                try
                {
                    Console.WriteLine(calc.Method.Name + ": " + calc(3));
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            /////////// MÉTODOS ANÓNIMOS ///////////
            Console.WriteLine();
            Console.WriteLine("Mi primer método anónimo");
            ObtenerDelegadoTexto miDelegado = delegate (string nombre)
            {
                return "Hola, " + nombre;
            };
            Console.WriteLine(miDelegado("Miguel"));
            Mostrar(miDelegado);

            // RELACIÓN 3 INICIALES MÉTODOS ANÓNIMOS
            Console.WriteLine();
            Console.WriteLine("EJERCICIO 3 INICIALES MÉTODOS ANÓNIMOS");

            // EJERCICIO 1
            Console.WriteLine();
            Console.WriteLine("Ejercicio 1");

            ValidarEdades validate = delegate (int x)
            {
                return x >= 18;
            };
            Console.WriteLine(validate(19));

            // EJERCICIO 2
            Console.WriteLine();
            Console.WriteLine("Ejercicio 2");

            ImprimirConsola(validate, 19);
        }
    }
}
