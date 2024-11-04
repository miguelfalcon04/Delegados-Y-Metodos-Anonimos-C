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
        static int Multiplicar(int a, int b) => a * b;
        static int Dividir(int a, int b)
        {
            if (b == 0)
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
        static bool ValidarPar(int x) => x % 2 == 0;

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

        static void ProcesarNumero(int numero, OperacionDel operacion)
        {
            operacion(numero);
        }

        public delegate int MultiplicarDel(int x, int y);
        public delegate bool VerificarPalindromo(string palabra);
        public delegate double ConvertirTemperatura(int tmp);
        public delegate bool EsMayorQueDiez(int x);
        public delegate bool CompararLongitud(string palabra1, string palabra2);
        public delegate int CalcularFactorial(int x);
        public delegate int ContarCaracteres(string palabra);
        public delegate void OperacionDel(int num);
        public delegate bool Filtro(Producto producto);
        public class Producto
        {
            private string nombre;
            private int cantidad;

            public static void MostratProductosFiltrados(List<Producto> lista, Filtro fil)
            {
                for(int i = 0; i < lista.Count; i++)
                {
                    if()
                    Console.WriteLine($"");
                }
            }

            public string Nombre { get; set; }
            public int Cantidad { get; set; }

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

            // RELACIÓN 3 INICIALES MÉTODOS ANÓNIMOS //
            Console.WriteLine();
            Console.WriteLine("RELACIÓN 3 INICIALES MÉTODOS ANÓNIMOS");

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

            // RELACIÓN 4 MÉTODOS ANÓNIMOS //
            Console.WriteLine();
            Console.WriteLine("RELACIÓN 4 MÉTODOS ANÓNIMOS");

            // EJERCICIO 1
            Console.WriteLine();
            Console.WriteLine("Ejercicio 1");

            MultiplicarDel multi = delegate (int x, int y)
            {
                return (x * y);
            };
            Console.WriteLine(multi(2,5));

            // EJERCICIO 2
            Console.WriteLine();
            Console.WriteLine("Ejercicio 2");

            VerificarPalindromo esPalindromo = (string texto) =>
            {
                int l = texto.Length;
                for (int i = 0; i < l / 2; i++)
                {
                    if (texto[i] != texto[l - i - 1])
                    {
                        return false; 
                    }
                }
                return true; 
            };

            Console.WriteLine($"radar es palindromo: {esPalindromo("radar")}");
            Console.WriteLine($"puerta es palindromo: {esPalindromo("puerta")}");

            // EJERCICIO 3
            Console.WriteLine();
            Console.WriteLine("Ejercicio 3");

            ConvertirTemperatura celsius = delegate (int x)
            {
                return (x * 9 / 5) + 32;
            };

            Console.WriteLine($"0ºC -> {celsius(0)}ºF");
            Console.WriteLine($"30ºC -> {celsius(30)}ºF");

            // EJERCICIO 4
            Console.WriteLine();
            Console.WriteLine("Ejercicio 4");

            EsMayorQueDiez mayorDiez = delegate (int x)
            {
                return x > 10;
            };

            Console.WriteLine($"8 es mayor que 10: {mayorDiez(8)}");
            Console.WriteLine($"15 es mayor que 10: {mayorDiez(15)}");

            // EJERCICIO 5
            Console.WriteLine();
            Console.WriteLine("Ejercicio 5");

            CompararLongitud longitud = delegate (string pal1, string pal2)
            {
                return pal1.Length == pal2.Length;
            };

            Console.WriteLine($"Las palabras gato y perro tienen la misma longitud: {longitud("gato","perro")}");

            // EJERCICIO 6
            Console.WriteLine();
            Console.WriteLine("Ejercicio 6");

            CalcularFactorial fact = delegate (int x)
            {
                int f = 1;
                for (int i = x; i > 1; i--) {
                    f *= i;
                }

                return f;
            };

            Console.WriteLine($"Factorial de 4 es {fact(4)}");
            Console.WriteLine($"Factorial de 6 es {fact(6)}");

            // EJERCICIO 7
            Console.WriteLine();
            Console.WriteLine("Ejercicio 7");

            ContarCaracteres caract = delegate (string pal)
            {
                return pal.Length;
            };

            Console.WriteLine($"La palabra mundo tiene {caract("mundo")} caracteres");
            Console.WriteLine($"La palabra programa tiene {caract("programa")} caracteres");

            // EJERCICIO 8
            Console.WriteLine();
            Console.WriteLine("Ejercicio 8");

            ProcesarNumero(7, delegate (int numero)
            {
                if (numero % 2 == 0)
                    Console.WriteLine($"{numero} es par.");
                else
                    Console.WriteLine($"{numero} es impar.");
            });

            // EJERCICIO 9
            Console.WriteLine();
            Console.WriteLine("Ejercicio 9");

            Filtro fil = delegate (Producto producto)
            {
                return producto.Cantidad > 5;
            };
        }
    }
}
