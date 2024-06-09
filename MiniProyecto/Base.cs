using System;

namespace MiniProyecto
{
    public class Base
    {
        static void Main(string[] args)
        {
            bool Salir = false;

            GestorDeTareas gestor = new GestorDeTareas();

            do
            {
                Console.WriteLine("Gestor de Tareas");
                Console.Write("Seleccione una opción: ");

                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Eliminar Tarea");
                Console.WriteLine("3. Completar Tarea");
                Console.WriteLine("4. Mostrar Todas las Tareas");
                Console.WriteLine("5. Salir");
              
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        gestor.AgregarTarea();
                        break;
                    case "2":
                        gestor.EliminarTarea();
                        break;
                    case "3":
                        gestor.CompletarTarea();
                        break;
                    case "4":
                        gestor.MostrarTareas();
                        break;
                    case "5":
                        Salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!Salir);
        }
    }
}