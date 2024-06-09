using System;
using System.Collections.Generic;
using System.Threading;
namespace MiniProyecto
{
    public class ListaDeTareas 
    {

        //Lista
        private List<string> Tareas = new List<string>();

        //Metodos

        public void AgregarTarea(string tarea)
        {
            Tareas.Add(tarea);
            Console.WriteLine("Tarea guardada");
            Console.ReadKey();
        }

        public void EliminarTarea(string tarea)
        {
            Tareas.Remove(tarea);
            Console.WriteLine("Tarea eliminada.");
            Console.ReadKey();


        }
        public string BuscarTarea(string titulo)
        {
            foreach (var tarea in Tareas) 
            {
            if (tarea == titulo)
                {
                    return tarea;
                }
            }
            return "Tarea no encontrada";

        }
        public void MostrarTareas()
        {
            foreach (var tarea in Tareas)
            {
                Console.WriteLine(tarea);
            }
            Console.ReadKey();
        } 
        public void Completar(string tarea)
        {
            To_do to_Do = new To_do(tarea);

            to_Do.Completar();
            Console.ReadKey();
        }
    }
}