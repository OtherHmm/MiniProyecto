using MiniProyecto;
using System.Threading;
using System;
using System.Collections.Generic;

public class GestorDeTareas 
{
    Compendio Compendio = new Compendio();

    public void AgregarTarea()
    {
        Console.WriteLine("Ingrese el título de la tarea:");
        string titulo = Console.ReadLine();
        Console.WriteLine("Ingrese una descripción:");
        string descripcion = Console.ReadLine();
        Console.WriteLine("Seleccione una categoria: Estudio, Trabajo, Personal");
        string categoria = Console.ReadLine();

        To_do nuevaTarea = new To_do(titulo);

        nuevaTarea.Categoria = categoria;
        nuevaTarea.Descripcion = descripcion;

        Compendio.AgregarTarea(titulo);
    }

    public void EliminarTarea()
    {
        Console.WriteLine("Ingrese el título de la tarea a eliminar:");
        string tarea = Compendio.BuscarTarea(Console.ReadLine());

        if (tarea != null)
        {
            Compendio.EliminarTarea(tarea);
        }
    }

    public void CompletarTarea()
    {
        Console.WriteLine("Ingrese el título de la tarea a completar:");
        string tarea = Compendio.BuscarTarea(Console.ReadLine());

        if (tarea != null)
        {
            Compendio.Completar(tarea);
            Console.WriteLine("Tarea completada.");
        }
    }

    public void MostrarTareas()
    {
        Compendio.MostrarTareas();
    }
}
