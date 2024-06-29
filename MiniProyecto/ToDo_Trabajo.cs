using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {
        public ToDo_Trabajo(string tipo, string detalle, byte nTarea) : base(tipo, detalle, nTarea)
        {
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea)
        {
            base.AgregarInfo(tipo, detalle, nTarea);
        }
    }
}
