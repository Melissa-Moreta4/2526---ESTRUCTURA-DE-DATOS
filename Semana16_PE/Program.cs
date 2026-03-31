using System;
using System.Collections.Generic;

class Grafo
{
    private Dictionary<string, List<(string destino, double precio)>> adyacencias;

    public Grafo()
    {
        adyacencias = new Dictionary<string, List<(string, double)>>();
    }

    public void AgregarVuelo(string origen, string destino, double precio)
    {
        if (!adyacencias.ContainsKey(origen))
            adyacencias[origen] = new List<(string, double)>();

        adyacencias[origen].Add((destino, precio));
    }

    public void MostrarVuelos()
    {
        Console.WriteLine("\n--- Lista de vuelos ---");
        foreach (var origen in adyacencias.Keys)
        {
            foreach (var vuelo in adyacencias[origen])
            {
                Console.WriteLine($"Origen: {origen}, Destino: {vuelo.destino}, Precio: ${vuelo.precio}");
            }
        }
    }

    public void ConsultarVuelo(string origen, string destino)
    {
        if (adyacencias.ContainsKey(origen))
        {
            var vuelos = adyacencias[origen].FindAll(v => v.destino.Equals(destino, StringComparison.OrdinalIgnoreCase));
            if (vuelos.Count > 0)
            {
                Console.WriteLine("\n--- Resultados ---");
                foreach (var v in vuelos)
                    Console.WriteLine($"Origen: {origen}, Destino: {v.destino}, Precio: ${v.precio}");
            }
            else
            {
                Console.WriteLine("No se encontraron vuelos para esa ruta.");
            }
        }
        else
        {
            Console.WriteLine("No existe la ciudad de origen en la base.");
        }
    }

    public void ModificarVuelo(string origen, string destino, double nuevoPrecio)
    {
        if (adyacencias.ContainsKey(origen))
        {
            for (int i = 0; i < adyacencias[origen].Count; i++)
            {
                if (adyacencias[origen][i].destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
                {
                    adyacencias[origen][i] = (destino, nuevoPrecio);
                    Console.WriteLine("Vuelo modificado correctamente.");
                    return;
                }
            }
        }
        Console.WriteLine("No se encontró el vuelo para modificar.");
    }

    public void EliminarVuelo(string origen, string destino)
    {
        if (adyacencias.ContainsKey(origen))
        {
            adyacencias[origen].RemoveAll(v => v.destino.Equals(destino, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Vuelo eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el vuelo para eliminar.");
        }
    }
}

class Program
{
    static void Main()
    {
        Grafo grafo = new Grafo();

        // Base ficticia inicial
        grafo.AgregarVuelo("Quito", "Guayaquil", 25.00);
        grafo.AgregarVuelo("Quito", "Cuenca", 30.00);
        grafo.AgregarVuelo("Guayaquil", "Bogotá", 110.00);
        grafo.AgregarVuelo("Cuenca", "Guayaquil", 33.00);
        grafo.AgregarVuelo("Guayaquil", "Panamá", 204.00);

        int opcion;
        do
        {
            Console.WriteLine("\n=== Sistema de vuelos (Grafos) ===");
            Console.WriteLine("1. Mostrar vuelos");
            Console.WriteLine("2. Agregar vuelo");
            Console.WriteLine("3. Consultar vuelo");
            Console.WriteLine("4. Modificar vuelo");
            Console.WriteLine("5. Eliminar vuelo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    grafo.MostrarVuelos();
                    break;
                case 2:
                    Console.Write("Origen: ");
                    string origen = Console.ReadLine();
                    Console.Write("Destino: ");
                    string destino = Console.ReadLine();
                    Console.Write("Precio: ");
                    double precio = double.Parse(Console.ReadLine());
                    grafo.AgregarVuelo(origen, destino, precio);
                    Console.WriteLine("Vuelo agregado.");
                    break;
                case 3:
                    Console.Write("Origen: ");
                    origen = Console.ReadLine();
                    Console.Write("Destino: ");
                    destino = Console.ReadLine();
                    grafo.ConsultarVuelo(origen, destino);
                    break;
                case 4:
                    Console.Write("Origen: ");
                    origen = Console.ReadLine();
                    Console.Write("Destino: ");
                    destino = Console.ReadLine();
                    Console.Write("Nuevo precio: ");
                    double nuevoPrecio = double.Parse(Console.ReadLine());
                    grafo.ModificarVuelo(origen, destino, nuevoPrecio);
                    break;
                case 5:
                    Console.Write("Origen: ");
                    origen = Console.ReadLine();
                    Console.Write("Destino: ");
                    destino = Console.ReadLine();
                    grafo.EliminarVuelo(origen, destino);
                    break;
            }
        } while (opcion != 0);
    }
}