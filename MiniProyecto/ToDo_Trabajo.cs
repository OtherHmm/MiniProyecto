using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {
        byte TrabajoTarea;
        public ToDo_Trabajo(string tipo, string detalle, byte nTarea, byte trabajoTarea) : base(tipo, detalle, nTarea)
        {
            TrabajoTarea = trabajoTarea;
        }
        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }
        public void PreguntarInfoTrabajo()
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            Console.WriteLine("| Su tarea pendiente es para oficina (proyecto) o cliente?|");
            Console.WriteLine("----------------------------------------------------------|");
            Console.WriteLine("|1. Proyecto de oficina                                   |");
            Console.WriteLine("|                             2. Cliente                  |");
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");
            TrabajoTarea = Convert.ToByte(Console.ReadLine());
        }
        public override void MostrarInfo(byte nTarea)
        {
            base.MostrarInfo(nTarea);

            if (TrabajoTarea == 1)
            {
                Console.WriteLine("\nProyecto de oficina \n");
            }
            if (TrabajoTarea == 2)
            {
                Console.WriteLine("\nProyecto Cliente\n");
            }
            
        }
    }
}