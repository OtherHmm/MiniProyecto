using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {
        public ToDo_Trabajo(string tipo, string nombre, string detalle) : base(tipo, nombre, detalle)
        {

        }
        public override void AgregarInfo(string tipo, string nombre, string detalle)
        {
            base.AgregarInfo(tipo, nombre, detalle);
        }
    }
}
