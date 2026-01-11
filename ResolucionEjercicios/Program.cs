using System;
using System.Collections.Generic;
using System.Linq;

namespace ListasYTuplasPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Mostrar();
        }
    }

    // ===================== MENÚ PRINCIPAL =====================
    class Menu
    {
        public void Mostrar()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==============================================");
                Console.WriteLine("   EJERCICIOS DE LISTAS Y TUPLAS - C# (POO)");
                Console.WriteLine("==============================================");
                Console.ResetColor();

                Console.WriteLine("1. Este ejercicio muestra una lista fija de asignaturas del curso utilizando una colección de tipo List.");
                Console.WriteLine("2. En este ejercicio se ingresan seis números de la lotería, se guardan en una lista y luego se ordenan de menor a mayor.");
                Console.WriteLine("3. Aquí se genera la secuencia de números del 1 al 10 y se imprime en orden inverso usando listas.");
                Console.WriteLine("4. Este ejercicio construye el abecedario completo y elimina las letras que están en posiciones múltiplos de tres.");
                Console.WriteLine("5. En este ejercicio se pide una palabra y se cuenta cuántas veces aparece cada vocal dentro de ella, almacenando los resultados en una lista de tuplas.");
                Console.WriteLine("0. Salir.");
                Console.Write("\nSeleccione una opción: ");

                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1: new Ejercicio1().Ejecutar(); break;
                    case 2: new Ejercicio2().Ejecutar(); break;
                    case 3: new Ejercicio3().Ejecutar(); break;
                    case 4: new Ejercicio4().Ejecutar(); break;
                    case 5: new Ejercicio5().Ejecutar(); break;
                    case 0: Console.WriteLine("\nPrograma finalizado."); break;
                    default: Console.WriteLine("\nOpción no válida."); break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }

    // ===================== EJERCICIO 1 =====================
    class Ejercicio1
    {
        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 1: Este ejercicio muestra una lista fija de asignaturas del curso utilizando una colección de tipo List.\n");

            List<string> asignaturas = new List<string>
            {
                "Filosofía",
                "Educación a la Ciudadanía",
                "Biología",
                "Lengua Extranjera",
                "Matemáticas Aplicadas"
            };

            Console.WriteLine("Asignaturas del curso:");
            asignaturas.ForEach(a => Console.WriteLine("- " + a));
        }
    }

    // ===================== EJERCICIO 2 =====================
    class Ejercicio2
    {
        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 2: En este ejercicio se ingresan seis números de la lotería, se guardan en una lista y luego se ordenan de menor a mayor.\n");

            List<int> numeros = new List<int>();

            for (int i = 1; i <= 6; i++)
            {
                Console.Write($"Ingrese el número ganador #{i}: ");
                numeros.Add(int.Parse(Console.ReadLine()));
            }

            numeros.Sort();

            Console.WriteLine("\nNúmeros ordenados:");
            Console.WriteLine(string.Join(", ", numeros));
        }
    }

    // ===================== EJERCICIO 3 =====================
    class Ejercicio3
    {
        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 3: Aquí se genera la secuencia de números del 1 al 10 y se imprime en orden inverso usando listas.\n");

            List<int> numeros = Enumerable.Range(1, 10).ToList();
            numeros.Reverse();

            Console.WriteLine(string.Join(", ", numeros));
        }
    }

    // ===================== EJERCICIO 4 =====================
    class Ejercicio4
    {
        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 4: Este ejercicio construye el abecedario completo y elimina las letras que están en posiciones múltiplos de tres.\n");

            List<char> abecedario = Enumerable.Range('A', 26)
                                              .Select(c => (char)c)
                                              .ToList();

            List<char> resultado = new List<char>();

            for (int i = 0; i < abecedario.Count; i++)
            {
                if ((i + 1) % 3 != 0)
                    resultado.Add(abecedario[i]);
            }

            Console.WriteLine(string.Join(", ", resultado));
        }
    }

    // ===================== EJERCICIO 5 =====================
    class Ejercicio5
    {
        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("EJERCICIO 5: En este ejercicio se pide una palabra y se cuenta cuántas veces aparece cada vocal dentro de ella, almacenando los resultados en una lista de tuplas.\n");

            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();

            List<char> vocales = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            List<(char vocal, int cantidad)> resultado = new List<(char, int)>();

            foreach (char v in vocales)
            {
                int conteo = palabra.Count(c => c == v);
                resultado.Add((v, conteo));
            }

            Console.WriteLine("\nResultado:");
            foreach (var item in resultado)
            {
                Console.WriteLine($"Vocal '{item.vocal}': {item.cantidad} veces");
            }
        }
    }
}