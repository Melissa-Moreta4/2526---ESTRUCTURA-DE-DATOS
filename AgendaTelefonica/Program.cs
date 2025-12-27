using System;

namespace AgendaTelefonica
{
    class Contacto
    {
        public string Nombre;
        public long Telefono;
        public string Direccion;
        public string Correo;
        public bool Activo;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Contacto[] agenda = new Contacto[5];
            int contador = 0;
            int opcion;

            do
            {
                Console.WriteLine("\n--- AGENDA TELEFÓNICA ---");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Mostrar contactos");
                Console.WriteLine("3. Buscar contacto");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        if (contador < agenda.Length)
                        {
                            agenda[contador] = new Contacto();

                            Console.Write("Nombre: ");
                            agenda[contador].Nombre = Console.ReadLine();

                            Console.Write("Teléfono: ");
                            agenda[contador].Telefono = long.Parse(Console.ReadLine());

                            Console.Write("Dirección: ");
                            agenda[contador].Direccion = Console.ReadLine();

                            Console.Write("Correo: ");
                            agenda[contador].Correo = Console.ReadLine();

                            agenda[contador].Activo = true;
                            contador++;

                            Console.WriteLine("Contacto agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Agenda llena.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n--- LISTA DE CONTACTOS ---");
                        for (int i = 0; i < contador; i++)
                        {
                            Console.WriteLine($"Nombre: {agenda[i].Nombre}");
                            Console.WriteLine($"Teléfono: {agenda[i].Telefono}");
                            Console.WriteLine($"Dirección: {agenda[i].Direccion}");
                            Console.WriteLine($"Correo: {agenda[i].Correo}");
                            Console.WriteLine("-------------------------");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre a buscar: ");
                        string nombreBuscar = Console.ReadLine();
                        bool encontrado = false;

                        for (int i = 0; i < contador; i++)
                        {
                            if (agenda[i].Nombre.Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Contacto encontrado:");
                                Console.WriteLine($"Teléfono: {agenda[i].Telefono}");
                                Console.WriteLine($"Dirección: {agenda[i].Direccion}");
                                Console.WriteLine($"Correo: {agenda[i].Correo}");
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine("Contacto no encontrado.");
                        }
                        break;
                }

            } while (opcion != 4);
        }
    }
}
