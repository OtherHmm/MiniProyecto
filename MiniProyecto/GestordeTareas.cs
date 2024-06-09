using MiniProyecto;
using System.Threading;
using System;
using System.Collections.Generic;

public class GestorDeTareas 
{
    ListaDeTareas Listado = new ListaDeTareas();

    public void AgregarTarea()
    {
        Console.WriteLine("Ingrese el título de la tarea:");
        string titulo = Console.ReadLine();

        Console.WriteLine("Ingrese una descripción:");
        string descripcion = Console.ReadLine();

        Console.WriteLine("Seleccione el tipo de tarea: Estudio, Trabajo, Personal");
        string categoria = Console.ReadLine();

        To_do nuevaTarea = new To_do(titulo/*, descripcion, categoria*/);

        Listado.AgregarTarea(titulo);
    }

    public void EliminarTarea()
    {
        Console.WriteLine("Ingrese el título de la tarea a eliminar:");
        string tarea = Listado.BuscarTarea(Console.ReadLine());

        if (tarea != null)
        {
            Listado.EliminarTarea(tarea);
        }
    }

    public void CompletarTarea()
    {
        Console.WriteLine("Ingrese el título de la tarea a completar:");
        string tarea = Listado.BuscarTarea(Console.ReadLine());

        if (tarea != null)
        {
            Listado.Completar(tarea);
            Console.WriteLine("Tarea completada.");
        }
    }

    public void MostrarTareas()
    {
        Listado.MostrarTareas();
    }
}
