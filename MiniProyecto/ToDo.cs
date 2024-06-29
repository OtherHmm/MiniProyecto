using System;
using System.Collections.Generic;
using System.Threading;

namespace MiniProyecto
{
    public class ToDo
    {
         string[] Tipos = new string[15]; // categoria de la tarea
         string[] Detalles = new string[15]; // descripcion de la tarea


        // Constructor

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
            Console.WriteLine("");
            Console.WriteLine($"Tarea {Tipos[nTarea]}");
            Console.WriteLine($"{Detalles[nTarea]}");
            Console.WriteLine("");
        }
        public virtual void BorrarInfo(byte nTarea)
        {
            Tipos[nTarea] = default;
            Detalles[nTarea] = default;

            Console.WriteLine("Tarea Eliminada con exito");
            Console.ReadKey();
        }
        public virtual void EditarInfo(byte nTarea)
        {
            Console.Write("Ingrese la nueva tipo de la tarea: ");
            Tipos[nTarea] = Console.ReadLine();
            Console.Write("Ingrese la nueva descripción de la tarea: ");
            Detalles[nTarea] = Console.ReadLine();
        }
    }
}