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
    delegate int Operacion(int x, int y);
    delegate int OperacionCallback(int x, int y);
    delegate bool Validar(int x);
    internal class Program
    {
        static int Sumar(int a, int b) => a + b;

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


        static void Main(string[] args)
        {
            // EJERCICIO 1 2 3 
            Console.WriteLine("EJERCICIO 1 2 3");

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
            Console.WriteLine("EJERCICIO 4");

            Operacion multicast = Sumar;
            multicast += Restar;
            multicast += Multiplicar;
            multicast += Dividir;

            foreach (Operacion ope in multicast.GetInvocationList()) {
                Console.WriteLine(ope(5,3));
            }

            // EJERCICIO 5
            Console.WriteLine();
            Console.WriteLine("EJERCICIO 5");

            Console.WriteLine("Suma: " + EjecutarOperacion(Sumar, 5, 3));
            Console.WriteLine("Resta: " + EjecutarOperacion(Restar, 5, 3));
            Console.WriteLine("Multiplica: " + EjecutarOperacion(Multiplicar, 5, 3));

            // EJERCICIO 6
            Console.WriteLine();
            Console.WriteLine("EJERCICIO 6");

            Operar eje06 = Sumar;
            eje06 += Restar;
            eje06 += Multiplicar;

            foreach (Operar ope in eje06.GetInvocationList())
            {
                Console.WriteLine(ope.Method.Name + ": " + ope(5, 3));
            }

            // EJERCICIO 7
            Console.WriteLine();
            Console.WriteLine("EJERCICIO 7");

            Operar eje07 = Sumar;
            eje07 += Restar;
            eje07 += Multiplicar;

            foreach (Operar ope in eje07.GetInvocationList())
            {
                Console.WriteLine(ope.Method.Name + ": " + ope(5, 3));
            }

            // MULTICASTING DELEGADOS 
            //Operacion op = Sumar;
            //op += Restar;

            //foreach (Operacion metedo in op.GetInvocationList()) {
            //    Console.WriteLine(metedo(5,3));
            //}

            // DELEGADOS FUNCIONES CALLBACK
            //Console.WriteLine("Suma: " + EjecutarOperacion(Sumar, 5, 3));

            // EJERCICIO 1
            //Validar validate = ValidarNumero;
            //Console.WriteLine(validate(2));

            // EJERCICIO 2
            //validate = ValidarPar;
            //Console.WriteLine(validate(3));


        }
    }
}
