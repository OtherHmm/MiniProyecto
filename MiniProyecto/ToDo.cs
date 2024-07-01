using System;
using System.Collections.Generic;
using System.Threading;

namespace MiniProyecto
{
    public class ToDo
    {
        public static string[] Tipos = new string[15]; // categoria de la tarea
        public static string[] Detalles = new string[15]; // descripcion de la tarea

        public ToDo(string tipo, string detalle, byte nTarea)
        {
            Tipos[nTarea] = tipo;
            Detalles[nTarea] = detalle;
        }

        // Métodos 

        public virtual void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            Tipos[nTarea] = tipo;
            Detalles[nTarea] = detalle;
        }
        public virtual void MostrarInfo(byte nTarea) // Cuando se elige una tarea
        {
            Console.WriteLine("       -*  TAREA  *-         ");
            Console.WriteLine($"\nCategoria:    {Tipos[nTarea - 1]}");
            Console.WriteLine($"\nDescripcion:\n{Detalles[nTarea - 1]}\n");
        }
        public virtual void BorrarInfo(byte nTarea)
        {
            Tipos[nTarea - 1] = default;
            Detalles[nTarea - 1] = default;

            Console.WriteLine("¡Tarea Eliminada con exito!");
            Console.ReadKey();
            Console.Clear();
        }
        public virtual void EditarInfo(byte nTarea)
        {
            Console.Write("Ingrese el nuevo tipo de la tarea: ");
            Tipos[nTarea - 1] = Console.ReadLine();
            Console.Write("Ingrese la nueva descripción de la tarea: ");
            Detalles[nTarea - 1] = Console.ReadLine();
        }
        public static void ActualizarTarea(int indice, string tipo, string detalle)
        {
            Tipos[indice] = tipo;
            Detalles[indice] = detalle;
        }
    }
}