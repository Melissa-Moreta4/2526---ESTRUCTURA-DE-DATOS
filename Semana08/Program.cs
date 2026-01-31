using System;
using System.Collections.Generic;

class NavegadorWeb
{
    private Stack<string> historial = new Stack<string>();

    public void VisitarPagina(string url)
    {
        historial.Push(url);
        Console.WriteLine($"Visitaste: {url}");
    }

    public void Retroceder()
    {
        if (historial.Count > 1)
        {
            historial.Pop();
            Console.WriteLine($"Retrocediste a: {historial.Peek()}");
        }
        else
        {
            Console.WriteLine("No hay más páginas a las que retroceder.");
        }
    }

    public void MostrarPaginaActual()
    {
        if (historial.Count > 0)
            Console.WriteLine($"Página actual: {historial.Peek()}");
        else
            Console.WriteLine("No se ha visitado ninguna página.");
    }
}

class Program
{
    static void Main()
    {
        NavegadorWeb navegador = new NavegadorWeb();
        string comando;

        Console.WriteLine("Simulador de Navegador Web");
        Console.WriteLine("Comandos: visitar <url>, retroceder, actual, salir");

        do
        {
            Console.Write("\n> ");
            comando = Console.ReadLine();

            if (comando.StartsWith("visitar "))
            {
                string url = comando.Substring(8); // extrae la URL
                navegador.VisitarPagina(url);
            }
            else if (comando == "retroceder")
            {
                navegador.Retroceder();
            }
            else if (comando == "actual")
            {
                navegador.MostrarPaginaActual();
            }
            else if (comando != "salir")
            {
                Console.WriteLine("Comando no reconocido.");
            }

        } while (comando != "salir");

        Console.WriteLine("Programa finalizado.");
    }
}