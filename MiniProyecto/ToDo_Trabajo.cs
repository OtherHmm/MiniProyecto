using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {

        /*
        string Proyecto;
        public To_doTrabajo(string titulo, string proyecto) : base(titulo)
        {
            Proyecto = proyecto;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Proyecto: {Proyecto}");
        }*/
        public ToDo_Trabajo(string tipo, string nombre, string detalle) : base(tipo, nombre, detalle)
        {
        }
    }
}
