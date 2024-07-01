using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto
{
    internal class ToDo_Personal : ToDo
    {
        byte Prioridad;
        public ToDo_Personal(string tipo, string detalle, byte nTarea, byte prioridad) : base(tipo, detalle, nTarea)
        {
            Prioridad = prioridad;
        }
        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }
        public override void MostrarInfo(byte nTarea)
        {
            base.MostrarInfo(nTarea);
            if (Prioridad == 1) 
            {
            Console.WriteLine($"\nPrioridad: Alta\n");
            }
            if (Prioridad == 2) 
            {
                Console.WriteLine($"\nPrioridad: Intermedia\n");
            }
            if (Prioridad == 3) 
            {
                Console.WriteLine($"\nPrioridad: Baja\n");
            }
        }
        public void PreguntarInfoPersonal()
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("|       Cual es la prioridad de tu tarea?         |");
            Console.WriteLine("--------------------------------------------------|");
            Console.WriteLine("|1. Alta                                          |");
            Console.WriteLine("|                 2. Intermedia                   |");
            Console.WriteLine("|                                   3. Baja       |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Prioridad = Convert.ToByte(Console.ReadLine());
        }
    }
}