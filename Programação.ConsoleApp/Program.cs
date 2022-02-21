using System;

namespace Programação.ConsoleApp
{
    internal class Program
    {
        static int[] valores; 
        static int valorMaior(ref int[] numeros)
        {            
            Array.Sort(numeros);            
            return numeros[numeros.Length - 1];
        }
        static int valorMenor(out int[] numeros)
        {
            numeros = valores;
            Array.Sort(numeros);
            return numeros[0];
            
        }
        static int valorMedio()
        {
            int media = 0;
            foreach (var item in valores)
            {
                media += item;
            }
            return media / valores.Length;
        }
        static int[] valorNegativo(ref int[] numeros)
        {
            return Array.FindAll(numeros, x=> x < 0);
        }
        
        static int[] tresMaiores(ref int[] numeros)
        {
            int maior = valorMaior(ref valores);
            return new int[]{ numeros[numeros.Length - 3], numeros[numeros.Length - 2],
            maior};
        }
        static void remover(ref int[] numeros, int indice)
        {
            int[] copia = new int [10];
            Array.Copy(numeros, copia, numeros.Length);
            numeros = new int[numeros.Length - 1];
            int j = 0;
            for (int i = 0; i < copia.Length; i++)
            {
                if (i != indice)
                {
                    numeros[j] = copia[i];
                    j++;
                }                
            }
        }
        static void print(ref int[] numeros)
        {
            int i = 0;
            Array.ForEach(numeros, x => {Console.WriteLine("N° " + i + " : " + x); i++;});
        }
        static void Main(string[] args)
        {            
            valores = new int[10] {-4, 3, 99, 152, 35, -35, 0,  -3, 6, 14};
            print(ref valores);
            int maior = valorMaior(ref valores);
            int menor = valorMenor(out valores);
            int media = valorMedio();
            Console.WriteLine("Media : " + media);
            int[] maior3 = tresMaiores(ref valores);
            Console.WriteLine("Maior : {0} | Menor : {1} | Três Maiores : {2}, {3}, {4}!", 
                maior, menor, maior3[0], maior3[1], maior3[2]);
            int[] negativos = valorNegativo(ref valores);
            print(ref negativos);
            remover(ref valores, 3);
            print(ref valores);
        }
    }
}
