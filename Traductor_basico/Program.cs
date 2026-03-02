using System;
using System.Collections.Generic;

class TraductorBasico
{
    static void Main()
    {
        // Diccionario inicial con al menos 10 palabras
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
{
    {"tiempo", "time"},
    {"persona", "person"},
    {"año", "year"},
    {"día", "day"},
    {"ojo", "eye"},
    {"mundo", "world"},
    {"vida", "life"},
    {"trabajo", "work"},
    {"semana", "week"},
    {"empresa", "company"},
    {"mujer", "woman"},
    {"lugar", "place"},
    {"niño", "child"}
};

        int opcion;
        do
        {
            Console.WriteLine("======================= MENÚ =======================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;
                case 2:
                    AgregarPalabra(diccionario);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la frase a traducir: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].ToLower().Trim(',', '.', ';', ':', '!', '?');
            if (diccionario.ContainsKey(palabraLimpia))
            {
                // Reemplaza solo la palabra limpia, conserva puntuación
                palabras[i] = palabras[i].Replace(palabraLimpia, diccionario[palabraLimpia]);
            }
        }

        string traduccion = string.Join(" ", palabras);
        Console.WriteLine("Traducción: " + traduccion);
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
