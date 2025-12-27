using System;
using System.Collections.Generic;

namespace AgendaTelefonica
{
    // Registro de contacto
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email}");
        }
    }

    // Agenda con funcionalidades de reportería
    public class Agenda
    {
        private List<Contacto> contactos = new List<Contacto>();

        public void AgregarContacto(Contacto c)
        {
            contactos.Add(c);
            Console.WriteLine("Contacto agregado exitosamente.");
        }

        public void MostrarContactos()
        {
            Console.WriteLine("\n--- Lista de Contactos ---");
            foreach (var c in contactos)
            {
                c.Mostrar();
            }
        }

        public void BuscarPorNombre(string nombre)
        {
            Console.WriteLine($"\nBuscando contacto: {nombre}");
            foreach (var c in contactos)
            {
                if (c.Nombre.ToLower().Contains(nombre.ToLower()))
                {
                    c.Mostrar();
                    return;
                }
            }
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Agenda miAgenda = new Agenda();

            // Simulación de ingreso de datos
            miAgenda.AgregarContacto(new Contacto("Melissa Moreta", "0998673452", "melissa.moreta@gmail.com"));
            miAgenda.AgregarContacto(new Contacto("Freddy Armijos", "0987865453", "freddy.armijos@gmail.com"));

            miAgenda.MostrarContactos();
            miAgenda.BuscarPorNombre("Melissa");

            Console.ReadKey();
        }
    }
}
