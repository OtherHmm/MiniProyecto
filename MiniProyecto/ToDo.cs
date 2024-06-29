using System;
using System.Collections.Generic;
using System.Threading;

namespace MiniProyecto
{
    public class ToDo
    {
        private string[] Lista      = new string[15]; // tareas
        private string[] Nombre     = new string[15]; // nombre de la tarea
        private string[] Tipo       = new string[15]; // categoria de la tarea
        private string[] Detalles   = new string[15]; // descripcion de la tarea

        // Constructor

        public ToDo(string tipo, string nombre, string detalles) 
        {
            Nombre      [default] = nombre;
            Tipo        [default] = tipo;
            Detalles    [default] = detalles;
        }

        // Métodos 

        public virtual void AgregarInfo(string tipo, string nombre, string detalles)
        {
            for (int i = 0; i < Lista.Length; i++)
            {
                if (Tipo[i] == default && Nombre[i] == default && Detalles[i] == default)
                {
                    Tipo        [i] = tipo;
                    Nombre      [i] = nombre;
                    Detalles    [i] = detalles;
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
            Tipo        [opcion] = default;
            Nombre      [opcion] = default;
            Detalles    [opcion] = default;

            Console.WriteLine("Tarea Eliminada con exito");
            Console.ReadKey();
        }

        public virtual byte SeleccionarTarea(string nombre)
        {
            for (byte i = 0; i < Lista.Length; i++)
            {
                if (Lista[i] == nombre)
                {
                    return i;
                }
                else
                {
                    Console.WriteLine("Tarea no encontrada");
                }
            }
            return default;
        }

        public virtual void MostrarInfo(byte opcion)
        {
            Console.WriteLine($"Tarea {Tipo[opcion]}");
            Console.WriteLine($"\n{Nombre[opcion]}");
            Console.WriteLine($"{Detalles[opcion]}");
        }
        public virtual void MostrarTareas()
        {
            for (int i = 0; i < Lista.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Nombre[i]} {Tipo[i]}");
            }
            Console.WriteLine("");
        }
        public virtual void EditarTarea(byte opcion)
        {
            if (Lista[opcion] != null)
            {
                Console.WriteLine("Tarea Editada.");
            }
        }
    }
}