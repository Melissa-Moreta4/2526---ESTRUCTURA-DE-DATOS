using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random rnd = new Random();

        // 1. Crear conjunto de 500 ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i);
        }

        // 2. Seleccionar aleatoriamente 75 ciudadanos vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>(
            ciudadanos.OrderBy(x => rnd.Next()).Take(75)
        );

        // 3. Seleccionar aleatoriamente 75 ciudadanos vacunados con AstraZeneca
        HashSet<string> astrazeneca = new HashSet<string>(
            ciudadanos.OrderBy(x => rnd.Next()).Take(75)
        );

        // --- Menú interactivo ---
        int opcion;
        do
        {
            Console.WriteLine("\n--- Sistema de Vacunación contra COVID-19 ---");
            Console.WriteLine("1. Mostrar ciudadanos NO vacunados");
            Console.WriteLine("2. Mostrar ciudadanos con ambas dosis");
            Console.WriteLine("3. Mostrar ciudadanos solo Pfizer");
            Console.WriteLine("4. Mostrar ciudadanos solo AstraZeneca");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida, intente otra vez.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    var noVacunados = ciudadanos.Except(pfizer.Union(astrazeneca));
                    MostrarResultados("Ciudadanos NO vacunados", noVacunados);
                    break;

                case 2:
                    var ambasDosis = pfizer.Intersect(astrazeneca);
                    MostrarResultados("Ciudadanos con ambas dosis", ambasDosis);
                    break;

                case 3:
                    var soloPfizer = pfizer.Except(astrazeneca);
                    MostrarResultados("Ciudadanos solo Pfizer", soloPfizer);
                    break;

                case 4:
                    var soloAstrazeneca = astrazeneca.Except(pfizer);
                    MostrarResultados("Ciudadanos solo AstraZeneca", soloAstrazeneca);
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida, intente otra vez.");
                    break;
            }

        } while (opcion != 5);
    }

    static void MostrarResultados(string titulo, IEnumerable<string> conjunto)
    {
        Console.WriteLine($"\n{titulo}: {conjunto.Count()} encontrados");
        foreach (var c in conjunto.Take(10)) // muestra solo 10 para no saturar
        {
            Console.WriteLine(c);
        }
    }
}