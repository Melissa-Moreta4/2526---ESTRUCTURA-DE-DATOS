using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinarioBusqueda
{
    public Nodo Raiz;

    public void Insertar(int valor)
    {
        Raiz = InsertarRecursivo(Raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

        return nodo;
    }

    public bool Buscar(int valor)
    {
        return BuscarRecursivo(Raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return false;
        if (valor == nodo.Valor) return true;
        if (valor < nodo.Valor) return BuscarRecursivo(nodo.Izquierdo, valor);
        return BuscarRecursivo(nodo.Derecho, valor);
    }

    public Nodo Eliminar(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = Eliminar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = Eliminar(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null) return nodo.Derecho;
            else if (nodo.Derecho == null) return nodo.Izquierdo;

            nodo.Valor = Minimo(nodo.Derecho);
            nodo.Derecho = Eliminar(nodo.Derecho, nodo.Valor);
        }
        return nodo;
    }

    public void Eliminar(int valor)
    {
        Raiz = Eliminar(Raiz, valor);
    }

    public void Inorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            Inorden(nodo.Derecho);
        }
    }

    public void Preorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            Preorden(nodo.Izquierdo);
            Preorden(nodo.Derecho);
        }
    }

    public void Postorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Postorden(nodo.Izquierdo);
            Postorden(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public int Minimo(Nodo nodo)
    {
        int min = nodo.Valor;
        while (nodo.Izquierdo != null)
        {
            min = nodo.Izquierdo.Valor;
            nodo = nodo.Izquierdo;
        }
        return min;
    }

    public int Maximo(Nodo nodo)
    {
        int max = nodo.Valor;
        while (nodo.Derecho != null)
        {
            max = nodo.Derecho.Valor;
            nodo = nodo.Derecho;
        }
        return max;
    }

    public int Altura(Nodo nodo)
    {
        if (nodo == null) return 0;
        return 1 + Math.Max(Altura(nodo.Izquierdo), Altura(nodo.Derecho));
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO DE BÚSQUEDA ---");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorrido Inorden");
            Console.WriteLine("5. Mostrar recorrido Preorden");
            Console.WriteLine("6. Mostrar recorrido Postorden");
            Console.WriteLine("7. Mostrar mínimo");
            Console.WriteLine("8. Mostrar máximo");
            Console.WriteLine("9. Mostrar altura del árbol");
            Console.WriteLine("10. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor a insertar: ");
                    int valIns = int.Parse(Console.ReadLine());
                    arbol.Insertar(valIns);
                    break;
                case 2:
                    Console.Write("Ingrese valor a buscar: ");
                    int valBus = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valBus) ? "Valor encontrado." : "Valor no encontrado.");
                    break;
                case 3:
                    Console.Write("Ingrese valor a eliminar: ");
                    int valDel = int.Parse(Console.ReadLine());
                    arbol.Eliminar(valDel);
                    Console.WriteLine("Valor eliminado si existía.");
                    break;
                case 4:
                    Console.Write("Recorrido Inorden: ");
                    arbol.Inorden(arbol.Raiz);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Recorrido Preorden: ");
                    arbol.Preorden(arbol.Raiz);
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Recorrido Postorden: ");
                    arbol.Postorden(arbol.Raiz);
                    Console.WriteLine();
                    break;
                case 7:
                    if (arbol.Raiz != null)
                        Console.WriteLine("Mínimo: " + arbol.Minimo(arbol.Raiz));
                    else Console.WriteLine("Árbol vacío.");
                    break;
                case 8:
                    if (arbol.Raiz != null)
                        Console.WriteLine("Máximo: " + arbol.Maximo(arbol.Raiz));
                    else Console.WriteLine("Árbol vacío.");
                    break;
                case 9:
                    Console.WriteLine("Altura del árbol: " + arbol.Altura(arbol.Raiz));
                    break;
                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol limpiado.");
                    break;
            }

        } while (opcion != 0);
    }
}