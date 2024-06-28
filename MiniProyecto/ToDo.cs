using System;
using System.Collections.Generic;

namespace MiniProyecto
{
    /*
    public class To_do
    {
        public string Titulo;
        public string Descripcion;
        public string Categoria;
        public bool Estado;

        public To_do(string titulo)
        {
            Titulo = titulo;
            Estado = false;
        }

        public void Completar()
        {
            Estado = true;
            Console.WriteLine("Tarea Completada");
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Categoría: {Categoria}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }*/

    public class ToDo
    {
        private string[] Lista      = new string[15]; // tareas
        private string[] Nombre     = new string[15]; // nombre de la tarea
        private string[] Tipo       = new string[5];  // categoria de la tarea
        private string[] Detalles   = new string[15]; // descripcion de la tarea

        // Constructor

        public ToDo(string tipo, string nombre, string detalles) 
        {
            Nombre[default] = nombre;
            Tipo[default] = tipo;
            Detalles[default] = detalles;
        }

        // Métodos 
        public virtual void AgregarInfo(string tipo, string nombre, string detalles)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Tipo[i] == default && Nombre[i] == default && Detalles[i] == default)
                {
                    Tipo[i] = tipo;
                    Nombre[i] = nombre;
                    Detalles[i] = detalles;
                    break;
                }
                else if (Tipo[4] != default && Nombre[4] != default && Detalles[4] != default)
                {
                    Console.Clear();
                    Console.WriteLine("Capacidad maxima ya alcanzada");
                    Console.ReadKey();
                    break;
                }
            }
        }
        public virtual void BorrarInfo(byte opcion)
        {
            Tipo[opcion] = default;
            Nombre[opcion] = default;
            Detalles[opcion] = default;

            Console.WriteLine("Tarea Eliminada con exito");
            Console.ReadKey();
        }

        public virtual void SeleccionarTarea(byte opcion)
        {
            
        }


        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Tarea {Tipo}");
            Console.WriteLine($"{Nombre}   ");
            Console.WriteLine($"{Detalle}");
            
        }
        public virtual void MostrarTareas()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1}. {Nombre[i]} {Tipo[i]}");
            }
            Console.WriteLine("");
        }
        
    }
}