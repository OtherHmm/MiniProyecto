using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {
        byte trabajoTarea;
        public ToDo_Trabajo(string tipo, string detalle, byte nTarea, string fecha, byte trabajoTarea) : base(tipo, detalle, nTarea, fecha)
        {
            this.trabajoTarea = trabajoTarea;
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea, string fecha)
        {
            base.AgregarInfo(tipo, detalle, nTarea, fecha);
        }

        public void PreguntarInfoTrabajo()
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("| Su tarea pendiente es para oficina (proyecto) o cliente?|");
            Console.WriteLine("----------------------------------------------------------|");
            Console.WriteLine("|1. Proyecto de oficina                                   |");
            Console.WriteLine("|                             2. Cliente                  |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            trabajoTarea = Convert.ToByte(Console.ReadLine());
        }
    }
}