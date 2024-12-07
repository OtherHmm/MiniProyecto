using System;
using System.Collections.Generic;

namespace MiniProyecto
{
    public class ToDo
    {
        public static List<To_do> Tareas = new List<To_do>(15);
        public ToDo(string tipo, string detalle, int nTarea, string materia = default, byte prioridad = default, byte trabajoTarea = default)
        {
            if (Tareas.Count <= nTarea)
            {
                Tareas.Add(new To_do(tipo, detalle, materia, prioridad, trabajoTarea));
            }
            else
            {
                Tareas[nTarea] = new To_do(tipo, detalle, materia, prioridad, trabajoTarea);
            }
        }
        public virtual void AgregarInfo(string tipo, string detalle, int nTarea, string materia = default, byte prioridad = default, byte trabajoTarea = default)
        {
            if (nTarea < Tareas.Count)
            {
                Tareas[nTarea].Tipo = tipo;
                Tareas[nTarea].Detalle = detalle;
                Tareas[nTarea].Materia = materia;
                Tareas[nTarea].Prioridad = prioridad;
                Tareas[nTarea].TrabajoTarea = trabajoTarea;
            }
            else
            {
                Tareas.Add(new To_do(tipo, detalle, materia, prioridad, trabajoTarea));
            }
        }
        public virtual void MostrarInfo(int nTarea)
        {
            if (nTarea < Tareas.Count)
            {
                Console.WriteLine($"\nCategoria:    {Tareas[nTarea].Tipo}");
                Console.WriteLine($"\nDescripcion:\n{Tareas[nTarea].Detalle}");
            }
            else
            {
                Console.WriteLine("La tarea no existe.");
            }
        }
        public virtual void BorrarInfo(int nTarea)
        {
            if (nTarea < Tareas.Count)
            {
                Tareas.RemoveAt(nTarea);
                Console.WriteLine("¡Tarea Eliminada con éxito!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("La tarea no existe.");
            }
        }
        public virtual void EditarInfo(int nTarea)
        {
            if (nTarea < Tareas.Count)
            {
                Console.Write("Ingrese el nuevo tipo de la tarea: ");
                Tareas[nTarea].Tipo = Console.ReadLine();
                Console.Write("Ingrese la nueva descripción de la tarea: ");
                Tareas[nTarea].Detalle = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("La tarea no existe.");
            }
        }
        public virtual void AgregarInfoEspecial(int nTarea, string materia = default, byte prioridad = default, byte trabajoTarea = default)
        {
            if (nTarea < Tareas.Count)
            {
                Tareas[nTarea].Materia = materia;
                Tareas[nTarea].Prioridad = prioridad;
                Tareas[nTarea].TrabajoTarea = trabajoTarea;
            }
        }
    }
}