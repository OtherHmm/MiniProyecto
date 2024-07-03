using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {
        byte TipoTrabajo;
        public ToDo_Trabajo(string tipo, string detalle, byte nTarea, byte tipotrabajo) : base(tipo, detalle, nTarea)
        {
            TipoTrabajo = tipotrabajo;
        }
        public override void AgregarInfoEspecial(int nTarea, string materia = null, byte prioridad = 0, byte tipotrabajo = 0)
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("| Su tarea pendiente es para oficina (proyecto) o cliente?|");
            Console.WriteLine("----------------------------------------------------------|");
            Console.WriteLine("|1. Proyecto de oficina                                   |");
            Console.WriteLine("|                             2. Cliente                  |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            TipoTrabajo = Convert.ToByte(Console.ReadLine());
        
            base.AgregarInfoEspecial(nTarea, materia, prioridad, TipoTrabajo);
        }
        public override void MostrarInfo(int nTarea)
        {
            base.MostrarInfo(nTarea);

            if (Tareas[nTarea].TrabajoTarea == 1)
            {
                Console.WriteLine("\nProyecto de oficina \n");
            }
            if (Tareas[nTarea].TrabajoTarea == 2)
            {
                Console.WriteLine("\nProyecto Cliente\n");
            }
        }
        public override void EditarInfo(int nTarea)
        {
            base.EditarInfo(nTarea);
            Console.Write("Ingrese el nuevo trabajo de la tarea (si aplica): ");
            Tareas[nTarea].TrabajoTarea = Convert.ToByte(Console.ReadLine());
        }
    }
}