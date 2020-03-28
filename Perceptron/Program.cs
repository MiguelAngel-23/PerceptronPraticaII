using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Perceptron
{
    class Program
    {

        public static void mostrarValores()
        {
            Console.WriteLine("T A B L A   A N D");
            Console.WriteLine(" x1  x2  x3  dx");
            Console.WriteLine(" -1  -1  -1  -1");
            Console.WriteLine(" -1  -1   1  -1");
            Console.WriteLine(" -1   1  -1  -1");
            Console.WriteLine(" -1   1   1  -1");
            Console.WriteLine("  1  -1  -1  -1");
            Console.WriteLine("  1  -1   1  -1");
            Console.WriteLine("  1   1  -1  -1");
            Console.WriteLine("  1   1   1   1");
        }


        static int[,] Valores = {

            { -1, -1 , -1, -1},
            { -1, -1 ,  1, -1},
            { -1,  1 , -1, -1},
            { -1,  1 ,  1, -1},
            {  1, -1 , -1, -1},
            {  1, -1 ,  1, -1},
            {  1,  1 , -1, -1},
            {  1,  1 ,  1,  1},
        };


        static double w1 = 0, w2 = 0, w3 = 0, umbral = 0;
        static double resultado;
        static int y = 0, cont = 0;
        static int[] TablaY = new int[8];
        static List<double> guardar = new List<double>(); 


        static void Main(string[] args)
        {
            mostrarValores();
            Console.WriteLine("");
            Console.Write("Ingresa W1: ");
            w1 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa W2: ");  
            w2 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa W3: ");
            w3 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa  U: ");
            umbral = Double.Parse(Console.ReadLine());
            Console.WriteLine("");

            while (cont < 8) 
            {
                operacion(cont);
                cont++;
            }

            for (int i = 0; i < guardar.Count; i++) 
            {
                Console.WriteLine( guardar[i] + " = " + TablaY[i]);
            }

        }


        static void operacion(int cont) 
        {
            /*y= (W1*X1)+(W2*X2)+(W3*X3)+(0.5)*/
            resultado = (Valores[cont, 0] * w1) + (Valores[cont, 1] * w2) + (Valores[cont, 2] * w3) + (umbral);

            if (resultado > 0) 
            {
                y = 1;
                TablaY[cont] = 1;
            }
            else
            {
                y = -1;
                TablaY[cont] = -1;
            }

            if (y == Valores[cont, 3])
            {
                guardar.Add(resultado); 
            }
            else
            {
                w1 += Valores[cont, 3] * Valores[cont, 0];
                w2 += Valores[cont, 3] * Valores[cont, 1];
                w3 += Valores[cont, 3] * Valores[cont, 2];
                umbral += Valores[cont, 3];
                operacion(cont);
            }

        }

    }
}
