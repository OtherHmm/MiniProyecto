using System;

namespace MiniProyecto
{
    public class ToDo_Trabajo : ToDo
    {
        public ToDo_Trabajo(string tipo, string detalle, byte nTarea, string fecha) : base(tipo, detalle, nTarea, fecha)
        {
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea, string fecha)
        {
            base.AgregarInfo(tipo, detalle, nTarea, fecha);
        }
    }
}
