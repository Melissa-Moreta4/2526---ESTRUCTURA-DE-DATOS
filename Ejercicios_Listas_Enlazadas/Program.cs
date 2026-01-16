using System;

public class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Insertar al final
    public void Insertar(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // Mostrar lista
    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    // Ejercicio 1: Invertir lista
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }
        cabeza = anterior;
    }

    // Ejercicio 2: Buscar valor
    public void Buscar(int valor)
    {
        Nodo actual = cabeza;
        int contador = 0;

        while (actual != null)
        {
            if (actual.Dato == valor)
            {
                contador++;
            }
            actual = actual.Siguiente;
        }

        if (contador > 0)
        {
            Console.WriteLine($"El valor {valor} se encontró {contador} veces en la lista.");
        }
        else
        {
            Console.WriteLine($"El valor {valor} no fue encontrado en la lista.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Insertamos algunos datos de prueba
        lista.Insertar(1);
        lista.Insertar(2);
        lista.Insertar(3);
        lista.Insertar(2);
        lista.Insertar(4);

        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Ejercicio 1: Invertir lista enlazada");
            Console.WriteLine("2. Ejercicio 2: Buscar un valor en la lista");
            Console.WriteLine("3. Mostrar lista");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\nLista original:");
                    lista.Mostrar();
                    lista.Invertir();
                    Console.WriteLine("Lista invertida:");
                    lista.Mostrar();
                    break;

                case 2:
                    Console.Write("\nIngrese el valor a buscar: ");
                    int valor = int.Parse(Console.ReadLine());
                    lista.Buscar(valor);
                    break;

                case 3:
                    Console.WriteLine("\nContenido de la lista:");
                    lista.Mostrar();
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida, intente nuevamente.");
                    break;
            }

        } while (opcion != 0);
    }
}