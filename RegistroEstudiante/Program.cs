using System;

public class Estudiante
{
    public int ID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }

    // Array de 3 teléfonos
    public string[] Telefonos = new string[3];

    public void MostrarInformacion()
    {
        Console.WriteLine("=== Información del Estudiante ===");
        Console.WriteLine($"ID: {ID}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"Teléfono {i + 1}: {Telefonos[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estudiante estudiante = new Estudiante();

        estudiante.ID = 1;
        estudiante.Nombres = "Miguel Jossías";
        estudiante.Apellidos = "Vilacis Guapulema";
        estudiante.Direccion = "Av. 20 de Septiembre y Amazonas";

        estudiante.Telefonos[0] = "0969735621";
        estudiante.Telefonos[1] = "0987644253";
        estudiante.Telefonos[2] = "0974056782";

        estudiante.MostrarInformacion();

        Console.ReadLine();
    }
}