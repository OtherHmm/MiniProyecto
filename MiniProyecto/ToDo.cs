using System;
using System.Collections.Generic;
using System.Threading;

namespace MiniProyecto
{
    public class ToDo
    {
         string[] Tipos = new string[15]; // categoria de la tarea
         string[] Detalles = new string[15]; // descripcion de la tarea
        string[] Fecha = new string[15]; // fecha tope

        // Constructor

        public ToDo(string tipo, string detalle, byte nTarea, string fecha)
        {
            Tipos[nTarea] = tipo;
            Detalles[nTarea] = detalle;
            Fecha[nTarea] = fecha;
        }

        // Métodos 

        public virtual void AgregarInfo(string tipo, string detalle, byte nTarea, string fecha)
        {
            Tipos[nTarea-1] = tipo;
            Detalles[nTarea-1] = detalle;
            Fecha[nTarea] = fecha;
        }
        public virtual void MostrarInfo(byte nTarea) // Cuando se elige una tarea
        {
            Console.WriteLine($"\nTarea {Tipos[nTarea - 1]}");
            Console.WriteLine($"{Detalles[nTarea - 1]}\n");
            Console.WriteLine($"Fecha limite {Fecha[nTarea - 1]}\n");
        }
        public virtual void BorrarInfo(byte nTarea)
        {
            Tipos[nTarea - 1] = default;
            Detalles[nTarea - 1] = default;
            Fecha[nTarea-1] = default;

            Console.WriteLine("Tarea Eliminada con exito");
            Console.ReadKey();
        }
        public virtual void EditarInfo(byte nTarea)
        {
            Console.Write("Ingrese el nuevo tipo de la tarea: ");
            Tipos[nTarea - 1] = Console.ReadLine();
            Console.Write("Ingrese la nueva descripción de la tarea: ");
            Detalles[nTarea - 1] = Console.ReadLine();
            Console.Write("Ingrese la nueva fecha de la tarea: ");
            Fecha[nTarea - 1] = Console.ReadLine();
        }
    }
}