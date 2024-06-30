using System;
namespace MiniProyecto
{

    public class ToDo_Estudio : ToDo
    {
        public ToDo_Estudio(string tipo, string detalle, byte nTarea, string fecha) : base(tipo, detalle, nTarea, fecha)
        {
        }

        public override void AgregarInfo(string tipo, string detalle, byte nTarea, string fecha)
        {
            base.AgregarInfo(tipo, detalle, nTarea, fecha);
        }
    }
}
