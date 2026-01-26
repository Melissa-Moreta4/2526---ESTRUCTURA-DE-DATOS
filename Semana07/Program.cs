using System;
using System.Collections.Generic;

class Program
{
    // -------------------------------
    // 1. Verificación de paréntesis balanceados
    // -------------------------------
    static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;

                char tope = pila.Pop();
                if ((c == ')' && tope != '(') ||
                    (c == '}' && tope != '{') ||
                    (c == ']' && tope != '['))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0;
    }

    // -------------------------------
    // 2. Torres de Hanoi con pilas
    // -------------------------------
    static void TorresDeHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }
        else
        {
            TorresDeHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);
            TorresDeHanoi(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
            TorresDeHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }

    static void Main(string[] args)
    {
        // -------------------------------
        // Prueba de paréntesis balanceados
        // -------------------------------
        string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        Console.WriteLine("Expresión: " + expresion);
        if (EstaBalanceada(expresion))
            Console.WriteLine("Fórmula balanceada");
        else
            Console.WriteLine("Fórmula NO balanceada");

        Console.WriteLine("\n-------------------------------\n");

        // -------------------------------
        // Prueba de Torres de Hanoi
        // -------------------------------
        int numDiscos = 3;
        Stack<int> torreA = new Stack<int>();
        Stack<int> torreB = new Stack<int>();
        Stack<int> torreC = new Stack<int>();

        // Inicializar torre A con discos (mayor abajo, menor arriba)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }

        Console.WriteLine($"Resolviendo Torres de Hanoi con {numDiscos} discos:\n");
        TorresDeHanoi(numDiscos, torreA, torreC, torreB, "A", "C", "B");
    }
}