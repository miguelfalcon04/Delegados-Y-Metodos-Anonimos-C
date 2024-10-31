using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegados_Y_Métodos_Anónimos_C_
{
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

        static bool ValidarNumero(int x) => x > 0;

        static bool ValidarPar(int x) => x%2 == 0;


        static void Main(string[] args)
        {
            // DECLARACIÓN DE UN DELEGADO
            //Operacion op = Sumar;
            //Console.WriteLine("Suma: " + op(5,3));

            //op = Restar;
            //Console.WriteLine("Resta: " + op(5, 3));

            // MULTICASTING DELEGADOS 
            //Operacion op = Sumar;
            //op += Restar;

            //foreach (Operacion metedo in op.GetInvocationList()) {
            //    Console.WriteLine(metedo(5,3));
            //}

            // DELEGADOS FUNCIONES CALLBACK
            //Console.WriteLine("Suma: " + EjecutarOperacion(Sumar, 5, 3));

            // EJERCICIO 1
            Validar validate = ValidarNumero;
            Console.WriteLine(validate(2));

            // EJERCICIO 2
            validate = ValidarPar;
            Console.WriteLine(validate(3));
        }
    }
}
