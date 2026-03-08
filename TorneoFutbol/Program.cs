using System;
using System.Collections.Generic;

class TorneoFutbol
{
    // Diccionario: equipo -> lista de jugadores
    static Dictionary<string, List<string>> equipos = new Dictionary<string, List<string>>()
    {
        { "Barcelona", new List<string> { "Pedro", "Luis" } },
        { "Liga de Quito", new List<string> { "Andrés", "Carlos" } },
        { "Emelec", new List<string>() } // vacío para que el usuario agregue
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- TORNEO DE FUTBOL ---");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Registrar jugador en un equipo");
            Console.WriteLine("3. Mostrar equipos y jugadores");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

            switch (opcion)
            {
                case 1:
                    RegistrarEquipo();
                    break;
                case 2:
                    RegistrarJugador();
                    break;
                case 3:
                    MostrarEquipos();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente nuevamente.");
                    break;
            }
        } while (opcion != 4);
    }

    static void RegistrarEquipo()
    {
        Console.Write("Ingrese el nombre del nuevo equipo: ");
        string nombreEquipo = Console.ReadLine();

        if (!equipos.ContainsKey(nombreEquipo))
        {
            equipos[nombreEquipo] = new List<string>();
            Console.WriteLine($"Equipo '{nombreEquipo}' registrado exitosamente.");
        }
        else
        {
            Console.WriteLine("Ese equipo ya existe.");
        }
    }

    static void RegistrarJugador()
    {
        Console.Write("Ingrese el nombre del equipo: ");
        string nombreEquipo = Console.ReadLine();

        if (equipos.ContainsKey(nombreEquipo))
        {
            Console.Write("Ingrese el nombre del jugador: ");
            string jugador = Console.ReadLine();
            equipos[nombreEquipo].Add(jugador);
            Console.WriteLine($"Jugador '{jugador}' agregado al equipo '{nombreEquipo}'.");
        }
        else
        {
            Console.WriteLine("El equipo no existe. Regístrelo primero.");
        }
    }

    static void MostrarEquipos()
    {
        Console.WriteLine("\n--- LISTA DE EQUIPOS Y JUGADORES ---");
        foreach (var equipo in equipos)
        {
            Console.WriteLine($"Equipo: {equipo.Key}");
            if (equipo.Value.Count == 0)
            {
                Console.WriteLine("  (Sin jugadores registrados)");
            }
            else
            {
                foreach (var jugador in equipo.Value)
                {
                    Console.WriteLine($"  - {jugador}");
                }
            }
        }
    }
}