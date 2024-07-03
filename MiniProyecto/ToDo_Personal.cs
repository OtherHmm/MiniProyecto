using System;

namespace MiniProyecto
{
    internal class ToDo_Personal : ToDo
    {
        byte Prioridad;
        public ToDo_Personal(string tipo, string detalle, byte nTarea, byte prioridad) : base(tipo, detalle, nTarea)
        {
            Prioridad = prioridad;
        }
        public override void AgregarInfoEspecial(int nTarea, string materia = null, byte prioridad = 0, byte trabajoTarea = 0)
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("|       Cual es la prioridad de tu tarea?         |");
            Console.WriteLine("--------------------------------------------------|");
            Console.WriteLine("|1. Alta                                          |");
            Console.WriteLine("|                 2. Intermedia                   |");
            Console.WriteLine("|                                   3. Baja       |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Prioridad = Convert.ToByte(Console.ReadLine());

            base.AgregarInfoEspecial(nTarea, materia, Prioridad, trabajoTarea);
        }
        public override void MostrarInfo(int nTarea)
        {
            base.MostrarInfo(nTarea);
            if (Tareas[nTarea].Prioridad == 1)
            {
                Console.WriteLine($"\nPrioridad: Alta\n");
            }
            if (Tareas[nTarea].Prioridad == 2)
            {
                Console.WriteLine($"\nPrioridad: Intermedia\n");
            }
            if (Tareas[nTarea].Prioridad == 3)
            {
                Console.WriteLine($"\nPrioridad: Baja\n");
            }
        }
        public override void EditarInfo(int nTarea)
        {
            base.EditarInfo(nTarea);
            Console.Write("Ingrese la nueva prioridad de la tarea (si aplica): ");
            Tareas[nTarea].Prioridad = Convert.ToByte(Console.ReadLine());
        }
    }
}