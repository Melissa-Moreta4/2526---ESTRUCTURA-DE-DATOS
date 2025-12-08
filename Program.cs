using System;

// Clase Circulo que encapsula su dato primitivo (radio)
class Circulo
{
    private double radio; // Variable privada para encapsulación

    // Constructor que recibe el radio
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // CalcularArea es una función que devuelve un double y calcula el área del círculo
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // CalcularPerimetro devuelve el perímetro (circunferencia)
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}

// Clase Rectangulo que encapsula largo y ancho
class Rectangulo
{
    private double largo;
    private double ancho;

    // Constructor que recibe largo y ancho
    public Rectangulo(double largo, double ancho)
    {
        this.largo = largo;
        this.ancho = ancho;
    }

    // Calcula el área del rectángulo
    public double CalcularArea()
    {
        return largo * ancho;
    }

    // Calcula el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (largo + ancho);
    }
}

class Program
{
    static void Main()
    {
        // Crear un objeto Círculo con radio 5
        Circulo c = new Circulo(5);

        Console.WriteLine("CÍRCULO");
        Console.WriteLine("Área: " + c.CalcularArea());
        Console.WriteLine("Perímetro: " + c.CalcularPerimetro());

        // Crear un objeto Rectángulo de 4x6
        Rectangulo r = new Rectangulo(4, 6);

        Console.WriteLine("\nRECTÁNGULO");
        Console.WriteLine("Área: " + r.CalcularArea());
        Console.WriteLine("Perímetro: " + r.CalcularPerimetro());

        Console.WriteLine("\nPresiona ENTER para salir...");
        Console.ReadLine();
    }
}
